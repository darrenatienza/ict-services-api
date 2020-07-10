using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.ERBS
{
    public class VenueDetailDTO
    {
        public VenueDetailDTO()
        {

        }
        public int VenueID { get; set; }
        public string Description {get; set;}
    }
}