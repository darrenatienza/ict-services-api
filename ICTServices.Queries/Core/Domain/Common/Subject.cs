using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    [Table("Common.Subjects")]
    public class Subject
    {
        public Subject() { }

        public int SubjectId { get; set; }
        public string Name { get; set; }
    }
}
