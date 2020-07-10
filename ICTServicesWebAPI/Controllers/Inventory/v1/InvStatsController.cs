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
    public class InvStatsController : ApiController
    {
        // GET api/invstat
        public IHttpActionResult Get()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = uow.InvStats.GetAll();
                    List<ReadAllInvStatModel> models = new List<ReadAllInvStatModel>();
                    foreach (var item in objs)
                    {
                        ReadAllInvStatModel model = new ReadAllInvStatModel();
                        model.InvStatID = item.InvStatID;
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

        // GET api/invstat/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/invstat
        public void Post([FromBody]string value)
        {
        }

        // PUT api/invstat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/invstat/5
        public void Delete(int id)
        {
        }
    }
}
