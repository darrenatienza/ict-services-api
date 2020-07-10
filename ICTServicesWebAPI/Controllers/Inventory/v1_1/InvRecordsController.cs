using V3 = API.Jwt.Models.Inventory.v3;
using V1_1 = API.Jwt.Models.Inventory.v1_1;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;
using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1;
using API.Jwt.Models.Inventory.v1_1;

namespace API.Jwt.Controllers.Inventory.v1_1

{
    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class InvRecordsController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(string propNum, int invRecordID)
        {
            try
            {
             // check if the property number already exists   
                    using (var uow = new UnitOfWork(new DataContext()))
                    {
                        //get the record using invrecord
                        var invRecord = uow.InvRecords.Get(invRecordID);
                        
                        //check if property number are same
                        if (invRecord != null && invRecord.PropertyNum != propNum)
                        {
                            // if not get record using property number
                            var invRecord2 = uow.InvRecords.GetInvRecord(propNum);
                            //check if record exists
                            if (invRecord2 != null)
                            {
                                // if exists it means that the property number already exists with diff. record id
                                return Ok(new { isExists = true} );
                            }
                        }
                        // if not return false means no one handles the property number
                        return Ok(new { isExists = false });
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
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.InvRecords.GetInvRecord(invRecordID);


                    V3.InvRecordModel model = new V3.InvRecordModel();
                    model.InvRecordID = obj.InvRecordID;
                    model.PropertyNum = obj.PropertyNum;
                    model.EquipNum = obj.InvDetail.InvType.Code + obj.EquipNum;
                    model.DateAcquired = obj.DateAcquired;
                    model.InvLocationID = obj.InvLocationID;
                    model.InvDetailID = obj.InvDetailID;
                    model.InvTypeID = obj.InvDetail.InvTypeID;
                    model.Remarks = obj.Remarks;
                    model.Status = obj.Status;
                    model.InvStatID = obj.InvStatID;
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(InvRecordModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = new InvRecord();
                    obj.PropertyNum = model.PropertyNum;
                    obj.EquipNum = model.EquipNum.Substring(model.EquipNum.Length-5);
                    obj.DateAcquired = model.DateAcquired;
                    obj.Status = model.Status;
                    obj.InvDetailID = model.InvDetailID;
                    obj.InvLocationID = model.InvLocationID;
                    obj.Remarks = model.Remarks;
                    uow.InvRecords.Add(obj);                   
                    uow.Complete();
                    return Ok(obj.InvRecordID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }


        
    }
}
