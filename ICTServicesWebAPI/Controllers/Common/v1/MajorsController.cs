using API.Jwt.Models.Common;
using API.Queries.Core.Domain.Common;
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

    public class MajorsController : ApiController
    {
        // GET api/major
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAll(int courseID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.Majors.GetAll(courseID));
                    List<MajorModel> models = new List<MajorModel>();
                    foreach (var item in objs)
                    {
                        MajorModel model = new MajorModel();
                        model.MajorID = item.MajorID;
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

        // GET api/major/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/major
        public void Post([FromBody]string value)
        {
        }

        // PUT api/major/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/major/5
        public void Delete(int id)
        {
        }
    }
}
