// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The customer repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The customer repository.
    /// </summary>
    class CustomerRepository : IEntityRepository<Customer>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Customer Create(Customer customer)
        {
            using (var context = new DataBaseContext())
            {
                context.Customers.Add(customer);
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var validationErrors in exception.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                "Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }

            return customer;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var customer = context.Customers.SingleOrDefault(x => x.Id == id);
                context.Customers.Remove(customer);
                if (customer == null)
                {
                    throw new ArgumentNullException();
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var validationErrors in exception.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                "Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IList<Customer> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Customers.Include("Bookings").ToList();
            }
        }

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IQueryable<Customer> ReadAllQuery(DataBaseContext context)
        {
            return context.Customers.Include("Bookings");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Customer ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var customer = context.Customers.Include("Bookings").SingleOrDefault(x => x.Id == id);
                return customer;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Update(Customer entity)
        {
            using (var context = new DataBaseContext())
            {
                var customer = context.Customers.SingleOrDefault(x => x.Id == entity.Id);

                customer.Address = entity.Address;
                customer.Bookings = entity.Bookings;
                customer.Email = entity.Email;
                customer.IdNumber = entity.IdNumber;
                customer.Name = entity.Name;
                customer.Phone = entity.Phone;
                customer.Surname = entity.Surname;
                customer.TaxId = entity.TaxId;
                customer.Updated = DateTime.Now;
                customer.UpdatedBy = Environment.UserName;

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var validationErrors in exception.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                "Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}