using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Jwt.Controllers.ClassSchedule.v1
{
    public class ClassScheduleController : ApiController
    {
        [AllowAnonymous]
        // GET api/classschedule
        public async Task<IHttpActionResult> Get() => 
            Ok(new string[] { "asdf" });

        // GET api/classschedule/5
        public string Get(int id) => 
            "value";

        // POST api/classschedule
        public void Post([FromBody]string value)
        {
        }

        // PUT api/classschedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/classschedule/5
        public void Delete(int id)
        {
        }
    }
}
