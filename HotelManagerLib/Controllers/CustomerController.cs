// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerController.cs" company="">
//   
// </copyright>
// <summary>
//   The customer controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The customer controller.
    /// </summary>
    public class CustomerController : IEntityController<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        public CustomerController()
        {
            this.Repository = new CustomerRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Customer> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Customer CreateOrUpdateEntity(Customer entity)
        {
            if (entity.Id == 0)
            {
                entity = this.Repository.Create(entity);
            }
            else
            {
                this.Repository.Update(entity);
            }

            return entity;
        }

        /// <summary>
        /// The delete entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DeleteEntity(Customer entity)
        {
            if (entity.Id > 0)
            {
                this.Repository.Delete(entity.Id);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Customer GetEntity(int id)
        {
            if (id > 0)
            {
                return this.Repository.ReadOne(id);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IList<Customer> RefreshEntities()
        {
            var bookingList = this.Repository.ReadAllList();
            return bookingList;
        }
    }
}