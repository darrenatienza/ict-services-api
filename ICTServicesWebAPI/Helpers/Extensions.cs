using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Helpers
{
    public static class Extensions
    {
        public static string GetFullName(this string firstName, string middleName, string lastName){
            return string.Format("{0} {1} {2}", firstName, middleName, lastName);


        }
        public static string GetFullName(this string firstName)
        {
            return firstName;


        }
    }
}