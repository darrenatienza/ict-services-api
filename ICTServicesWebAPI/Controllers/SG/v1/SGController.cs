using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Jwt.Models.SG;
using SG = System.Web.Http.Cors;
using API.Jwt.Filters;
using API.Queries.Core.Domain.SG;

namespace API.Jwt.Controllers.SG.v1
{
    public class SGController : ApiController
    {
        [Authorize(Roles= SysRole.Admin_SSO_LIB)]
        [HttpGet]
        [JwtAuthentication]
        public IHttpActionResult GetLastReport(bool isGetLastReport)
        {
            try
            {
                if (isGetLastReport)
                {
                    using (var uow = new UnitOfWork(new DataContext()))
                    {
                        var report = uow.SGReports.GetLast();
                        if (report != null)
                        {
                            ReportModel model = new ReportModel();
                            model.Acts = report.Acts;
                            model.Personnel = report.Personnel;
                            model.Rmks = report.Rmks;
                            return Ok(model);
                        }
                        else
                        {
                            return Content(HttpStatusCode.NotFound, "No Last Record found!");
                        }
                        
                    }
                }
                else
                {
                    return Content(HttpStatusCode.NotImplemented, "Method Not Implemented!");
                }
               
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Get All Reports
        /// </summary>
        /// <param name="value">eg /api/value?value="value"</param>
        /// <returns></returns>
        [Authorize(Roles = SysRole.Admin_SSO_LIB)]
        [HttpGet]
        [JwtAuthentication]
        public IHttpActionResult GetAllReports(DateTime dateFrom, DateTime dateTo)
        {
            using (var uow = new UnitOfWork(new DataContext()))
            {
                var rpts = uow.SGReports.GetAllReports(dateFrom,dateTo);
                List<ReportModel> models = new List<ReportModel>();
                foreach (var item in rpts)
                {
                    ReportModel model = new ReportModel();
                    model.Date = item.Date;
                    model.ReportID = item.ReportID;
                    model.Acts = item.Acts;
                    model.Desc = item.Desc;
                    model.Personnel = item.Personnel;
                    model.Rmks = item.Rmks;
                    models.Add(model);
                }
                return Ok(models);
            }

        }

        [Authorize(Roles = SysRole.Admin_SSO_LIB)]
        [HttpPost]
        [JwtAuthentication]
        public IHttpActionResult AddNewReport(ReportModel model)
        {
            using (var uow = new UnitOfWork(new DataContext()))
            {
                var report = new Report();
                report.Date = model.Date;
                report.Desc = model.Desc;
                report.Personnel = model.Personnel;
                report.Rmks = model.Rmks;
                report.Acts = model.Acts;
                uow.SGReports.Add(report);
                uow.Complete();
                return Ok(report.ReportID);
            }

        }

        [Authorize(Roles = SysRole.Admin_SSO_LIB)]
        [HttpGet]
        [JwtAuthentication]
        public IHttpActionResult GetReportDetail(int reportID)
        {
            using (var uow = new UnitOfWork(new DataContext()))
            {
                var obj = uow.SGReports.Get(reportID);
                ReportModel model = new ReportModel();
                model.Date = obj.Date;
                model.ReportID = obj.ReportID;
                model.Acts = obj.Acts;
                model.Desc = obj.Desc;
                model.Personnel = obj.Personnel;
                model.Rmks = obj.Rmks;
                return Ok(obj);
            }

        }
        [Authorize(Roles = SysRole.Admin_SSO_LIB)]
        [HttpPut]
        [JwtAuthentication]
        public IHttpActionResult UpdateReport(int reportID, ReportModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var report = uow.SGReports.Get(reportID);
                    report.Date = model.Date;
                    report.Desc = model.Desc;
                    report.Personnel = model.Personnel;
                    report.Rmks = model.Rmks;
                    report.Acts = model.Acts;
                    uow.SGReports.Edit(report);
                    uow.Complete();
                    return Ok(report.ReportID);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            

        }
        [Authorize(Roles = SysRole.Admin_SSO_LIB)]
        [HttpDelete]
        [JwtAuthentication]
        public IHttpActionResult DeleteReport(int reportID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var report = uow.SGReports.Get(reportID);
                    uow.SGReports.Remove(report);
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
