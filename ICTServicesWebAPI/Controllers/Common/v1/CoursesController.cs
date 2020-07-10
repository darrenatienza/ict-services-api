using API.Jwt.Models.Common;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Jwt.Controllers.Common.v1
{

    public class CoursesController : ApiController
    {
        // GET api/semester
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAll(int collegeID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.Courses.GetAll(collegeID));
                    List<CourseModel> models = new List<CourseModel>();
                    foreach (var item in objs)
                    {
                        CourseModel model = new CourseModel();
                        model.CourseID = item.CourseID;
                        model.Code = item.Code;
                        model.Description = item.Description;
                        models.Add(model);
                    }
                    return Ok(models);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET api/semester/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/semester
        public void Post([FromBody]string value)
        {
        }

        // PUT api/semester/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/semester/5
        public void Delete(int id)
        {
        }
    }
}
