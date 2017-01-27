// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceControllerTests.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The service controller tests.
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
    /// The service controller tests.
    /// </summary>
    public class ServiceControllerTests
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
        /// The create room type.
        /// </summary>
        [Test]
        public void CreateService()
        {
            var serviceTemp = new Service()
            {
                HotelId = this.hotel.Id,
                Code = "BXH",
                Description = "Brunch Xaris Hotel"
            };
            serviceTemp = this.serviceController.CreateOrUpdateEntity(serviceTemp);

            Assert.AreEqual(serviceTemp.Code, "BXH");
            Assert.AreEqual(serviceTemp.Description, "Brunch Xaris Hotel");
            Assert.AreEqual(serviceTemp.HotelId, this.hotel.Id);

            this.serviceController.DeleteEntity(serviceTemp);
        }

        /// <summary>
        /// The delete null service.
        /// </summary>
        [Test]
        public void DeleteNullService()
        {
            var serviceTemp = new Service()
            {
                HotelId = this.hotel.Id,
                Code = "BXH",
                Description = "Brunch Xaris Hotel"
            };
            var exp =
                Assert.Throws<ArgumentNullException>(() => this.serviceController.DeleteEntity(serviceTemp));
            Assert.That(exp.Message, Is.EqualTo("Value cannot be null."));
        }

        /// <summary>
        /// The delete service.
        /// </summary>
        [Test]
        public void DeleteService()
        {
            var serviceTemp = new Service()
            {
                HotelId = this.hotel.Id,
                Code = "BXH",
                Description = "Brunch Xaris Hotel"
            };
            serviceTemp = this.serviceController.CreateOrUpdateEntity(serviceTemp);

            var servicePricingListTemp = new PricingList()
            {
                BillableEntityId = serviceTemp.Id,
                TypeOfBillableEntity = TypeOfBillableEntity.Service,
                ValidFrom = DateTime.Now,
                ValidTo = Convert.ToDateTime("31/01/2017"),
                Price = 999,
                VatPrc = 99
            };
            this.pricingListController.CreateOrUpdateEntity(servicePricingListTemp);

            this.serviceController.DeleteEntity(serviceTemp);

            Assert.IsEmpty(this.serviceController.RefreshEntities().Where(x => x.Code == "BXH"));
            Assert.IsEmpty(this.pricingListController.RefreshEntities().Where(x => x.BillableEntityId == serviceTemp.Id && x.TypeOfBillableEntity == TypeOfBillableEntity.Service));
        }

        /// <summary>
        /// The get service.
        /// </summary>
        [Test]
        public void GetService()
        {
            var serviceTemp = new Service()
            {
                HotelId = this.hotel.Id,
                Code = "BXH",
                Description = "Brunch Xaris Hotel"
            };
            serviceTemp = this.serviceController.CreateOrUpdateEntity(serviceTemp);

            var servicePricingListTemp = new PricingList()
            {
                BillableEntityId = serviceTemp.Id,
                TypeOfBillableEntity = TypeOfBillableEntity.Service,
                ValidFrom = DateTime.Now,
                ValidTo = Convert.ToDateTime("31/01/2017"),
                Price = 999,
                VatPrc = 99
            };
            servicePricingListTemp = this.pricingListController.CreateOrUpdateEntity(servicePricingListTemp);

            var serviceTemp2 = this.serviceController.RefreshEntities().SingleOrDefault(x => x.Code == "BXH");
            if (serviceTemp2 != null)
            {
                var serviceForCheck = this.serviceController.GetEntity(serviceTemp2.Id);

                var servicePricingListForCheck = this.pricingListController.GetEntity(servicePricingListTemp.Id);

                Assert.AreEqual(serviceForCheck.Code, "BXH");
                Assert.AreEqual(serviceForCheck.Description, "Brunch Xaris Hotel");
                Assert.AreEqual(serviceForCheck.HotelId, this.hotel.Id);
            
                Assert.AreEqual(servicePricingListForCheck.BillableEntityId, serviceForCheck.Id);

                this.serviceController.DeleteEntity(serviceForCheck);
            }
        }

        /// <summary>
        /// The refresh services.
        /// </summary>
        [Test]
        public void RefreshServices()
        {
            Assert.IsNotEmpty(this.serviceController.RefreshEntities());
        }

        /// <summary>
        /// The update service.
        /// </summary>
        [Test]
        public void UpdateService()
        {
            this.service.Code = "BXH";
            this.service.Description = "Brunch Xaris Hotel";

            this.serviceController.CreateOrUpdateEntity(this.service);

            Assert.AreEqual(this.service.Code, "BXH");
            Assert.AreEqual(this.service.Description, "Brunch Xaris Hotel");
        }
    }
}