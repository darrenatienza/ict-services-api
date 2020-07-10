using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Auth
{
    [Table("Auth.Users")]
    public class User
    {
        public User()
        {
            Permissions = new HashSet<Permission>();
        }
        public int UserID { get; set; }
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserCreatedBy { get; set; }
        public Guid? UserGUID { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }

    }
}
