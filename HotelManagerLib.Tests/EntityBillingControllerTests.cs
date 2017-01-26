// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBillingControllerTests.cs" company="">
//   
// </copyright>
// <summary>
//   The entity billing controller tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Tests
{
    #region

    using System;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.DBContext;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The entity billing controller tests.
    /// </summary>
    public class EntityBillingControllerTests
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

            this.room = new Room()
                            {
                                HotelId = this.hotel.Id,
                                Code = "Alex Hotel 123",
                                RoomTypeId = this.roomType.Id,
                            };
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
        }

        /// <summary>
        /// The create billing.
        /// </summary>
        [Test]
        public void CreateBilling()
        {
            var localBilling = new Billing()
            {
                BookingId = this.booking.Id,
                PriceForRoom = this.booking.AgreedPrice,
                PriceForServices = 150,
                TotalPrice = 12150,
                Paid = true
            };
            var testBilling = this.billingEntityController.CreateOrUpdateEntity(localBilling);
            Assert.AreEqual(testBilling.TotalPrice, localBilling.TotalPrice);
            this.billingEntityController.DeleteEntity(testBilling);
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        [Test]
        public void RefreshEntities()
        {
            var list = this.billingEntityController.RefreshEntities();
            Assert.AreNotEqual(list.Count, null);
        }

        /// <summary>
        /// The read one.
        /// </summary>
        [Test]
        public void GetEntity()
        {
            var test = this.billingEntityController.GetEntity(this.billing.Id);
            Assert.AreEqual(this.billing.Id , test.Id);
        }

        /// <summary>
        /// The update.
        /// </summary>
        [Test]
        public void Update()
        {
            this.billing.TotalPrice = 1000000;
            
            var testBilling = this.billingEntityController.CreateOrUpdateEntity(this.billing);
            Assert.IsNotNull(testBilling);
            Assert.AreEqual(testBilling.TotalPrice, this.billing.TotalPrice);
            Assert.AreEqual(Environment.UserName, testBilling.UpdatedBy);
        }

        /// <summary>
        /// The clear hotel.
        /// </summary>
        [TearDown]
        public void ClearHotel()
        {
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