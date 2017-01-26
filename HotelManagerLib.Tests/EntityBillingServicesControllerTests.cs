// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBillingServicesControllerTests.cs" company="">
//   
// </copyright>
// <summary>
//   The entity billing services controller test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Tests
{
    using System;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    using NUnit.Framework;

    /// <summary>
    /// The entity billing services controller test.
    /// </summary>
    public class EntityBillingServicesControllerTests
    {
        /// <summary>
        /// The billing.
        /// </summary>
        private Billing billing;

        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

        /// <summary>
        /// The booking entity controller.
        /// </summary>
        private IEntityController<Booking> bookingEntityController;

        /// <summary>
        /// The pricing list entity controller.
        /// </summary>
        private IEntityController<PricingList> pricingListEntityController;

        /// <summary>
        /// The pricing list.
        /// </summary>
        private PricingList servicePricingList;

        /// <summary>
        /// The room type pricing list.
        /// </summary>
        private PricingList roomTypePricingList;

        /// <summary>
        /// The booking.
        /// </summary>
        private Booking booking;

        /// <summary>
        /// The customer.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// The customer entity controller.
        /// </summary>
        private IEntityController<Customer> customerEntityController;

        /// <summary>
        /// The hotel.
        /// </summary>
        private Hotel hotel;

        /// <summary>
        /// The hotel entity controller.
        /// </summary>
        private IEntityController<Hotel> hotelEntityController;

        /// <summary>
        /// The room.
        /// </summary>
        private Room room;

        /// <summary>
        /// The room entity controller.
        /// </summary>
        private IEntityController<Room> roomEntityController;

        /// <summary>
        /// The room type.
        /// </summary>
        private RoomType roomType;

        /// <summary>
        /// The room type entity controller.
        /// </summary>
        private IEntityController<RoomType> roomTypeEntityController;

        /// <summary>
        /// The service.
        /// </summary>
        private Service service;

        /// <summary>
        /// The service entity controller.
        /// </summary>
        private IEntityController<Service> serviceEntityController;

        /// <summary>
        /// The billing service.
        /// </summary>
        private BillingService billingService;

        /// <summary>
        /// The billing services entity controller.
        /// </summary>
        private IEntityController<BillingService> billingServicesEntityController;

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.hotelEntityController = new HotelController();
            this.bookingEntityController = new BookingController();
            this.customerEntityController = new CustomerController();
            this.serviceEntityController = new ServiceController();
            this.roomTypeEntityController = new RoomTypeController();
            this.roomEntityController = new RoomController();
            this.billingEntityController = new BillingEntityController();
            this.pricingListEntityController = new PricingListController();
            this.billingServicesEntityController = new BillingServiceEntityController();

            this.hotel = new Hotel()
                             {
                                 Name = "Alex Hotel",
                                 Address = "Syntagma",
                                 TaxId = "AH123456",
                                 Manager = "Alex",
                                 Phone = "2101234567",
                                 Email = "alex@outlook.com"
                             };
            this.hotel = this.hotelEntityController.CreateOrUpdateEntity(this.hotel);

            this.roomType = new RoomType()
                                {
                                    Code = "TreeBed",
                                    View = View.MountainView,
                                    BedType = BedType.ModernCot,
                                    Tv = true,
                                    WiFi = true,
                                    Sauna = true
                                };
            this.roomType = this.roomTypeEntityController.CreateOrUpdateEntity(this.roomType);

            this.room = new Room() { HotelId = this.hotel.Id, Code = "Alex Hotel 123", RoomTypeId = this.roomType.Id, };
            this.room = this.roomEntityController.CreateOrUpdateEntity(this.room);

            this.service = new Service()
                               {
                                   HotelId = this.hotel.Id,
                                   Code = "AHBF",
                                   Description = "Breakfast Alex Hotel"
                               };
            this.service = this.serviceEntityController.CreateOrUpdateEntity(this.service);

            this.servicePricingList = new PricingList()
                                          {
                                              BillableEntityId = this.service.Id,
                                              TypeOfBillableEntity = TypeOfBillableEntity.Service,
                                              ValidFrom = DateTime.Now,
                                              ValidTo = Convert.ToDateTime("31/01/2017"),
                                              VatPrc = 13
                                          };
            this.servicePricingList = this.pricingListEntityController.CreateOrUpdateEntity(this.servicePricingList);

            this.roomTypePricingList = new PricingList()
                                           {
                                               BillableEntityId = this.roomType.Id,
                                               TypeOfBillableEntity = TypeOfBillableEntity.RoomType,
                                               ValidFrom = DateTime.Now,
                                               ValidTo = Convert.ToDateTime("31/01/2017").Date,
                                               VatPrc = 13
                                           };
            this.roomTypePricingList = this.pricingListEntityController.CreateOrUpdateEntity(this.roomTypePricingList);

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
            this.customer = this.customerEntityController.CreateOrUpdateEntity(this.customer);

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
            this.booking = this.bookingEntityController.CreateOrUpdateEntity(this.booking);

            this.billing = new Billing()
                               {
                                   BookingId = this.booking.Id,
                                   PriceForRoom = this.booking.AgreedPrice,
                                   PriceForServices = 150,
                                   TotalPrice = 12150,
                                   Paid = true
                               };
            this.billing = this.billingEntityController.CreateOrUpdateEntity(this.billing);

            this.billingService = new BillingService()
            {
                BillingId = this.billing.Id,
                ServiceId = this.service.Id,
                Quantity = 15,
                Price = 1500,
            };
            this.billingService = this.billingServicesEntityController.CreateOrUpdateEntity(this.billingService);
        }

        /// <summary>
        /// The create billing.
        /// </summary>
        [Test]
        public void CreateBillingService()
        {
            var localBillingService = new BillingService()
            {
                BillingId = this.billing.Id,
                ServiceId = this.service.Id,
                Quantity = 15,
                Price = 1500,
            };
            var testBillingService = this.billingServicesEntityController.CreateOrUpdateEntity(localBillingService);
            Assert.AreEqual(testBillingService.Quantity, localBillingService.Quantity);
            this.billingServicesEntityController.DeleteEntity(testBillingService);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        [Test]
        public void RefreshEntities()
        {
            var list = this.billingServicesEntityController.RefreshEntities();
            Assert.AreNotEqual(list.Count, null);
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        [Test]
        public void GetEntity()
        {
            var test = this.billingServicesEntityController.GetEntity(this.billingService.Id);
            Assert.AreEqual(this.billingService.Id, test.Id);
        }

        /// <summary>
        /// The get entity null reference exception.
        /// </summary>
        [Test]
        public void GetEntityNullReferenceException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.billingServicesEntityController.GetEntity(0));
        }

        /// <summary>
        /// The update.
        /// </summary>
        [Test]
        public void Update()
        {
            this.billingService.Quantity = 10;

            this.billingServicesEntityController.CreateOrUpdateEntity(this.billingService);
            var testBillingService = this.billingServicesEntityController.GetEntity(this.billingService.Id);
            Assert.IsNotNull(testBillingService = this.billingServicesEntityController.GetEntity(this.billingService.Id));
            Assert.AreEqual(testBillingService.Quantity , this.billingService.Quantity);
            Assert.AreEqual(Environment.UserName , testBillingService.UpdatedBy);
        }

        /// <summary>
        /// The delete null reference exception.
        /// </summary>
        [Test]
        public void DeleteNullReferenceException()
        {
            var testBillingService = new BillingService();
            Assert.Throws<ArgumentNullException>(
                () => this.billingServicesEntityController.DeleteEntity(testBillingService));
        }

        /// <summary>
        /// The clear hotel.
        /// </summary>
        [TearDown]
        public void ClearHotel()
        {
            this.billingServicesEntityController.DeleteEntity(this.billingService);
            this.bookingEntityController.DeleteEntity(this.booking);
            this.customerEntityController.DeleteEntity(this.customer);
            this.pricingListEntityController.DeleteEntity(this.servicePricingList);
            this.pricingListEntityController.DeleteEntity(this.roomTypePricingList);
            this.serviceEntityController.DeleteEntity(this.service);
            this.roomEntityController.DeleteEntity(this.room);
            this.roomTypeEntityController.DeleteEntity(this.roomType);
            this.hotelEntityController.DeleteEntity(this.hotel);
        }
    }
}