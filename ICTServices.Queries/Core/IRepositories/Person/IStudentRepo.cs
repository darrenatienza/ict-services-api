
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Queries.Core.Domain.Person;

namespace API.Queries.Core.IRepositories.Person
{
    public interface IStudentRepo : IRepository<Student>
    {
        IEnumerable<Student> GetAll(string criteria);

        Student GetBySrCode(string srCode);
    }
}
