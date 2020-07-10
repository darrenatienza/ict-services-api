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
    public class StudentRepo : Repository<Student>, IStudentRepo
    {

        public StudentRepo(DataContext _context)
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

        public IEnumerable<Student> GetAll(string criteria)
        {
            return DataContext.Students.Include(rec => rec.College)
                .Include(rec => rec.Course).Include(rec => rec.Major)
                .Where(rec => rec.SrCode.Contains(criteria) || (rec.FirstName.Contains(criteria) || rec.LastName.Contains(criteria)));
        }


        public Student GetBySrCode(string srCode)
        {
            return DataContext.Students.Include(rec => rec.College)
               .Include(rec => rec.Course).Include(rec => rec.Major)
               .FirstOrDefault(rec => rec.SrCode == srCode);
        }
    }
}
