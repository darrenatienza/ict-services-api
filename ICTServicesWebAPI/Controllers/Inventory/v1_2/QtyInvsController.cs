using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1_2;
using API.Queries.Core.Domain.Inventory;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Jwt.Controllers.Inventory.v1_2
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
                        model.InvStat_Description = item.InvStat == null ? "" : item.InvStat.Description;
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
