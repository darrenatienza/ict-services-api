using V1_2 = API.Jwt.Models.Inventory.v1_2;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;
using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1_3;
using API.Jwt.Models.Inventory.v1_2;
using API.Queries.Core.Domain.Logs;

namespace API.Jwt.Controllers.Inventory.v1_2

{
    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class InvRecordsController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get(string criteria, string location, string type, string status)
        {

            // read all records with printing
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    criteria = criteria == null ? "" : criteria;
                    location = location == null ? "" : location;
                    type = type == null ? "" : type;
                    status = status == null ? "" : status;
                    var objs = uow.InvRecords.GetAll_Criteria(criteria,location, type, status);
                    List<V1_2.InvRecordListModel> models = new List<V1_2.InvRecordListModel>();
                    foreach (var item in objs)
                    {
                        V1_2.InvRecordListModel model = new V1_2.InvRecordListModel();
                        model.InvRecordID = item.InvRecordID;
                        model.PropertyNum = item.PropertyNum;
                        model.InvRecordGuid = item.InvRecordGUID;
                        model.EquipNum = item.InvDetail.InvType.Code + item.EquipNum;
                        model.InvLoc_Desc = item.InvLocation.Description;
                        model.InvType_Desc = item.InvDetail.InvType.Description;
                        model.DateAcquired = item.DateAcquired;
                        if (item.InvStatID == null)
                        {
                            model.Status = item.Status;
                        }
                        else
                        {
                            model.Status = item.InvStat.Description;
                        }
                        
                        models.Add(model);
                    }
                    return Ok(models);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        
        [HttpPost]
        public IHttpActionResult Post(AddInvRecordDTO model)
        {
            //changes: remove support to status field on database.. all status field will be null on adding new record 
            //Added Model State Validation and InvRecordGuid property to model

           
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = new InvRecord();
                    obj.InvRecordGUID = Guid.NewGuid();
                    obj.PropertyNum = model.PropertyNum;
                    obj.EquipNum = model.EquipNum.Substring(model.EquipNum.Length - 5);
                    obj.DateAcquired = model.DateAcquired;
                    obj.InvStatID = model.InvStatID;
                    obj.InvDetailID = model.InvDetailID;
                    obj.InvLocationID = model.InvLocationID;
                    obj.Remarks = model.Remarks;
                    uow.InvRecords.Add(obj);
                    uow.Complete();
                    return Ok(obj.InvRecordGUID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        public IHttpActionResult Get(int invRecordID)
        {
            // get a record using invRecordID
            try
            {
                string userGuID = "";
                // Get UserGuid on Http Header
                var headers = Request.Headers;
                if (headers.Contains("UserGuid"))
                {
                    userGuID = headers.GetValues("UserGuid").First();
                }

                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.InvRecords.GetInvRecord(invRecordID);
                    
                    InvRecordDetailDTO model = new InvRecordDetailDTO();
                    
                    model.InvRecordGuid = obj.InvRecordGUID;
                    // add guid if no guid
                    if (obj.InvRecordGUID == null)
                    {
                        obj.InvRecordGUID = Guid.NewGuid();

                        // if no guid means that it is old record
                        // for better logging add the current value to user activity
                        UserActivityLog log = new UserActivityLog();
                        log.CreateTimeStamp = DateTime.Now;
                        log.Action = "Add";
                        log.RecordGUID = obj.InvRecordGUID;
                        log.UserGUID = Guid.Parse(userGuID);
                        log.Message = string.Format("Initial Values \n" + 
                                                                     "Type: {0}\n" +
                                                                     "Property Number: {1}\n" +
                                                                     "Equipment Number: {2}\n" +
                                                                     "Date Acquired: {3} \n" +
                                                                     "Inventory Detail: {4}\n" +
                                                                     "Office / Location: {5}\n" +
                                                                     "Status: {6}\n" +
                                                                     "Remarks: {7}",
                                                                         obj.InvDetail.InvType.Description,
                                                                         obj.PropertyNum,
                                                                         obj.InvDetail.InvType.Code + obj.EquipNum,
                                                                         obj.DateAcquired != null ? obj.DateAcquired.Value.ToShortDateString() : "",
                                                                         obj.InvDetail.Description,
                                                                         obj.InvLocation.Description,
                                                                         obj.InvStatID == null ? obj.Status : obj.InvStat.Description, // if inv status is null use status field
                                                                         obj.Remarks);
                        uow.UserActivityLogs.Add(log); // add the new log record
                        uow.InvRecords.Edit(obj); // edit the guid
                        uow.Complete(); // commit transaction
                    }
                    
                    model.InvRecordID = obj.InvRecordID;
                    model.PropertyNum = obj.PropertyNum;
                    model.EquipNum = obj.InvDetail.InvType.Code + obj.EquipNum;
                    model.DateAcquired = obj.DateAcquired;
                    model.InvLocationID = obj.InvLocationID;
                    model.InvDetailID = obj.InvDetailID;
                    model.InvTypeID = obj.InvDetail.InvTypeID;
                    // get the id base on invstats description in invrecords if invstat is null
                    if (obj.InvStatID == null)
                    {
                        model.InvStatID = uow.InvStats.Get(obj.Status).InvStatID;
                    }
                    else
                    {
                        model.InvStatID = obj.InvStatID;
                    }
                    model.Remarks = obj.Remarks;
                   
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int invRecordID, EditInvRecordDTO model)
        {
            //changes: remove support to status field on database.. all status field will be no changes on existing record after updating
            //Added Model State Validation and InvRecordGuid property to model
            try
            {
               
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var uow = new UnitOfWork(new DataContext()))
                {
                   
                    var obj = uow.InvRecords.Get(invRecordID);
                    var guid = Guid.NewGuid();
                    if (obj.InvRecordGUID == null)
                    {
                        obj.InvRecordGUID = Guid.NewGuid();
                    }
                    obj.PropertyNum = model.PropertyNum;
                    obj.DateAcquired = model.DateAcquired;
                    obj.InvStatID = model.InvStatID;
                    obj.InvDetailID = model.InvDetailID;
                    obj.InvLocationID = model.InvLocationID;
                    obj.Remarks = model.Remarks;
                    uow.InvRecords.Edit(obj);
                    uow.Complete();
                    return Ok(obj.InvRecordGUID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        
    }
}
