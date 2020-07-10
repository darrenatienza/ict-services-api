using API.Jwt.Filters;
using V1 = API.Jwt.Models.Inventory.v1;
using V2 = API.Jwt.Models.Inventory.v2;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;
using API.Jwt.Models.Inventory.v1_2;

namespace API.Jwt.Controllers.Inventory.v1_2
{

    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class InvDetailsController : ApiController
    {
        // GET api/invdetail
        public IHttpActionResult Get(int invTypeID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var invDetails = uow.InvDetails.GetAll(invTypeID);
                    List<InvDetailModel> models = new List<InvDetailModel>();
                    foreach (var item in invDetails)
                    {
                        InvDetailModel model = new InvDetailModel();
                        model.InvDetailID = item.InvDetailID;
                        model.Description = item.Description;
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
