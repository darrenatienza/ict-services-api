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
    public class CollegesController : ApiController
    {
        // GET api/college

        [AllowAnonymous]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.Colleges.GetAll());

                    return Ok(objs);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET api/college/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/college
        public void Post([FromBody]string value)
        {
        }

        // PUT api/college/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/college/5
        public void Delete(int id)
        {
        }
    }
}
