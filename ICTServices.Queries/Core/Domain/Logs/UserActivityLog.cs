using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Logs
{
    [Table("Logs.UserActivityLogs")]
    public class UserActivityLog
    {
        public UserActivityLog() { }
        public int UserActivityLogID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public Guid? UserGUID { get; set; }
        public Guid? RecordGUID { get; set; }


    }
}
