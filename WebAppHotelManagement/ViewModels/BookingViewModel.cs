using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHotelManagement.ViewModels
{
    public class BookingViewModel
    {
        [Display(Name = "Ім'я клієнта")]
        [Required(ErrorMessage = "Ім'я клієнта обов'язкове.")]
        public string CustomerName { get; set; }
        [Display(Name = "Адреса клієнта")]
        [Required(ErrorMessage = "Адреса клієнта обов'язкова.")]
        public string CustomerAdress { get; set; }
        [Display(Name = "Номер телефону клієнта")]
        [Required(ErrorMessage = "Номер телефону клієнта обов'язковий.")]
        public string CustomerPhone { get; set; }
        [Display(Name = "Бронювання з")]
        [Required(ErrorMessage = "Дата початку бронювання обов'язкова.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingFrom { get; set; }
        [Display(Name = "Бронювання до")]
        [Required(ErrorMessage = "Дата кінця обов'язкова.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingTo { get; set; }
        [Display(Name = "Кiмната для бронювання")]
        public int AssignRoomId { get; set; }
        [Display(Name = "Кількість проживаючих")]
        public int NumberOfMembers { get; set; }
        public IEnumerable<SelectListItem> ListOfRooms { get; set; }

    }
}