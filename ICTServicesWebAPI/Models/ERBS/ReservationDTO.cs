using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.ERBS
{
    public class ReservationListDTO
    {
        public ReservationListDTO() { }
        public int ReservationID { get; set; }
        public string ItemDescription { get; set; }
        public string ReservationDateFrom { get; set; }
        public string ReservationDateTo { get; set; }
        public string EmployeeName { get; set; }
        public string Venues { get; set; }
    }
    public class ReservationDetailDTO
    {
        public ReservationDetailDTO() { Venues = new List<VenueDetailDTO>(); }
        public DateTime CreateTimeStamp { get; set; }
        public int ItemID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public List<VenueDetailDTO> Venues { get; set; }
    }
    public class AddReservationDTO
    {
        public AddReservationDTO() { }
        public DateTime CreateTimeStamp { get; set; }
        public int ItemID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public List<int> Venues { get; set; }
    }
    public class EditReservationDTO
    {
        public EditReservationDTO() { }
        public int ReservationID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public int ItemID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public List<int> Venues { get; set; }
    }
}