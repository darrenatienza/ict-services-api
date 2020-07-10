using API.Jwt.Models.ERBS;
using API.Queries.Core.Domain.ERBS;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Jwt.Helpers;
namespace API.Jwt.Controllers.ERBS.v1
{
    public class ReservationsController : ApiController
    {
        [AllowAnonymous]
        // GET api/reservations
        public IHttpActionResult Get()
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                   
                    var reservations = uow.Reservations.GetAllReservations();
                    List<ReservationListDTO> models = new List<ReservationListDTO>();
                    foreach (var item in reservations)
                    {
                        var model = new ReservationListDTO();
                        model.EmployeeName = item.Employee.FirstName;
                        model.ItemDescription = item.Item.Code;
                        model.ReservationDateFrom = item.DateTimeFrom.ToString();
                        model.ReservationDateTo = item.DateTimeTo.ToString();
                        model.ReservationID = item.ReservationID;
                        var venueStrings = "";
                        item.Venues.ToList().ForEach(r => 
                        {
                            
                            venueStrings = "[" + r.Description + "] " + venueStrings; 
                        });
                        model.Venues = venueStrings.Trim();
                        models.Add(model);
                    }
                    return Ok(models);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        [AllowAnonymous]
        // GET api/reservations/5
        public IHttpActionResult Get(int reservationID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.Reservations.GetByReservationID(reservationID);
                    var model = new ReservationDetailDTO();
                    model.EmployeeID = obj.EmployeeID;
                    model.ItemID = obj.ItemID;
                    if (obj.BorrowedDate.HasValue)
                    {
                        model.BorrowedDate = obj.BorrowedDate.Value;
                    }
                    model.CreateTimeStamp = obj.CreateTimeStamp;
                    model.DateTimeFrom = obj.DateTimeFrom;
                    model.DateTimeTo = obj.DateTimeTo;
                    model.EmployeeID = obj.EmployeeID;
                    model.ItemID = obj.ItemID;
                    if (obj.ReturnedDate.HasValue)
                    {
                        model.ReturnedDate = obj.ReturnedDate.Value;
                    }
                    obj.Venues.ToList().ForEach(r =>
                    {
                        model.Venues.Add(new VenueDetailDTO()
                        {
                            VenueID = r.VenueID, 
                            Description = r.Description
                        });
                    });
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST api/reservations
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Post(AddReservationDTO model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = new Reservation();
                    obj.EmployeeID = model.EmployeeID;
                    obj.ItemID = model.ItemID;
                    obj.BorrowedDate = model.BorrowedDate;
                    obj.CreateTimeStamp = model.CreateTimeStamp;
                    obj.DateTimeFrom = model.DateTimeFrom;
                    obj.DateTimeTo = model.DateTimeTo;
                    obj.EmployeeID = model.EmployeeID;
                    obj.ItemID = obj.ItemID;

                    obj.ReturnedDate = model.ReturnedDate;

                    model.Venues.ToList().ForEach(r =>
                    {
                        var v = uow.Venues.Get(r);
                        if (v != null)
                        {
                            obj.Venues.Add(v);
                        }
                        
                    });
                    uow.Reservations.Add(obj);
                    uow.Complete();
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT api/reservations/5
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult Put(int id, EditReservationDTO model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.Reservations.GetByReservationID(id);

                    obj.EmployeeID = model.EmployeeID;
                    obj.ItemID = model.ItemID;
                    obj.BorrowedDate = model.BorrowedDate;
                    obj.CreateTimeStamp = model.CreateTimeStamp;
                    obj.DateTimeFrom = model.DateTimeFrom;
                    obj.DateTimeTo = model.DateTimeTo;
                    obj.EmployeeID = model.EmployeeID;
                    obj.ItemID = obj.ItemID;
                    obj.ReturnedDate = model.ReturnedDate;
                    obj.Venues.Clear();
                    model.Venues.ToList().ForEach(r =>
                    {
                        var v = uow.Venues.Get(r);
                        if (v != null)
                        {
                            obj.Venues.Add(v);
                        }
                       

                    });
                    uow.Reservations.Edit(obj);
                    uow.Complete();
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE api/reservations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var obj = uow.Reservations.Get(id);
                    uow.Reservations.Remove(obj);
                    uow.Complete();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
