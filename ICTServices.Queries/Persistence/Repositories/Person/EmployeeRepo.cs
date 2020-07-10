using API.Queries.Core.Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Queries.Core.IRepositories.Person;
namespace API.Queries.Persistence.Repositories.Person
{
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {

        public EmployeeRepo(DataContext _context)
            : base(_context)
        {
        }
        public DataContext DataContext
        {
            get
            {
                return Context as DataContext;
            }
        }

        public IEnumerable<Employee> GetAll(string criteria)
        {
            return DataContext.Employees.Include(r => r.College).Include(r => r.Office).Where(r => r.EmployeeCode.Contains(criteria));
        }
    }
       
}
