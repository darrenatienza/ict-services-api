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
    public class StudentReqTypesController : ApiController
    {

        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAll(string criteria)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.StudentReqTypes.GetAll());

                    return Ok(objs);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET api/studreqtype/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/studreqtype
        public void Post([FromBody]string value)
        {
        }

        // PUT api/studreqtype/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/studreqtype/5
        public void Delete(int id)
        {
        }
    }
}
