﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Schedule.ClassSchedule
{
    public class RoomClassScheduleDTO
    {
        public string RoomName { get; set; }

        public List<RoomClassScheduleItem> RoomClassScheduleItems { get; set; }

    }
}