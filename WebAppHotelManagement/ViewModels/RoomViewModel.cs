using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppHotelManagement.ViewModels
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        [Display(Name ="Номер кімнати")]
        [Required(ErrorMessage = "Номер кімнати обов'язковий.")]
        public string RoomNumber { get; set; }
        [Display(Name = "Зображення номера")]
        public string RoomImage { get; set; }
        [Display(Name = "Ціна номера")]
        [Required(ErrorMessage = "Ціна номера обов'язкова.")]
        [Range(500, 10000, ErrorMessage = "Ціна кімнати повинна бути рівною і більше {1}")]
        public decimal RoomPrice { get; set; }
        [Display(Name = "Статус бронювання")]
        [Required(ErrorMessage = "Статус бронювання обов'язковий.")]
        public int BookingStatusId { get; set; }
        [Display(Name = "Тип номера")]
        [Required(ErrorMessage = "Тип номера обов'язковий.")]
        public int RoomTypeId { get; set; }
        [Display(Name = "Місткість номера")]
        [Required(ErrorMessage = "Місткість номера обов'язкова.")]
        [Range(1,8, ErrorMessage = "Ємність кімнати повинна бути рівною і більше {1}")]
        public int RoomCapacity { get; set; }
        public HttpPostedFileBase Image { get; set; }
        [Display(Name = "Опис номера")]
        [Required(ErrorMessage = "Опис номера обов'язковий.")]
        public string RoomDescription { get; set; }
        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }


    }
}