using V3 = API.Jwt.Models.Inventory.v3;
using V1 = API.Jwt.Models.Inventory.v1;

using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;
using API.Jwt.Filters;

namespace API.Jwt.Controllers.Inventory.v1

{
    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class InvRecordsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllByInvDetailID(bool isGetByInvDetailID, int invDetailID)
        {
            try
            {
                if (isGetByInvDetailID)
                {
                    using (var uow = new UnitOfWork(new DataContext()))
                    {
                       
                        var objs = uow.InvRecords.GetAllByInvDetailID(invDetailID);
                        List<V1.ReadAllInvRecords> models = new List<V1.ReadAllInvRecords>();
                        foreach (var item in objs)
                        {
                            V1.ReadAllInvRecords model = new V1.ReadAllInvRecords();
                            model.InvRecordID = item.InvRecordID;
                            model.PropertyNum = item.PropertyNum;
                            model.EquipNum = item.InvDetail.InvType.Code + item.EquipNum;
                            model.InvLocation_Description = item.InvLocation.Description;
                            model.Status = item.Status;
                            models.Add(model);
                        }
                        return Ok(models);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }

            return Content(HttpStatusCode.NotImplemented, "Method Not implemented");
        }

        [HttpGet]
        public IHttpActionResult CheckIfExists(bool isCheckIfExists, string propNum)
        {
            try
            {
                if (isCheckIfExists)
                {
                    using (var uow = new UnitOfWork(new DataContext()))
                    {

                        bool isExists = uow.InvRecords.CheckIfExists(propNum);
                        return Ok(isExists);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }

            return Content(HttpStatusCode.NotImplemented, "Method Not implemented");
        }
        [HttpGet]
        public IHttpActionResult Get(string criteria, string location, string type, string status)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    criteria = criteria == null ? "" : criteria;
                    location = location == null ? "" : location;
                    type = type == null ? "" : type;
                    status = status == null ? "" : status;
                    var objs = uow.InvRecords.GetAll_Criteria(criteria,location, type, status);
                    List<V1.InvRecordModel> models = new List<V1.InvRecordModel>();
                    foreach (var item in objs)
                    {
                        V1.InvRecordModel model = new V1.InvRecordModel();
                        model.InvRecordID = item.InvRecordID;
                        model.PropertyNum = item.PropertyNum;
                        model.EquipNum = item.InvDetail.InvType.Code + item.EquipNum;
                        model.DateAcquired = item.DateAcquired;
                        model.Status = item.Status;
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
        [HttpGet]
        public IHttpActionResult Get(string criteria,int qtyInvID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    criteria = criteria == null ? "" : criteria;
                    var objs = uow.InvRecords.GetAll_Criteria(criteria, qtyInvID);
                    List<V1.InvRecordModel> models = new List<V1.InvRecordModel>();
                    foreach (var item in objs)
                    {
                        V1.InvRecordModel model = new V1.InvRecordModel();
                        model.InvRecordID = item.InvRecordID;
                        model.PropertyNum = item.PropertyNum;
                        model.EquipNum = item.QtyInv.InvType.Code + item.EquipNum;
                        model.DateAcquired = item.DateAcquired;
                        model.Status = item.Status;
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
        /// <summary>
        /// Generate New Equipment Number
        /// </summary>
        /// <param name="IsGenEquipNum"></param>
        /// <param name="invTypeID"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(bool IsGenEquipNum, int invTypeID)
        {
            try
            {
                if (IsGenEquipNum)
                {
                    using (var uow = new UnitOfWork(new DataContext()))
                    {
                        //Get the last Equipment Number of the selected Inventory Type
                        //if the selected inventory type is Desktop Computer ID, get the last equipment inventory
                        //related to desktop computer id
                        string invTypeCode = uow.InvTypes.Get(invTypeID).Code;
                        string lstNum = string.Format("{0:00000}", uow.InvRecords.GetLastEquipNum(invTypeID) + 1);
                        return Ok(invTypeCode + lstNum);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }

            return Content(HttpStatusCode.NotImplemented, "Method Not implemented");
        }

        [HttpGet]
        public IHttpActionResult GetCountByQtyInvID(bool IsGetCountByQtyInvID, int qtyInvID)
        {
            try
            {
                if (IsGetCountByQtyInvID)
                {
                    using (var uow = new UnitOfWork(new DataContext()))
                    {
                        var count = uow.InvRecords.GetCountByQtyInvID(qtyInvID);


                        
                        return Ok(count);
                    }
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
            return Content(HttpStatusCode.NotImplemented, "Method Not implemented");
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
                    model.EquipNum = obj.QtyInv.InvType.Code + obj.EquipNum;
                    model.DateAcquired = obj.DateAcquired;
                    model.InvLocationID = obj.InvLocationID;
                    model.InvDetailID = obj.InvDetailID;
                    model.InvTypeID = obj.InvDetail.InvTypeID;
                    model.Remarks = obj.Remarks;
                    model.Status = obj.Status;
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(V1.InvRecordModel model)
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
                    obj.QtyInvID = model.QtyInvID;
                    obj.InvLocationID = model.InvLocationID;
                    uow.InvRecords.Add(obj);
                    // add new count to quantity inventory
                    var qtyInv = uow.QtyInvs.Get(model.QtyInvID);
                    qtyInv.Count++;
                    uow.QtyInvs.Edit(qtyInv);                   
                    uow.Complete();
                    return Ok(obj.InvRecordID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int invRecordID, V1.InvRecordModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.InvRecords.Get(invRecordID);
                    obj.PropertyNum = model.PropertyNum;
                    obj.DateAcquired = model.DateAcquired;
                    obj.Status = model.Status;
                    obj.InvDetailID = model.InvDetailID;
                    obj.InvLocationID = model.InvLocationID;
                    obj.Remarks = model.Remarks;
                    uow.InvRecords.Edit(obj);
                    uow.Complete();
                    return Ok(obj.InvRecordID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE api/invrecord/5
        public IHttpActionResult Delete(int invRecordID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.InvRecords.Get(invRecordID);
                
                    uow.InvRecords.Remove(obj);
                    uow.Complete();
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
