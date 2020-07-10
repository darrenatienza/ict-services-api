using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1;
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
    public class InvLocationsController : ApiController
    {
        // GET api/invlocation
        public IHttpActionResult Get()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    return Ok(uow.InvLocations.GetAll());
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/invlocation/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post()
        {
        }

        // PUT api/invlocation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/invlocation/5
        public void Delete(int id)
        {
        }
    }
}
