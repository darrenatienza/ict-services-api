using API.Jwt.Filters;
using API.Jwt.Models.Person;
using API.Queries.Core.Domain.Person;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Jwt.Controllers.Person.v1
{
    [JwtAuthentication]
    public class StudentsController : ApiController
    {
        // GET api/student
        [HttpGet]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public async Task<IHttpActionResult> Get(string criteria)
        {
            try
            {
                criteria = criteria == null ? "" : criteria;
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.Students.GetAll(criteria));
                    List<StudentModel> models = new List<StudentModel>();
                    foreach (var item in objs)
                    {
                        StudentModel model = new StudentModel();
                        model.StudentID = item.StudentID;
                        model.SrCode = item.SrCode;
                        model.FirstName = item.FirstName;
                        model.MiddleName = item.MiddleName;
                        model.LastName = item.LastName;
                        model.CollegeID = item.CollegeID;
                        model.CollegeCode = item.College.Code;
                        model.CollegeDescription = item.College.Description;
                        model.CourseID = item.CourseID;
                        model.CourseCode = item.Course.Code;
                        model.CourseDescription = item.Course.Description;
                        model.MajorID = item.MajorID;
                        model.MajorCode = item.Major.Code;
                        model.MajorDescription = item.Major.Description;
                        model.YearLevel = item.YearLevel;
                        models.Add(model);
                    }
                    return Ok(models);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public IHttpActionResult GetStudent(string srCode)
        {
            try
            {

                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.Students.GetBySrCode(srCode);
                    StudentModel model = new StudentModel();
                    if (obj != null)
                    {
                        model.StudentID = obj.StudentID;
                        model.SrCode = obj.SrCode;
                        model.FirstName = obj.FirstName;
                        model.MiddleName = obj.MiddleName;
                        model.LastName = obj.LastName;
                        model.CollegeID = obj.CollegeID;
                        model.CourseID = obj.CourseID;
                        model.MajorID = obj.MajorID;
                        model.YearLevel = obj.YearLevel;
                    }
                    

                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        
        // GET api/student/5
        [HttpGet]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public IHttpActionResult Get(int studentID)
        {
            try
            {

                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.Students.Get(studentID);
                    StudentModel model = new StudentModel();
                    model.StudentID = obj.StudentID;
                    model.SrCode = obj.SrCode;
                    model.FirstName = obj.FirstName;
                    model.MiddleName = obj.MiddleName;
                    model.LastName = obj.LastName;
                    model.CollegeID = obj.CollegeID;
                    model.CourseID = obj.CourseID;
                    model.MajorID = obj.MajorID;
                    model.YearLevel = obj.YearLevel;

                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public IHttpActionResult Post(StudentModel model)
        {
            try
            {

                using (var uow = new UnitOfWork(new DataContext()))
                {


                    Student obj = new Student();
                    
                    obj.SrCode = model.SrCode;
                    obj.FirstName = model.FirstName;
                    obj.MiddleName = model.MiddleName;
                    obj.LastName = model.LastName;
                    obj.CollegeID = model.CollegeID;
                    obj.CourseID = model.CourseID;
                    obj.MajorID = model.MajorID;
                    obj.YearLevel = model.YearLevel;
                    uow.Students.Add(obj);
                    uow.Complete();
                    return Ok(obj.StudentID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // PUT api/student/5
        [HttpPut]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public IHttpActionResult Put(int studentID, StudentModel model)
        {
            try
            {

                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.Students.Get(studentID);
                    obj.SrCode = model.SrCode;
                    obj.FirstName = model.FirstName;
                    obj.MiddleName = model.MiddleName;
                    obj.LastName = model.LastName;
                    obj.CollegeID = model.CollegeID;
                    obj.CourseID = model.CourseID;
                    obj.MajorID = model.MajorID;
                    obj.YearLevel = model.YearLevel;
                    uow.Students.Edit(obj);
                    uow.Complete();
                    return Ok(obj.StudentID);

                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        
        }

        // DELETE api/student/5
        [HttpDelete]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public IHttpActionResult Delete(int studentID)
        {
            try
            {

                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.Students.Get(studentID);
                   
                    uow.Students.Remove(obj);
                    uow.Complete();
                    return Ok(true);

                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
