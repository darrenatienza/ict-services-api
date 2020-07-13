using API.Jwt.Models.Schedule.ClassSchedule;
using API.Queries.Persistence;
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
        public async Task<IHttpActionResult> Get() {
            using (var uow = new UnitOfWork(new DataContext()))
            {
                return Ok();
            }
        }
        // GET: api/classSchedules/
        public async Task<IHttpActionResult> Get(int roomID, string semester, int schoolYearID)
        {
            using (var uow = new UnitOfWork(new DataContext()))
            {
                var roomClassSchedules = uow.ClassSchedules.GetAll(roomID, semester, schoolYearID);
                var dto = new RoomClassScheduleDTO();
                foreach (var classSchedule in roomClassSchedules)
                {
                    
                }
                return Ok();
            }
           
        }



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
