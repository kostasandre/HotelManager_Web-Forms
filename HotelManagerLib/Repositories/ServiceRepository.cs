// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The service repository.
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
    /// The service repository.
    /// </summary>
    public class ServiceRepository : IEntityRepository<Service>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        /// <returns>
        /// The <see cref="Service"/>.
        /// </returns>
        public Service Create(Service service)
        {
            using (var context = new DataBaseContext())
            {
                context.Services.Add(service);
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

            return service;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The Service is null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var service = context.Services.SingleOrDefault(x => x.Id == id);
                if (service == null)
                {
                    throw new ArgumentNullException();
                }

                context.Services.Remove(service);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Service}"/>.
        /// </returns>
        public IList<Service> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Services.Include("Hotels").ToList();
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
        public IQueryable<Service> ReadAllQuery(DataBaseContext context)
        {
            return context.Services.Include("Hotels");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Service"/>.
        /// </returns>
        public Service ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var service = context.Services.Include("Hotels").SingleOrDefault(x => x.Id == id);
                return service;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        public void Update(Service service)
        {
            using (var context = new DataBaseContext())
            {
                var databaseService = context.Services.SingleOrDefault(x => x.Id == service.Id);

                if (databaseService == null)
                {
                    return;
                }

                databaseService.Code = service.Code;
                databaseService.Updated = DateTime.Now;
                databaseService.UpdatedBy = Environment.UserName;
                databaseService.Description = service.Description;
                context.SaveChanges();
            }
        }
    }
}