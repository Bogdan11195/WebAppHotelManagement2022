﻿        using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHotelManagement.Models;
using WebAppHotelManagement.ViewModels;

namespace WebAppHotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private HotelDBEntities objHotelDbEntities;

        public BookingController()
        {
            objHotelDbEntities = new HotelDBEntities();
        }

        public ActionResult Index()
        {
            BookingViewModel objBookingViewModel = new BookingViewModel();
            objBookingViewModel.ListOfRooms = (from objRoom in objHotelDbEntities.Rooms
                                               where objRoom.BookingStatusId == 2
                                               select new SelectListItem()
                                               {
                                                   Text = objRoom.RoomNumber,
                                                   Value = objRoom.RoomId.ToString()
                                               }
                                             ).ToList();
            objBookingViewModel.BookingFrom = DateTime.Now;
            objBookingViewModel.BookingTo = DateTime.Now.AddDays(1);
            return View(objBookingViewModel);
        }

        [HttpPost]
        public ActionResult Index(BookingViewModel objBookingViewModel  )
        {
            int numberOfDays = Convert.ToInt32((objBookingViewModel.BookingTo - objBookingViewModel.BookingFrom).TotalDays);
            Room objRoom = objHotelDbEntities.Rooms.Single(model => model.RoomId == objBookingViewModel.AssignRoomId);
            decimal RoomPrice = objRoom.RoomPrice;
            decimal TotalAmount = RoomPrice * numberOfDays;

            RoomBooking roomBooking = new RoomBooking()
            {
                BookingFrom = objBookingViewModel.BookingFrom,
                BookingTo = objBookingViewModel.BookingTo,
                AssignRoomId = objBookingViewModel.AssignRoomId,
                CustomerAddress = objBookingViewModel.CustomerAdress,
                CustomerName = objBookingViewModel.CustomerName,
                CustomerPhone = objBookingViewModel.CustomerPhone,
                NoOfMembers = objBookingViewModel.NumberOfMembers,
                TotalAmount = TotalAmount
            };
            objHotelDbEntities.RoomBookings.Add(roomBooking);
            objHotelDbEntities.SaveChanges();

            objRoom.BookingStatusId = 3;
            objHotelDbEntities.SaveChanges();
            return Json(new { message = "Бронювання готелів успішно створено.", success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult GetAllBookingHistory()
        {
            List<RoomBookingViewModel> listOfBookingViewModels = new List<RoomBookingViewModel>();
            listOfBookingViewModels = (from objHotelBooking in objHotelDbEntities.RoomBookings
                                       join objRoom in objHotelDbEntities.Rooms on objHotelBooking.AssignRoomId equals objRoom.RoomId
                                       select new RoomBookingViewModel() {
                                           BookingFrom = objHotelBooking.BookingFrom,
                                           BookingTo = objHotelBooking.BookingTo,
                                           CustomerPhone = objHotelBooking.CustomerPhone,
                                           CustomerName = objHotelBooking.CustomerName,
                                           TotalAmount = objHotelBooking.TotalAmount,
                                           CustomerAdress = objHotelBooking.CustomerAddress,
                                           NumberOfMembers = objHotelBooking.NoOfMembers,
                                           BookingId = objHotelBooking.BookingId,
                                           RoomNumber = objRoom.RoomNumber,
                                           RoomPrice = objRoom.RoomPrice,
                                           NumberOfDays = System.Data.Entity.DbFunctions.DiffDays(objHotelBooking.BookingFrom, objHotelBooking.BookingTo).Value 
                                           
                                       }).ToList();
            return PartialView("_BookingHistoryPartial", listOfBookingViewModels);
        }     

    }
}