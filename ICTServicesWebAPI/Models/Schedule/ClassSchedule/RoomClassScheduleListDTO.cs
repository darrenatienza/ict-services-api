using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Schedule.ClassSchedule
{
    public class RoomClassScheduleListDTO
    {
        public string TimeStart { get; set; }
        public string  TimeEnd { get; set; }


        public string Description { get; set; }
        public string Section { get; set; }
        public int RowOccupied { get; set; }
    }
}