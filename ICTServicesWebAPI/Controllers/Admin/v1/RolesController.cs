using API.Jwt.Filters;
using API.Jwt.Models.Admin;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Jwt.Controllers.Admin.v1
{
    public class RolesController : ApiController
    {
        [JwtAuthentication]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var users = await Task.Run(() => uow.Roles.GetAll());
                    List<RoleModel> models = new List<RoleModel>();
                    foreach (var user in users)
                    {
                        RoleModel model = new RoleModel();
                        model.RoleID = user.RoleID;
                        model.Description = user.Description;
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

        // GET api/role/5
        [Route("api/admin/roles/{id}")]
        [AllowAnonymous]
        public string Get(int id)
        {
            return "value";
        }

        
        // POST api/role
        [Route("api/admin/roles")]
        [AllowAnonymous]
        public void Post(UserModel user)
        {
            Console.Write(user.UserName);
        }

        [Route("api/admin/roles")]
        // PUT api/role/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("api/admin/roles/{id}")]
        // DELETE api/role/5
        public void Delete(int id)
        {
        }
    }
}
