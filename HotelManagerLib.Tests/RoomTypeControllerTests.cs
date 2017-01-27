// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomTypeControllerTests.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room type controller tests.
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
    /// The room type controller tests.
    /// </summary>
    public class RoomTypeControllerTests
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
        public void ClearRoomType()
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
        public void CreateRoomType()
        {
            var roomTypeTemp = new RoomType()
            {
                Code = "Bungallows",
                View = View.MountainView,
                BedType = BedType.ModernCot,
                Tv = true,
                WiFi = true,
                Sauna = true
            };
            roomTypeTemp = this.roomTypeController.CreateOrUpdateEntity(roomTypeTemp);

            Assert.AreEqual(roomTypeTemp.Code, "Bungallows");
            Assert.AreEqual(roomTypeTemp.View, View.MountainView);
            Assert.AreEqual(roomTypeTemp.BedType, BedType.ModernCot);
            Assert.AreEqual(roomTypeTemp.Tv, true);
            Assert.AreEqual(roomTypeTemp.WiFi, true);
            Assert.AreEqual(roomTypeTemp.Sauna, true);

            this.roomTypeController.DeleteEntity(roomTypeTemp);
        }

        /// <summary>
        /// The delete hotel.
        /// </summary>
        [Test]
        public void DeleteNullRoomType()
        {
            var roomTypeTemp = new RoomType()
            {
                Code = "Bungallows",
                View = View.MountainView,
                BedType = BedType.ModernCot,
                Tv = true,
                WiFi = true,
                Sauna = true
            };
            var exp =
                Assert.Throws<ArgumentNullException>(() => this.roomTypeController.DeleteEntity(roomTypeTemp));
            Assert.That(exp.Message, Is.EqualTo("Value cannot be null."));
        }

        /// <summary>
        /// The delete room type.
        /// </summary>
        [Test]
        public void DeleteRoomType()
        {
            var roomTypeTemp = new RoomType()
            {
                Code = "Bungallows",
                View = View.MountainView,
                BedType = BedType.ModernCot,
                Tv = true,
                WiFi = true,
                Sauna = true
            };
            roomTypeTemp = this.roomTypeController.CreateOrUpdateEntity(roomTypeTemp);

            var roomTemp = new Room()
            {
                HotelId = this.hotel.Id,
                Code = "Super Extra Room",
                RoomTypeId = roomTypeTemp.Id
            };
            this.roomController.CreateOrUpdateEntity(roomTemp);

            var roomTypePricingListTemp = new PricingList()
            {
                BillableEntityId = roomTypeTemp.Id,
                TypeOfBillableEntity = TypeOfBillableEntity.RoomType,
                ValidFrom = DateTime.Now,
                ValidTo = Convert.ToDateTime("31/01/2017").Date,
                Price = 100,
                VatPrc = 13
            };
            this.pricingListController.CreateOrUpdateEntity(roomTypePricingListTemp);

            this.roomTypeController.DeleteEntity(roomTypeTemp);

            Assert.IsEmpty(this.roomTypeController.RefreshEntities().Where(x => x.Code == "Bungallows"));
            Assert.IsEmpty(this.roomController.RefreshEntities().Where(x => x.Code == "Super Extra Room"));
            Assert.IsEmpty(this.pricingListController.RefreshEntities().Where(x => x.BillableEntityId == roomTypeTemp.Id && x.TypeOfBillableEntity == TypeOfBillableEntity.RoomType));
        }

        /// <summary>
        /// The get hotel.
        /// </summary>
        [Test]
        public void GetRoomType()
        {
            var roomTypeTemp = new RoomType()
                                   {
                                       Code = "Bungallows",
                                       View = View.MountainView,
                                       BedType = BedType.ModernCot,
                                       Tv = true,
                                       WiFi = true,
                                       Sauna = true
                                   };
            roomTypeTemp = this.roomTypeController.CreateOrUpdateEntity(roomTypeTemp);

            var roomTemp = new Room()
                               {
                                   HotelId = this.hotel.Id,
                                   Code = "Super Extra Room",
                                   RoomTypeId = roomTypeTemp.Id
                               };
            roomTemp = this.roomController.CreateOrUpdateEntity(roomTemp);

            var roomTypePricingListTemp = new PricingList()
                                              {
                                                  BillableEntityId = roomTypeTemp.Id,
                                                  TypeOfBillableEntity = TypeOfBillableEntity.RoomType,
                                                  ValidFrom = DateTime.Now,
                                                  ValidTo = Convert.ToDateTime("31/01/2017").Date,
                                                  Price = 100,
                                                  VatPrc = 13
                                              };
            roomTypePricingListTemp = this.pricingListController.CreateOrUpdateEntity(roomTypePricingListTemp);

            var roomTypeTemp2 = this.roomTypeController.RefreshEntities().SingleOrDefault(x => x.Code == "Bungallows");
            if (roomTypeTemp2 != null)
            {
                var roomTypeForCheck = this.roomTypeController.GetEntity(roomTypeTemp2.Id);

                var roomForCheck = this.roomController.GetEntity(roomTemp.Id);
                var roomTypePricingListForCheck = this.pricingListController.GetEntity(roomTypePricingListTemp.Id);

                Assert.AreEqual(roomTypeForCheck.Code, "Bungallows");
                Assert.AreEqual(roomTypeForCheck.View, View.MountainView);
                Assert.AreEqual(roomTypeForCheck.BedType, BedType.ModernCot);
                Assert.AreEqual(roomTypeForCheck.Tv, true);
                Assert.AreEqual(roomTypeForCheck.WiFi, true);
                Assert.AreEqual(roomTypeForCheck.Sauna, true);

                Assert.AreEqual(roomForCheck.RoomType.Code, "Bungallows");
                Assert.AreEqual(roomForCheck.RoomType.View, View.MountainView);
                Assert.AreEqual(roomForCheck.RoomType.BedType, BedType.ModernCot);
                Assert.AreEqual(roomForCheck.RoomType.Tv, true);
                Assert.AreEqual(roomForCheck.RoomType.WiFi, true);
                Assert.AreEqual(roomForCheck.RoomType.Sauna, true);

                Assert.AreEqual(roomTypePricingListForCheck.BillableEntityId, roomTypeForCheck.Id);

                this.pricingListController.DeleteEntity(roomTypePricingListForCheck);
                this.roomController.DeleteEntity(roomForCheck);
                this.roomTypeController.DeleteEntity(roomTypeForCheck);
            }
        }

        /// <summary>
        /// The refresh hotels.
        /// </summary>
        [Test]
        public void RefreshRooms()
        {
            Assert.IsNotEmpty(this.roomTypeController.RefreshEntities());
        }

        /// <summary>
        /// The update hotel.
        /// </summary>
        [Test]
        public void UpdateHotel()
        {
            this.roomType.Code = "new Room Type Code";
            this.roomType.View = View.SeaView;
            this.roomType.BedType = BedType.OlympicQueen;
            this.roomType.Sauna = false;
            this.roomType.Tv = false;
            this.roomType.WiFi = false;
            
            this.roomType = this.roomTypeController.CreateOrUpdateEntity(this.roomType);

            Assert.AreEqual(this.roomType.Code, "new Room Type Code");
            Assert.AreEqual(this.roomType.View, View.SeaView);
            Assert.AreEqual(this.roomType.BedType, BedType.OlympicQueen);
            Assert.AreEqual(this.roomType.Sauna, false);
            Assert.AreEqual(this.roomType.Tv, false);
            Assert.AreEqual(this.roomType.WiFi, false);
        }
    }
}