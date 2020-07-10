using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1;
using API.Jwt.Models.Log.v1;
using API.Queries.Core.Domain.Logs;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Jwt.Controllers.Inventory.v1
{
    
    public class UserActivityLogsController : ApiController
    {
        [JwtAuthentication]
        [HttpGet]
        // GET api/useractivity
        public IHttpActionResult Get(Guid? recordGuid)
        {
            // Get User Activity by Record Guid
            try
            {
          
                using (var uow = new UnitOfWork(new DataContext()))
                {
                     
                     var list = new List<UserActivityLogListDto>();
                     if (recordGuid != null)
                     {
                         var record = uow.UserActivityLogs.GetAll(recordGuid.Value).ToList();

                         foreach (var item in record)
                         {
                             UserActivityLogListDto dto = new UserActivityLogListDto();
                             dto.CreateTimeStamp = item.CreateTimeStamp;
                             var user = uow.Users.Get(item.UserGUID);
                             if (user != null)
                             {
                                 dto.User = user.UserName;
                             }
                             else
                             {
                                 dto.User = "Not Defined";
                             }
                             dto.Message = item.Message;
                             list.Add(dto);
                         }
                         
                     }
                     return Ok(list);

                }
               
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
           

           
        }

        // GET api/useractivity/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [JwtAuthentication]
        public IHttpActionResult Post(UserActivityModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {

                    var obj = new UserActivityLog();
                    obj.CreateTimeStamp = DateTime.Now;
                    obj.Action = model.Action;
                    obj.Message = model.Message;
                    obj.UserGUID = model.UserGuid;
                    obj.RecordGUID = model.RecordGuid;
                    uow.UserActivityLogs.Add(obj);
                    uow.Complete();
                    return Ok(obj.UserActivityLogID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }


        // PUT api/useractivity/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/useractivity/5
        public void Delete(int id)
        {
        }
    }
}
