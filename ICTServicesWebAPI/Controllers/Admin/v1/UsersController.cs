using API.Jwt.Filters;
using API.Jwt.Models.Admin;
using API.Queries.Core.Domain.Auth;
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
    public class UsersController : ApiController
    {
        //[Authorize(Roles= SysRole.Admin)]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Get(string criteria)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var users = await Task.Run(()=>uow.Users.GetAllByCriteria(criteria));
                    List<UserModel> models = new List<UserModel>();
                    foreach (var user in users)
                    {
                        UserModel model = new UserModel();
                        model.UserID = user.UserID;
                        model.UserName = user.UserName;
                        model.FirstName = user.FirstName;
                        model.MiddleName = user.MiddleName;
                        model.LastName = user.LastName;
                        model.Role = user.Role;
                        model.CreateDate = user.CreateDate ;
                        model.CreatedBy = user.UserCreatedBy;
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

        // GET api/user
        [Authorize(Roles = SysRole.Admin)]
        [JwtAuthentication]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var users = await Task.Run(() => uow.Users.GetAll());
                    List<UserModel> models = new List<UserModel>();
                    foreach (var user in users)
                    {
                        UserModel model = new UserModel();
                        model.UserID = user.UserID;
                        model.UserName = user.UserName;
                        model.FirstName = user.FirstName;
                        model.MiddleName = user.MiddleName;
                        model.LastName = user.LastName;
                        model.Role = user.Role;
                        model.CreateDate = user.CreateDate;
                        model.CreatedBy = user.UserCreatedBy;
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
        
        // GET api/user/5
        [Authorize(Roles = SysRole.Admin)]
        [JwtAuthentication]
        public IHttpActionResult Get(int userid)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var user = uow.Users.Get(userid);
                    UserModel model = new UserModel();
                    model.UserName = user.UserName;
                    model.UserID = user.UserID;
                    model.FirstName = user.FirstName;
                    model.MiddleName = user.MiddleName;
                    model.LastName = user.LastName;
                    model.Role = user.Role;
                    model.CreateDate = user.CreateDate;
                    model.CreatedBy = user.UserCreatedBy;
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [JwtAuthentication]
        [HttpGet]
        public IHttpActionResult Get(bool isGetCurrentUser)
        {
            if (isGetCurrentUser)
            {
                return Ok(RequestContext.Principal.Identity.Name);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Current User Not Found!");
            }
        }
        
        // POST api/user
        [HttpPost]
        [Authorize(Roles = SysRole.Admin)]
        [JwtAuthentication]
        public async Task<IHttpActionResult> Post(UserModel user)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();
                string encrypPass = "";
                using (var uow = new UnitOfWork(new DataContext()))
                {
                   
                    var obj = new User();
                    obj.UserName = user.UserName;
                    obj.CreateDate = DateTime.Now;
                    obj.FirstName = user.FirstName;
                    obj.LastName = user.LastName;
                    obj.MiddleName = user.MiddleName;
                    encrypPass = await Task.Run(() => crypto.Compute(user.Password));
                    obj.Password = encrypPass;
                    obj.PasswordSalt = crypto.Salt;
                    obj.Role = user.Role;
                    obj.UserCreatedBy = RequestContext.Principal.Identity.Name;
                    uow.Users.Add(obj);
                    uow.Complete();
                    return Ok(obj.UserID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [HttpPut]
        [Authorize(Roles = SysRole.Admin)]
        [JwtAuthentication]
        public async Task<IHttpActionResult> Put(int userID,UserModel user)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();
                string encrypPass = "";
                using (var uow = new UnitOfWork(new DataContext()))
                {

                    var obj = uow.Users.Get(userID);
                    obj.FirstName = user.FirstName;
                    obj.LastName = user.LastName;
                    obj.MiddleName = user.MiddleName;
                    encrypPass = await Task.Run(() => crypto.Compute(user.Password));
                    obj.Password = encrypPass;
                    obj.PasswordSalt = crypto.Salt;
                    obj.Role = user.Role;
                    uow.Users.Edit(obj);
                    uow.Complete();
                    return Ok(obj.UserID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Authorize(Roles = SysRole.Admin)]
        [JwtAuthentication]
        // DELETE api/user/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                
                using (var uow = new UnitOfWork(new DataContext()))
                {

                    var obj = uow.Users.Get(id);
                    uow.Users.Remove(obj);
                    uow.Complete();
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
