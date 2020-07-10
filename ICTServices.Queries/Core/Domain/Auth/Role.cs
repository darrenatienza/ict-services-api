using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Auth
{
    [Table("Auth.Roles")]
    public class Role
    {
        public Role()
        {

        }
        public int RoleID { get; set; }
        public string Description { get; set; }
    }
}
