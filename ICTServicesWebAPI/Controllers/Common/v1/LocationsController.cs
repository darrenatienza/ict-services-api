using API.Jwt.Models.Common;
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
    public class LocationsController : ApiController
    {

        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAll(int studentReqID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.Locations.GetAllByStudentReqID(studentReqID));
                    List<LocationModel> models = new List<LocationModel>();
                    foreach (var item in objs)
                    {
                        LocationModel model = new LocationModel();
                        model.LocationID = item.LocationID;
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

        // GET api/location/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/location
        public void Post([FromBody]string value)
        {
        }

        // PUT api/location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/location/5
        public void Delete(int id)
        {
        }
    }
}
