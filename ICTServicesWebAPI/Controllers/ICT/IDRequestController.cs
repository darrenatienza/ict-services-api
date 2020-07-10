using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Jwt.Controllers.ICT
{
    public class IDRequestController : ApiController
    {
        [AllowAnonymous]
        [Route("api/student/{studentid}/request/{requestid}")]
        // GET api/idrequest
        public IEnumerable<string> Get(int studentid, int requestid)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/idrequest/5
        [AllowAnonymous]
        [Route("api/student/request/{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [AllowAnonymous]
        [Route("api/student/request/")]
        // POST api/idrequest
        public void Post()
        {
        }
        [AllowAnonymous]
        [Route("api/student/request/{id}")]
        // PUT api/idrequest/5
        public void Put(int id)
        {
        }
        [AllowAnonymous]
        [Route("api/student/request/{id}")]
        // DELETE api/idrequest/5
        public void Delete(int id)
        {
        }
    }
}
