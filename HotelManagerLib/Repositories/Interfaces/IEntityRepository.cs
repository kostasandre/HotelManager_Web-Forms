// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The EntityRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories.Interfaces
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant.Interfaces;

    #endregion

    /// <summary>
    /// The EntityRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// Any Entity parameter
    /// </typeparam>
    public interface IEntityRepository<T>
        where T : IEntity
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billing">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Create(T billing);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{List}"/>.
        /// </returns>
        IList<T> ReadAllList();

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> ReadAllQuery(DataBaseContext context);

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T ReadOne(int id);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The billing.
        /// </param>
        void Update(T entity);
    }
}