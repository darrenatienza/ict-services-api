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
    public class SchoolYearsController : ApiController
    {
        // GET api/schoolyear

        [AllowAnonymous]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.SchoolYears.GetAll());
                    
                    return Ok(objs);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET api/schoolyear/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/schoolyear
        public void Post([FromBody]string value)
        {
        }

        // PUT api/schoolyear/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/schoolyear/5
        public void Delete(int id)
        {
        }
    }
}
