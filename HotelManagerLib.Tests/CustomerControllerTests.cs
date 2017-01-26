using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLib.Tests
{
    using HotelManagerLib.Controllers;
    using HotelManagerLib.Models.Persistant;

    using NUnit.Framework;
    using NUnit.Framework.Internal;

    class CustomerControllerTests
    {
        private CustomerController customerController;

        private Customer customer;

        [SetUp]
        public void Setup()
        {
            this.customerController = new CustomerController();
            
            this.customer = new Customer()
                                {
                                    Name = "kwstasTests",
                                    Surname = "andre",
                                    TaxId = "TK1234567",
                                    IdNumber = "AB1234567",
                                    Address = "Monasthraki",
                                    Email = "theo@outlook.com",
                                    Phone = "2107654321"
                                };
            this.customer = this.customerController.CreateOrUpdateEntity(this.customer);
        }

        [Test]
        public void GetNullEntity()
        {
            var customer = new Customer();
            this.customerController = new CustomerController();
            var nullCustomer = Assert.Throws<ArgumentNullException>(
                () => this.customerController.GetEntity(customer.Id));
        }

        [Test]
        public void DeleteNullEntity()
        {
            var customer = new Customer();
            this.customerController = new CustomerController();
            var nullCustomer = Assert.Throws<ArgumentNullException>(
                () => this.customerController.DeleteEntity(customer));
        }

        [Test]
        public void refreshEntities()
        {
            var customers = this.customerController.RefreshEntities();
            Assert.AreNotEqual(customers.Count , null);
        }

        [Test]
        public void GetEntity()
        {
            var customer = this.customerController.GetEntity(this.customer.Id);
            Assert.AreEqual(customer.Id,this.customer.Id);
        }

        [Test]
        public void UpdateEntity()
        {
            this.customer.Name = "updateTest";
            var updatedCustomer = this.customerController.CreateOrUpdateEntity(this.customer);
            Assert.AreEqual(updatedCustomer.Name, this.customer.Name);
        }

        [TearDown]
        public void ClearHotel()
        {
            this.customerController.DeleteEntity(this.customer);
        }
    }
}
