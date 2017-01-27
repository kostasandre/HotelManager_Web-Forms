// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelControllerTests.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The hotel controller tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Tests
{
    #region

    using System;
    using System.Linq;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The hotel controller tests.
    /// </summary>
    public class HotelControllerTests
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

            this.room = new Room() { HotelId = this.hotel.Id, Code = "Alex Hotel 123", RoomTypeId = this.roomType.Id, };
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
        public void CreateHotel()
        {
            var hotelTemp = new Hotel()
                                {
                                    Name = "Alex Hotel 2",
                                    Address = "Syntagma 2",
                                    TaxId = "AH123456 2",
                                    Manager = "Alex 2",
                                    Phone = "2101234567 2",
                                    Email = "alex@outlook.com 2"
                                };
            hotelTemp = this.hotelController.CreateOrUpdateEntity(hotelTemp);

            Assert.AreEqual(hotelTemp.Name, "Alex Hotel 2");
            this.hotelController.DeleteEntity(hotelTemp);
        }

        /// <summary>
        /// The delete hotel.
        /// </summary>
        [Test]
        public void DeleteHotel()
        {
            var hotelTemp = new Hotel()
                                {
                                    Name = "Xaris Hotel",
                                    Address = "Omonoia",
                                    TaxId = "AA000000",
                                    Manager = "Xaris",
                                    Phone = "2262022620",
                                    Email = "xaris@outlook.com"
                                };
            hotelTemp = this.hotelController.CreateOrUpdateEntity(hotelTemp);

            this.hotelController.DeleteEntity(hotelTemp);

            Assert.IsEmpty(this.hotelController.RefreshEntities().Where(x => x.Name == "Xaris Hotel"));
        }

        /// <summary>
        /// The delete hotel.
        /// </summary>
        [Test]
        public void DeleteHotelWithRoom()
        {
            var hotelTemp = new Hotel()
            {
                Name = "Xaris Hotel",
                Address = "Omonoia",
                TaxId = "AA000000",
                Manager = "Xaris",
                Phone = "2262022620",
                Email = "xaris@outlook.com"
            };
            hotelTemp = this.hotelController.CreateOrUpdateEntity(hotelTemp);

            var roomTemp = new Room()
            { HotelId = hotelTemp.Id,
                Code = "Megalos Hotel 123",
                RoomTypeId = this.roomType.Id,
            };
            roomTemp = this.roomController.CreateOrUpdateEntity(roomTemp);

            this.hotelController.DeleteEntity(hotelTemp);

            Assert.IsEmpty(this.hotelController.RefreshEntities().Where(x => x.Name == "Xaris Hotel"));
        }

        /// <summary>
        /// The delete hotel.
        /// </summary>
        [Test]
        public void DeleteNullHotel()
        {
            var hotelTemp = new Hotel()
            {
                Name = "Xaris Hotel",
                Address = "Omonoia",
                TaxId = "AA000000",
                Manager = "Xaris",
                Phone = "2262022620",
                Email = "xaris@outlook.com"
            };
            var exp =
                Assert.Throws<ArgumentNullException>(() => this.hotelController.DeleteEntity(hotelTemp));
            Assert.That(exp.Message, Is.EqualTo("Value cannot be null."));
        }

        /// <summary>
        /// The get hotel.
        /// </summary>
        [Test]
        public void GetHotel()
        {
            var hotelTemp = new Hotel()
                                {
                                    Name = "Xaris Hotel",
                                    Address = "Omonoia",
                                    TaxId = "AA000000",
                                    Manager = "Xaris",
                                    Phone = "2262022620",
                                    Email = "xaris@outlook.com"
                                };
            this.hotelController.CreateOrUpdateEntity(hotelTemp);

            var hotelTemp2 = this.hotelController.RefreshEntities().SingleOrDefault(x => x.Name == "Xaris Hotel");
            if (hotelTemp2 != null)
            {
                var hotelForCheck = this.hotelController.GetEntity(hotelTemp2.Id);
                Assert.AreEqual(hotelForCheck.Address, "Omonoia");
                this.hotelController.DeleteEntity(hotelForCheck);
            }
        }

        /// <summary>
        /// The refresh hotels.
        /// </summary>
        [Test]
        public void RefreshHotels()
        {
            Assert.IsNotEmpty(this.hotelController.RefreshEntities());

            // Assert.Contains(this.hotel, this.hotelController.RefreshEntities() as List<Hotel>);
        }
        
        /// <summary>
        /// The update hotel.
        /// </summary>
        [Test]
        public void UpdateHotel()
        {
            this.hotel.Name = "Alex Hotel 3";
            this.hotel.Address = "Syntagma 3";
            this.hotel.TaxId = "AH123456 3";
            this.hotel.Manager = "Alex 3";
            this.hotel.Phone = "2101234567 3";
            this.hotel.Email = "alex@outlook.com 3";

            this.hotel = this.hotelController.CreateOrUpdateEntity(this.hotel);

            Assert.AreEqual(this.hotel.Name, "Alex Hotel 3");
            Assert.AreEqual(this.hotel.Address, "Syntagma 3");
            Assert.AreEqual(this.hotel.TaxId, "AH123456 3");
            Assert.AreEqual(this.hotel.Manager, "Alex 3");
            Assert.AreEqual(this.hotel.Phone, "2101234567 3");
            Assert.AreEqual(this.hotel.Email, "alex@outlook.com 3");
        }
    }
}