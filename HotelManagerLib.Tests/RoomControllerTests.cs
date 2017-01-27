// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomControllerTests.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room controller tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Tests
{
    using System;
    using System.Linq;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    using NUnit.Framework;

    /// <summary>
    /// The room controller tests.
    /// </summary>
    public class RoomControllerTests
    {
        /// <summary>
        /// The billing.
        /// </summary>
        private Billing billing;

        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingController;

        /// <summary>
        /// The booking.
        /// </summary>
        private Booking booking;

        /// <summary>
        /// The booking entity controller.
        /// </summary>
        private IEntityController<Booking> bookingController;

        /// <summary>
        /// The customer.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// The customer entity controller.
        /// </summary>
        private IEntityController<Customer> customerController;

        /// <summary>
        /// The hotel.
        /// </summary>
        private Hotel hotel;

        /// <summary>
        /// The hotel entity controller.
        /// </summary>
        private IEntityController<Hotel> hotelController;

        /// <summary>
        /// The pricing list entity controller.
        /// </summary>
        private IEntityController<PricingList> pricingListController;

        /// <summary>
        /// The room.
        /// </summary>
        private Room room;

        /// <summary>
        /// The room entity controller.
        /// </summary>
        private IEntityController<Room> roomController;

        /// <summary>
        /// The room type.
        /// </summary>
        private RoomType roomType;

        /// <summary>
        /// The room type entity controller.
        /// </summary>
        private IEntityController<RoomType> roomTypeController;

        /// <summary>
        /// The room type pricing list.
        /// </summary>
        private PricingList roomTypePricingList;

        /// <summary>
        /// The service.
        /// </summary>
        private Service service;

        /// <summary>
        /// The service entity controller.
        /// </summary>
        private IEntityController<Service> serviceController;

        /// <summary>
        /// The pricing list.
        /// </summary>
        private PricingList servicePricingList;

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.hotelController = new HotelController();
            this.bookingController = new BookingController();
            this.customerController = new CustomerController();
            this.serviceController = new ServiceController();
            this.roomTypeController = new RoomTypeController();
            this.roomController = new RoomController();
            this.billingController = new BillingEntityController();
            this.pricingListController = new PricingListController();

            this.hotel = new Hotel()
                             {
                                 Name = "Alex Hotel",
                                 Address = "Syntagma",
                                 TaxId = "AH123456",
                                 Manager = "Alex",
                                 Phone = "2101234567",
                                 Email = "alex@outlook.com"
                             };
            this.hotel = this.hotelController.CreateOrUpdateEntity(this.hotel);

            this.roomType = new RoomType()
                                {
                                    Code = "TreeBed",
                                    View = View.MountainView,
                                    BedType = BedType.ModernCot,
                                    Tv = true,
                                    WiFi = true,
                                    Sauna = true
                                };
            this.roomType = this.roomTypeController.CreateOrUpdateEntity(this.roomType);

            this.room = new Room()
                                {
                                    HotelId = this.hotel.Id,
                                    Code = "Alex Hotel 123",
                                    RoomTypeId = this.roomType.Id
                                };
            this.room = this.roomController.CreateOrUpdateEntity(this.room);

            this.service = new Service()
                               {
                                   HotelId = this.hotel.Id,
                                   Code = "AHBF",
                                   Description = "Breakfast Alex Hotel"
                               };
            this.service = this.serviceController.CreateOrUpdateEntity(this.service);

            this.servicePricingList = new PricingList()
                                          {
                                              BillableEntityId = this.service.Id,
                                              TypeOfBillableEntity = TypeOfBillableEntity.Service,
                                              ValidFrom = DateTime.Now,
                                              ValidTo = Convert.ToDateTime("31/01/2017"),
                                              VatPrc = 13
                                          };
            this.servicePricingList = this.pricingListController.CreateOrUpdateEntity(this.servicePricingList);

            this.roomTypePricingList = new PricingList()
                                           {
                                               BillableEntityId = this.roomType.Id,
                                               TypeOfBillableEntity = TypeOfBillableEntity.RoomType,
                                               ValidFrom = DateTime.Now,
                                               ValidTo = Convert.ToDateTime("31/01/2017").Date,
                                               VatPrc = 13
                                           };
            this.roomTypePricingList = this.pricingListController.CreateOrUpdateEntity(this.roomTypePricingList);

            this.customer = new Customer()
                                {
                                    Name = "Thodoris",
                                    Surname = "Kapiris",
                                    TaxId = "TK1234567",
                                    IdNumber = "AB1234567",
                                    Address = "Monasthraki",
                                    Email = "theo@outlook.com",
                                    Phone = "2107654321"
                                };
            this.customer = this.customerController.CreateOrUpdateEntity(this.customer);

            this.booking = new Booking()
                               {
                                   CustomerId = this.customer.Id,
                                   RoomId = this.room.Id,
                                   From = DateTime.Now,
                                   To = Convert.ToDateTime("31/01/2017"),
                                   SystemPrice = 12,
                                   AgreedPrice = 12,
                                   Status = Status.New,
                                   Comments = "Very good!!"
                               };
            this.booking = this.bookingController.CreateOrUpdateEntity(this.booking);

            this.billing = new Billing()
                               {
                                   BookingId = this.booking.Id,
                                   PriceForRoom = this.booking.AgreedPrice,
                                   PriceForServices = 150,
                                   TotalPrice = 12150,
                                   Paid = true
                               };
            this.billing = this.billingController.CreateOrUpdateEntity(this.billing);
        }

        /// <summary>
        /// The clear hotel.
        /// </summary>
        [TearDown]
        public void ClearHotel()
        {
            this.bookingController.DeleteEntity(this.booking);
            this.customerController.DeleteEntity(this.customer);
            this.pricingListController.DeleteEntity(this.servicePricingList);
            this.pricingListController.DeleteEntity(this.roomTypePricingList);
            this.serviceController.DeleteEntity(this.service);
            this.roomController.DeleteEntity(this.room);
            this.roomTypeController.DeleteEntity(this.roomType);
            this.hotelController.DeleteEntity(this.hotel);
        }

        /// <summary>
        /// The create hotel.
        /// </summary>
        [Test]
        public void CreateRoom()
        {
            var roomTemp = new Room()
                               {
                                   HotelId = this.hotel.Id,
                                   Code = "Super Extra Room",
                                   RoomTypeId = this.roomType.Id
                               };
            roomTemp = this.roomController.CreateOrUpdateEntity(roomTemp);

            Assert.AreEqual(roomTemp.Code, "Super Extra Room");

            this.roomController.DeleteEntity(roomTemp);
        }

        /// <summary>
        /// The delete hotel.
        /// </summary>
        [Test]
        public void DeleteNullRoom()
        {
            var roomTemp = new Room()
            {
                HotelId = this.hotel.Id,
                Code = "Super Extra Room",
                RoomTypeId = this.roomType.Id
            };
            var exp =
                Assert.Throws<ArgumentNullException>(() => this.roomController.DeleteEntity(roomTemp));
            Assert.That(exp.Message, Is.EqualTo("Value cannot be null."));
        }

        /// <summary>
        /// The delete hotel.
        /// </summary>
        [Test]
        public void DeleteRoom()
        {
            var roomTemp = new Room()
                               {
                                   HotelId = this.hotel.Id,
                                   Code = "Super Extra Room",
                                   RoomTypeId = this.roomType.Id
                               };
            roomTemp = this.roomController.CreateOrUpdateEntity(roomTemp);

            var bookingTemp = new Booking()
                                  {
                                      CustomerId = this.customer.Id,
                                      RoomId = roomTemp.Id,
                                      From = DateTime.Now,
                                      To = Convert.ToDateTime("31/01/2017"),
                                      SystemPrice = 12,
                                      AgreedPrice = 12,
                                      Status = Status.New,
                                      Comments = "With pet!!"
                                  };
            this.bookingController.CreateOrUpdateEntity(bookingTemp);

            this.roomController.DeleteEntity(roomTemp);

            Assert.IsEmpty(this.roomController.RefreshEntities().Where(x => x.Code == "Super Extra Room"));
            Assert.IsEmpty(this.bookingController.RefreshEntities().Where(x => x.Comments == "With pet!!"));
        }

        /// <summary>
        /// The get hotel.
        /// </summary>
        [Test]
        public void GetRoom()
        {
            var roomTemp = new Room()
            {
                HotelId = this.hotel.Id,
                Code = "Super Extra Room",
                RoomTypeId = this.roomType.Id
            };
            roomTemp = this.roomController.CreateOrUpdateEntity(roomTemp);

            var bookingTemp = new Booking()
            {
                CustomerId = this.customer.Id,
                RoomId = roomTemp.Id,
                From = DateTime.Now,
                To = Convert.ToDateTime("31/01/2017"),
                SystemPrice = 12,
                AgreedPrice = 12,
                Status = Status.New,
                Comments = "With pet!!"
            };
            bookingTemp = this.bookingController.CreateOrUpdateEntity(bookingTemp);
            var bookingForCheck = this.bookingController.GetEntity(bookingTemp.Id);

            var roomTemp2 = this.roomController.RefreshEntities().SingleOrDefault(x => x.Code == "Super Extra Room");
            var roomForCheck = this.roomController.GetEntity(roomTemp2.Id);

            Assert.AreEqual(roomForCheck.Code, "Super Extra Room");
            Assert.AreEqual(roomForCheck.HotelId, this.hotel.Id);
            Assert.AreEqual(roomForCheck.RoomTypeId, this.roomType.Id);
            Assert.AreEqual(bookingForCheck.Room.Code, "Super Extra Room");
            Assert.AreEqual(bookingForCheck.Room.HotelId, this.hotel.Id);
            Assert.AreEqual(bookingForCheck.Room.RoomTypeId, this.roomType.Id);
            this.roomController.DeleteEntity(roomForCheck);
        }

        /// <summary>
        /// The refresh hotels.
        /// </summary>
        [Test]
        public void RefreshRooms()
        {
            Assert.IsNotEmpty(this.hotelController.RefreshEntities());
        }

        /// <summary>
        /// The update hotel.
        /// </summary>
        [Test]
        public void UpdateHotel()
        {
            this.room.Code = "new room code";

            this.room = this.roomController.CreateOrUpdateEntity(this.room);

            Assert.AreEqual(this.room.Code, "new room code");
        }
    }
}