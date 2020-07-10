using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1;
using API.Queries.Core.Domain.Common;
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
    public class InvTypesController : ApiController
    {
        // GET api/invtypes
        public IHttpActionResult Get()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    return Ok(uow.InvTypes.GetAll());
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError,ex);
            }
        }

        // GET api/invtypes/5
        [HttpGet]
        public IHttpActionResult Get(int invTypeID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    // Todo: Create Model of Invetnroy Type
                    InvTypeModel model = new InvTypeModel();
                    var obj = uow.InvTypes.Get(invTypeID);
                    model.InvTypeID = obj.InvTypeID;
                    model.Code = obj.Code;
                    model.Description = obj.Description;
             
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST api/invtypes
        public void Post([FromBody]string value)
        {
        }

        // PUT api/invtypes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/invtypes/5
        public void Delete(int id)
        {
        }
    }
}
