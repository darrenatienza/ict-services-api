using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Admin
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName,  LastName); } }
        public DateTime? CreateDate { get; set; }
        public string Role { get; set; }
        public string CreatedBy { get; set; }
    }
}