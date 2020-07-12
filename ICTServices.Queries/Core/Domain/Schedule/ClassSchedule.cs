using API.Queries.Core.Domain.Common;
using API.Queries.Core.Domain.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Schedule
{
    [Table("Schedule.ClassSchedules")]
    public class ClassSchedule
    {
        public ClassSchedule() { }

        public int ClassScheduleID { get; set; }

        public string Code { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public virtual Room Room { get; set; }
        public int RoomID { get; set; }
        public virtual Section Section { get; set; }
        public int SectionID { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectID { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }
        public int SchoolYearID { get; set; }
        public string Semester { get; set; }

    }
}
