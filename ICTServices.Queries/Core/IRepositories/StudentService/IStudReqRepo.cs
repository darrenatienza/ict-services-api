
using API.Queries.Core.Domain.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Queries.Core.IRepositories.StudentService
{
    public interface IStudReqRepo : IRepository<StudentReq>
    {
        IEnumerable<StudentReq> GetAll(string criteria);

        StudentReq GetBy(int studentReqID);

        IEnumerable<StudentReq> GetAllBy(bool isAvailable);

        IEnumerable<StudentReq> GetAllByIsPrintReady(bool isPrintReady);
    }
}
