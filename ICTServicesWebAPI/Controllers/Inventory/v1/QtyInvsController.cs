using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1;
using API.Queries.Core.Domain.Inventory;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Jwt.Controllers.Inventory.v1
{

    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class QtyInvsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string criteria)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    criteria = criteria == null ? "" : criteria;
                    var qtyinvs = uow.QtyInvs.GetAll_Criteria(criteria);
                    List<ReadAllQtyInvModel> models = new List<ReadAllQtyInvModel>();
                    foreach (var item in qtyinvs)
                    {
                        ReadAllQtyInvModel model = new ReadAllQtyInvModel();
                        model.QtyInvID = item.QtyInvID;
                        model.InvType_Description = item.InvType.Description;
                        model.InvLocation_Description = item.InvLocation.Description;
                        model.Count = item.Count;
                        model.InvRecCount = item.InvRecCount;
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
        public IHttpActionResult Get(int qtyInvID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var qtyinv = uow.QtyInvs.Get(qtyInvID);
                    var model = new ReadOneQtyInvModel();
                    model.QtyInvID = qtyinv.QtyInvID;
                    model.Count = qtyinv.Count;
                    model.InvLocationID = qtyinv.InvLocationID;
                    model.InvTypeID = qtyinv.InvTypeID;
                    model.invStatID = qtyinv.InvStatID;
                    model.Remarks = qtyinv.Remarks;
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        public IHttpActionResult Post(ReadOneQtyInvModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {

                    var qtyInv = new QtyInv();
                    qtyInv.InvTypeID = model.InvTypeID;
                    qtyInv.InvLocationID = model.InvLocationID;
                    qtyInv.Remarks = model.Remarks;
                    qtyInv.Count = model.Count;
                    qtyInv.InvStatID = model.invStatID;
                    uow.QtyInvs.Add(qtyInv);
                    uow.Complete();
                    return Ok(qtyInv.QtyInvID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT api/qtyinv/5
        public IHttpActionResult Put(int qtyInvID, ReadOneQtyInvModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {

                    var qtyInv = uow.QtyInvs.Get(qtyInvID);
                    if (qtyInv == null)
                    {
                        return NotFound();
                    }
                    qtyInv.InvTypeID = model.InvTypeID;
                    qtyInv.InvLocationID = model.InvLocationID;
                    qtyInv.Remarks = model.Remarks;
                    qtyInv.Count = model.Count;
                    qtyInv.InvStatID = model.invStatID;
                    uow.QtyInvs.Edit(qtyInv);
                    uow.Complete();
                    return Ok(qtyInv.QtyInvID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

       [HttpDelete]
        public IHttpActionResult Delete(int qtyInvID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var qtyInv = uow.QtyInvs.Get(qtyInvID);
                    uow.QtyInvs.Remove(qtyInv);
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
