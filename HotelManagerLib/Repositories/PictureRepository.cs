// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The billing repository.
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
    /// The billing repository.
    /// </summary>
    public class PictureRepository : IEntityRepository<Picture>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billing">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="Picture"/>.
        /// </returns>
        public Picture Create(Picture billing)
        {
            using (var context = new DataBaseContext())
            {
                context.Pictures.Add(billing);
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

            return billing;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The billing is null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var picture = context.Pictures.SingleOrDefault(x => x.Id == id);
                if (picture == null)
                {
                    throw new ArgumentNullException($"ArgumentNullException");
                }

                context.Pictures.Remove(picture);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{pictures}"/>.
        /// </returns>
        public IList<Picture> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Pictures.ToList(); // .Include("Company")
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
        public IQueryable<Picture> ReadAllQuery(DataBaseContext context)
        {
            return context.Pictures; // .Include("Company");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Picture"/>.
        /// </returns>
        public Picture ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var picture = context.Pictures.SingleOrDefault(x => x.Id == id); // .Include("Company")
                return picture;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="picture">
        /// The billing.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// The update has not implemented
        /// </exception>
        public void Update(Picture picture)
        {
            throw new NotImplementedException();
        }
    }
}