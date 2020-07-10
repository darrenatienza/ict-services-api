using API.Jwt.Filters;
using API.Jwt.Models.StudentService;
using API.Queries.Core.Domain.StudentService;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Jwt.Controllers.StudentServices.v1
{
    [JwtAuthentication]
    public class StudentReqsController : ApiController
    {
        // GET api/studreq
        [HttpGet]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public async Task<IHttpActionResult> GetAll(string criteria)
        {
            try
            {
                criteria = criteria == null ? "" : criteria;
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.StudReqs.GetAll(criteria));
                    List<StudentReqModel> models = new List<StudentReqModel>();
                    foreach (var item in objs)
                    {
                        StudentReqModel model = new StudentReqModel();
                        model.StudentReqID = item.StudentReqID;
                        model.CreateDate = item.CreateDate;
                        model.StudentSrCode = item.Student.SrCode;
                        model.StudentFullName = string.Format("{0} {1}", item.Student.FirstName, item.Student.LastName);
                        model.StudentReqTypeDescription = item.StudentReqType.Description;
                        model.SchoolYearDescription = item.SchoolYear.Description;
                        model.IsClaimed = item.IsClaimed;
                        model.IsPrintReady = item.isPrintReady;
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
        public async Task<IHttpActionResult> GetCount(bool isGetCount)
        {
            try
            {
                if (isGetCount)
                {
                    using (var uow = new UnitOfWork(new DataContext()))
                    {
                        var objs = await Task.Run(() => uow.StudReqs.GetAll());
                        return Ok(objs.Count());
                    }
                }
                else
                {
                    return Ok(0);
                }
                
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public async Task<IHttpActionResult> GetAllByIsPrintReady(bool isPrintReady)
        {
            try
            {

                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.StudReqs.GetAllByIsPrintReady(isPrintReady));
                    List<StudentReqModel> models = new List<StudentReqModel>();
                    foreach (var item in objs)
                    {
                        StudentReqModel model = new StudentReqModel();
                        model.StudentReqID = item.StudentReqID;
                        model.CreateDate = item.CreateDate;
                        model.StudentSrCode = item.Student.SrCode;
                        model.StudentFullName = string.Format("{0} {1}", item.Student.FirstName, item.Student.LastName);
                        model.StudentReqTypeDescription = item.StudentReqType.Description;
                        model.SchoolYearDescription = item.SchoolYear.Description;
                        model.ReceiptNum = item.ReceiptNum;
                        model.IsClaimed = item.IsClaimed;
                        model.Reason = item.Reason;
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
        public async Task<IHttpActionResult> GetAll(bool isAvailable)
        {
            try
            {
                
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.StudReqs.GetAllBy(isAvailable));
                    List<StudentReqModel> models = new List<StudentReqModel>();
                    foreach (var item in objs)
                    {
                        StudentReqModel model = new StudentReqModel();
                        model.StudentReqID = item.StudentReqID;
                        model.CreateDate = item.CreateDate;
                        model.StudentSrCode = item.Student.SrCode;
                        model.StudentFullName = string.Format("{0} {1}", item.Student.FirstName, item.Student.LastName);
                        model.StudentReqTypeDescription = item.StudentReqType.Description;
                        model.SchoolYearDescription = item.SchoolYear.Description;
                        model.IsClaimed = item.IsClaimed;
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
        public IHttpActionResult Get(int studentReqID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    StudentReqModel model = new StudentReqModel();
                    StudentReq obj = uow.StudReqs.GetBy(studentReqID);
                    model.StudentReqID = obj.StudentReqID;
                    model.StudentSrCode = obj.Student.SrCode;
                    model.ClaimedDate = obj.ClaimedDate;
                    model.CreateDate = obj.CreateDate;
                    model.IsAvailable = obj.IsAvailable;
                    model.IsClaimed = obj.IsClaimed;
                    model.LocationID = obj.LocationID;
                    model.Reason = obj.Reason;
                    model.ReceiptNum = obj.ReceiptNum;
                    model.Remarks = obj.Remarks;
                    model.SchoolYearID = obj.SchoolYearID;
                    model.Semester = obj.Semester;
                    model.StudentID = obj.StudentID;
                    model.StudentReqTypeID = obj.StudentReqTypeID;

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
        public async Task<IHttpActionResult> Post(StudentReqModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    StudentReq obj = new StudentReq();
                    obj.ClaimedDate = model.ClaimedDate;
                    obj.CreateDate = model.CreateDate;
                    obj.IsAvailable = model.IsAvailable;
                    obj.IsClaimed = model.IsClaimed;
                    obj.LocationID = model.LocationID;
                    obj.Reason = model.Reason;
                    obj.ReceiptNum = model.ReceiptNum;
                    obj.Remarks = model.Remarks;
                    obj.SchoolYearID = model.SchoolYearID;
                    obj.Semester = model.Semester;
                    obj.StudentID = model.StudentID;
                    obj.StudentReqTypeID = model.StudentReqTypeID;
                    await Task.Run(() => uow.StudReqs.Add(obj));
                    uow.Complete();
                    return Ok(obj.StudentReqID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public async Task<IHttpActionResult> Put(int studentReqID, StudentReqModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    StudentReq obj = uow.StudReqs.Get(studentReqID);
                    obj.ClaimedDate = model.ClaimedDate;
                    obj.CreateDate = model.CreateDate;
                    obj.IsAvailable = model.IsAvailable;
                    obj.IsClaimed = model.IsClaimed;
                    obj.LocationID = model.LocationID;
                    obj.Reason = model.Reason;
                    obj.ReceiptNum = model.ReceiptNum;
                    obj.Remarks = model.Remarks;
                    obj.SchoolYearID = model.SchoolYearID;
                    obj.Semester = model.Semester;
                    obj.StudentID = model.StudentID;
                    obj.StudentReqTypeID = model.StudentReqTypeID;
                    await Task.Run(() => uow.StudReqs.Edit(obj));
                    uow.Complete();
                    return Ok(obj.StudentReqID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpPut]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public async Task<IHttpActionResult> Put(int studentReqID, bool printReadyStatus)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    StudentReq obj = uow.StudReqs.Get(studentReqID);
                    obj.isPrintReady = printReadyStatus;
                    await Task.Run(() => uow.StudReqs.Edit(obj));
                    uow.Complete();
                    return Ok(obj.StudentReqID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        [Authorize(Roles = SysRole.Admin_SOAHead)]
        public IHttpActionResult Delete(int studentReqID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    StudentReq obj = uow.StudReqs.Get(studentReqID);
                    uow.StudReqs.Remove(obj);
                    uow.Complete();
                    return Ok(obj.StudentReqID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
