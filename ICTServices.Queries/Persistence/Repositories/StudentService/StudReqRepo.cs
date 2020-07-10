
using API.Queries.Core.Domain.StudentService;
using API.Queries.Core.IRepositories.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace API.Queries.Persistence.Repositories.StudentService
{
    public class StudReqRepo : Repository<StudentReq>, IStudReqRepo
    {

        public StudReqRepo(DataContext _context)
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

        public IEnumerable<StudentReq> GetAll(string criteria)
        {
            return DataContext.StudReqs.Include(rec => rec.Student).Include(rec => rec.StudentReqType).Include(rec => rec.SchoolYear).Where(rec => rec.Student.SrCode.Contains(criteria) || (rec.Student.FirstName.Contains(criteria) || rec.Student.LastName.Contains(criteria)));
        }


        public StudentReq GetBy(int studentReqID)
        {
            return DataContext.StudReqs.Include(rec => rec.Student).FirstOrDefault(rec => rec.StudentReqID == studentReqID);
        }


        public IEnumerable<StudentReq> GetAllBy(bool isAvailable)
        {
            return DataContext.StudReqs.Include(rec => rec.Student).Include(rec => rec.StudentReqType).Include(rec => rec.SchoolYear).Where(rec => rec.IsAvailable == isAvailable);
        }


        public IEnumerable<StudentReq> GetAllByIsPrintReady(bool isPrintReady)
        {
            return DataContext.StudReqs.Include(rec => rec.Student).Include(rec => rec.StudentReqType).Include(rec => rec.SchoolYear).Where(rec => rec.isPrintReady == isPrintReady);
        }
    }
}
