using API.Queries.Core.Domain;
using API.Queries.Core.Domain.Auth;
using API.Queries.Core.IRepositories;

using API.Queries.Core.IRepositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Persistence.Repositories.Auth
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DataContext context)
            :base(context)
        {

        }
        public IEnumerable<Permission> GetPermissions()
        {
            return DataContext.AuthPermissions.ToList();
        }
        public DataContext DataContext
        {
            get
            {
                return Context as DataContext;
            }
        }


        public IEnumerable<Permission> GetPermissionsByUserID(int userID)
        {
            return DataContext.AuthPermissions
                .Where(u => u.Users.Any(p => p.UserID == userID));
        }


        public IEnumerable<Permission> GetAvailablePermission(IEnumerable<Permission> excludePermissions)
        {
            //StringBuilder excludedIDs = new StringBuilder();
            //foreach (Permission item in excludePermissions)
            //{
            //    excludedIDs.AppendFormat("{0},", item.PermissionID);
            //}
            //string[] excludeIDArray = excludedIDs.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var exPermissions = excludePermissions.Select(ex => ex.PermissionID).ToList();
            return DataContext.AuthPermissions
               .Where(p => !exPermissions.Any(ex => ex == p.PermissionID));
        }


        public IEnumerable<Permission> GetAvailablePermission(string[] permissionIDs)
        {
            return DataContext.AuthPermissions
               .Where(p => !permissionIDs.Any(p1 => p1 == p.PermissionID.ToString()));
        }


        public IEnumerable<Permission> GetValidPermissionsList(IEnumerable<Permission> permissionList)
        {
            List<Permission> newPermissions = new List<Permission>();
            permissionList.ToList().ForEach(p => newPermissions.Add(DataContext.AuthPermissions.Find(p.PermissionID)));
            return newPermissions;
        }
    }
}
