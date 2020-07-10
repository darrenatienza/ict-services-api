using API.Queries.Core.Domain;
using API.Queries.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Queries.Core.Domain.Auth;

using API.Queries.Core.IRepositories.Auth;

namespace API.Queries.Persistence.Repositories.Auth
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context)
            : base(context)
        {
        }
        public IEnumerable<User> GetUsers()
        {
            return DataContext.AuthUsers.ToList();
        }
        public DataContext DataContext
        {
            get
            {
                return Context as DataContext;
            }
        }


        public User GetUser(string userName)
        {

            return DataContext.AuthUsers.Include(u => u.Permissions).FirstOrDefault(user => user.UserName == userName);
        }


        public void RemoveUsersPermissions(int userID)
        {

            var a = DataContext.AuthUsers.Include(i => i.Permissions).Where(u => u.UserID == userID).FirstOrDefault<User>();
            var p = a.Permissions.ToList();
            p.ForEach(pe => a.Permissions.Remove(pe));
        }


        public User GetUser(int userID)
        {
            return DataContext.AuthUsers.Include(i => i.Permissions).Where(u => u.UserID == userID).FirstOrDefault<User>();
        }


        public IEnumerable<User> GetAllByCriteria(string criteria)
        {
            return DataContext.AuthUsers.Where(rec => rec.UserName.Contains(criteria) || rec.FirstName.Contains(criteria) || rec.LastName.Contains(criteria));
        }


        public User Get(Guid? userID)
        {
            return DataContext.AuthUsers.FirstOrDefault(r => r.UserGUID == userID);
        }
    }

   
}
