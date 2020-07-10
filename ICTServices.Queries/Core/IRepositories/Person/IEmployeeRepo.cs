
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Queries.Core.Domain.Person;

namespace API.Queries.Core.IRepositories.Person
{
    public interface IEmployeeRepo : IRepository<Employee>
    {

        IEnumerable<Employee> GetAll(string criteria);
    }
}
