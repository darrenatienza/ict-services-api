using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1_4;
using API.Queries.Core.Domain.Inventory;
using API.Queries.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Jwt.Controllers.Inventory.v1_4
{

    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class QtyInvsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll(string type, string location, string status)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    location = location == null ? "" : location;
                    type = type == null ? "" : type;
                    status = status == null ? "" : status;

                    var data = uow.QtyInvs.GetAll_Criteria(type, location, status).ToList();
                    // group related data
                    var d = (from f in data
                             group f by new { InvTypeDescription = f.InvType.Description, InvLocationDescription = f.InvLocation.Description }
                                 into myGroup
                                 where myGroup.Count() > 0
                                 select new
                                 {
                                     myGroup.Key.InvTypeDescription,
                                     myGroup.Key.InvLocationDescription,
                                     invStats = myGroup.GroupBy(f => f.InvStat.Description)
                                     .Select(m => new { Sub = m.Key, count = m.Sum(c => c.Count) })
                                 }).ToList();
                    // get inventory status
                    var invStats = uow.InvStats.GetAll().ToList();
                    List<ReadAllQtyInvModel> qtyInvs = new List<ReadAllQtyInvModel>();
                    for (int i = 0; i < d.Count; i++)
                    {
                        ReadAllQtyInvModel qtyInv = new ReadAllQtyInvModel();

                        qtyInv.InvType_Description = d[i].InvTypeDescription.ToString();
                        qtyInv.InvLocation_Description = d[i].InvLocationDescription.ToString();
                        var res = d[i].invStats.ToList();
                        foreach (var item in invStats)
                        {
                            var count = res.FirstOrDefault(colName => colName.Sub == item.Description) == null
                                ? 0
                                : res.FirstOrDefault(colName => colName.Sub == item.Description).count;

                            qtyInv.UnRecInvStats.Add(new ReadAllInvStatModel { Count = count, Description = item.Description });
                            qtyInv.RecInvStats.Add(new ReadAllInvStatModel { Count = uow.InvRecords.GetAll_Criteria("", d[i].InvLocationDescription.ToString(), d[i].InvTypeDescription.ToString(), item.Description).Count(), Description = item.Description });
                        }



                        qtyInvs.Add(qtyInv);
                    }

                    // Todo: Get Pivot using Model Class
                    return Ok(qtyInvs);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        private DataTable GetQtyInvPivotTable(string type, string location, string status)
        {

            // Online Resource: https://www.codeproject.com/Tips/844709/Pivot-Table-Using-Linq-Entity-and-SQL-Server-R-for
            try
            {
                DataTable dt = new DataTable();

                using (var uow  = new UnitOfWork(new DataContext()))
                {

                    //GetAllData() return All data for Student.

                    var data = uow.QtyInvs.GetAll_Criteria(type, location, status).ToList();

                    // Student data will be like below
                    //Applying linq for geeting pivot output

                    var d = (from f in data
                             group f by new { InvTypeDescription = f.InvType.Description, InvLocationDescription = f.InvLocation.Description }
                                 into myGroup
                                 where myGroup.Count() > 0
                                 select new
                                 {
                                     myGroup.Key.InvTypeDescription,
                                     myGroup.Key.InvLocationDescription,
                                     invStats = myGroup.GroupBy(f => f.InvStat.Description)
                                     .Select(m => new { Sub = m.Key, count =  m.Sum( c => c.Count)})
                                 }).ToList();

                    // By Using GetAllSubject() Method we will Get the list of all subjects

                    var invStats = uow.InvStats.GetAll().ToList();
                    // Distinct Subject Like Below
                    //Creating array for adding dynamic columns
                    ArrayList objDataColumn = new ArrayList();

                    if (data.Count() > 0)
                    {
                        //Three column are fix "rank","pupil","Total".
                        objDataColumn.Add("Type");
                        objDataColumn.Add("Location");

                        //Add Subject Name as column in Datatable
                        for (int i = 0; i < invStats.Count; i++)
                        {
                            objDataColumn.Add(invStats[i].Description);
                        }
                        
                    }
                    //Add dynamic columns name to datatable dt
                    for (int i = 0; i < objDataColumn.Count; i++)
                    {
                        dt.Columns.Add(objDataColumn[i].ToString());
                    }



                    //Add data into datatable with respect to dynamic columns and dynamic data
                    for (int i = 0; i < d.Count; i++)
                    {
                        List<string> tempList = new List<string>();
                        tempList.Add(d[i].InvTypeDescription.ToString());
                        tempList.Add(d[i].InvLocationDescription.ToString());
                        var res = d[i].invStats.ToList();
                        foreach (var item in invStats)
                        {
                            var count = res.FirstOrDefault(colName => colName.Sub == item.Description) == null
                                ? 0
                                : res.FirstOrDefault(colName => colName.Sub == item.Description).count;
                            tempList.Add(count.ToString());
                        }
                       
                        

                        dt.Rows.Add(tempList.ToArray<string>());
                    }
                    return dt;
                    //Now the Pivot datatable return like below screen
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
    }
}
