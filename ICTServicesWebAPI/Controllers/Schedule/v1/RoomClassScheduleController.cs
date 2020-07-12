using API.Jwt.Models.Schedule.ClassSchedule;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Jwt.Controllers.Schedule.v1
{
    public class RoomClassScheduleController : ApiController
    {
        // GET: api/RoomClassSchedule
        public async Task<IHttpActionResult> Get(int roomID, string semester, int schoolYearID)
        {
            using (var uow = new UnitOfWork(new DataContext()))
            {
                var roomClassSchedules = uow.ClassSchedules.GetAll(roomID, semester, schoolYearID);
                var dto = new RoomClassScheduleDTO();
                foreach (var classSchedule in roomClassSchedules)
                {

                }
            }
            return Ok();
        }

        // GET: api/RoomClassSchedule/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomClassSchedule
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomClassSchedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomClassSchedule/5
        public void Delete(int id)
        {
        }
    }
}
