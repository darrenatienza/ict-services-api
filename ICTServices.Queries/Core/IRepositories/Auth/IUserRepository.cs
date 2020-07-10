using API.Queries.Core.Domain;
using API.Queries.Core.Domain.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.Auth
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUsers();

        User GetUser(string userName);

        User GetUser(int userID);
        void RemoveUsersPermissions(int userID);

        IEnumerable<User> GetAllByCriteria(string criteria);

        User Get(Guid? nullable);
    }
}
