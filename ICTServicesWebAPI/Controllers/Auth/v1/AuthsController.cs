using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Jwt.Filters;
using API.Jwt.Models;
using API.Queries.Persistence;
using System;
using System.Threading.Tasks;
using API.Queries.Core.Domain.Auth;
using API.Jwt.Models.Auth.v1;

namespace API.Jwt.Controllers.Auth.v1
{
    public class AuthsController : ApiController
    {
        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> Get(LoginModel model)
        {
            // Login System User
            var user = await Task.Run(() => CheckUser(model.UserName,model.Password  ));
            if (user.UserID != 0)
            {
                var guid = AddUserGUIDIfNotExists(user.UserID);

                return Ok(new
                {
                    token = JwtManager.GenerateToken(model.UserName, user.Role),
                    user = new { userName = user.UserName, userGuid = guid}
                });
            }
            else
            {
                return Unauthorized();
            }

           
        }
        public string AddUserGUIDIfNotExists(int userID)
        {
            // if guid not exist add it
            try
            {
                using (var uOW = new UnitOfWork(new DataContext()))
                {
                    var user = uOW.Users.Get(userID);
                   
                    if (user.UserGUID == null)
                    {
                        user.UserGUID = Guid.NewGuid();
                        uOW.Users.Edit(user);
                        uOW.Complete();
                        
                    }
                    
                    return user.UserGUID.Value.ToString();
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public User CheckUser(string username, string password)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();

                using (var uOW = new UnitOfWork(new DataContext()))
                {
                    var user = uOW.Users.GetUser(username);
                    
                    if (user != null)
                    {
                        var crypt = crypto.Compute(password, user.PasswordSalt);
                        if (user.Password == crypt)
                        {
                            return user;
                        }
                    }
                }
                return new User();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
   
}
