using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppHotelManagement.ViewModels
{
    public class RoomBookingViewModel
    {

        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfMembers { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerPhone { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public decimal RoomPrice { get; set; }
        public DateTime BookingFrom { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingTo { get; set; }
        public string RoomNumber { get; set; }
        public decimal TotalAmount { get; set; }

        public int NumberOfDays { get; set; }
    }
}