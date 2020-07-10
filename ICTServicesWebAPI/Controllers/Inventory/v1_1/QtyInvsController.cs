using API.Jwt.Filters;

using API.Jwt.Models.Inventory.v1_1;
using API.Queries.Core.Domain.Inventory;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Jwt.Controllers.Inventory.v1_1{

    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class QtyInvsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int qtyInvID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var qtyinv = uow.QtyInvs.Get(qtyInvID);
                    var model = new ReadOneQtyInvModel();
                    model.QtyInvID                  = qtyinv.QtyInvID;
                    model.Count                     = qtyinv.Count;
                    model.InvLocation_Description   = qtyinv.InvLocation.Description;
                    model.InvType_Description       = qtyinv.InvType.Description;
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        public IHttpActionResult GetAll(string criteria)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    criteria = criteria == null ? "" : criteria;
                    var qtyinvs = uow.QtyInvs.GetAll_CriteriaV1_1(criteria);
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
    }
}
