using API.Jwt.Filters;
using API.Jwt.Models.Common;
using API.Jwt.Models.Common.v1;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Jwt.Controllers.Common.v1
{
    [AllowAnonymous]
    public class LogsController : ApiController
    {
        // GET api/log
        public IHttpActionResult Get(Guid identityID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    return Ok("");
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET api/log/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/log
        public void Post( PostLogModel model)
        {   
           
        }

        // PUT api/log/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/log/5
        public void Delete(int id)
        {
        }
    }
}
