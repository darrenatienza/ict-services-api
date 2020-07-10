using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Logs
{
    [Table("Logs.SystemLogs")]
    public class SystemLog
    {
        public SystemLog() { }
        public int SystemLogID { get; set; }
        public string Level { get; set; }
        public string Timestamp { get; set; }
        public string FileName { get; set; }
        public string LineNumber { get; set; }
        public string Message { get; set; }
    }
    
}
