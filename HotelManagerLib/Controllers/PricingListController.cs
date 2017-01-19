// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingListController.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing list controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Enums;

    using Interfaces;

    using Models.Persistant;

    using Repositories;
    using Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The pricing list controller.
    /// </summary>
    public class PricingListController : IEntityController<PricingList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PricingListController"/> class.
        /// </summary>
        public PricingListController()
        {
            this.Repository = new PricingListRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<PricingList> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="PricingList"/>.
        /// </returns>
        public PricingList CreateOrUpdateEntity(PricingList entity)
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
        /// <exception cref="ArgumentNullException">
        /// The PricingList is null
        /// </exception>
        public void DeleteEntity(PricingList entity)
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
        /// The <see cref="PricingList"/>.
        /// </returns>
        public PricingList GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{PricingList}"/>.
        /// </returns>
        public IList<PricingList> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }

        /// <summary>
        /// The room pricing.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <param name="roomId">
        /// The room id.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double RoomPricing(DateTime dateFrom, DateTime dateTo, int roomTypeId)
        {
            if (dateFrom > dateTo)
            {
                throw new ArgumentException("Given From date is larger than given To date!");
            }
            List<PricingList> pricingListsOfTheRoomForWholeYear;
            double sum = 0;
            
            IEntityRepository<Room> roomRepository = new RoomRepository();
            try
            {
                using (var context = new DataBaseContext())
                {
                    pricingListsOfTheRoomForWholeYear =
                        this.Repository.ReadAllQuery(context)
                            .Where(
                                x =>
                                    x.BillableEntityId == roomTypeId
                                    && x.TypeOfBillableEntity == TypeOfBillableEntity.RoomType
                                    && (x.ValidTo >= dateFrom && x.ValidFrom <= dateTo))
                            .ToList();
                }
            }
            catch (Exception exception)
            {
                
                throw new DataException($" Error retreiving data!", exception);
            }
            

            if (pricingListsOfTheRoomForWholeYear == null || pricingListsOfTheRoomForWholeYear.Count == 0)
            {
                throw new NullReferenceException($"No pricing list for given days!");
            }

            for (DateTime date = dateFrom; date.Date <= dateTo.Date; date = date.AddDays(1))
            {
                foreach (var pricingListOfTheRoomForOnePeriod in pricingListsOfTheRoomForWholeYear)
                {

                    if (date >= pricingListOfTheRoomForOnePeriod.ValidFrom && date <= pricingListOfTheRoomForOnePeriod.ValidTo)
                    {
                        sum += pricingListOfTheRoomForOnePeriod.Price
                                + (pricingListOfTheRoomForOnePeriod.Price * pricingListOfTheRoomForOnePeriod.VatPrc);
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// The service pricing.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <param name="serviceId">
        /// The service id.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The Pricing List is null
        /// </exception>
        public double ServicePricing(DateTime dateFrom, int serviceId)
        {
            PricingList tempPricingList;
            using (var context = new DataBaseContext())
            {
                try
                {
                    tempPricingList =
                        this.Repository.ReadAllQuery(context)
                            .FirstOrDefault(
                                x =>
                                    x.BillableEntityId == serviceId
                                    && x.TypeOfBillableEntity == TypeOfBillableEntity.Service
                                    && (dateFrom >= x.ValidFrom && dateFrom <= x.ValidTo));
                }
                catch (ArgumentNullException)
                {
                    throw new ArgumentNullException();
                }
            }

            if (tempPricingList == null)
            {
                throw new ArgumentNullException();
            }

            return tempPricingList.Price + (tempPricingList.Price * tempPricingList.VatPrc);
        }
    }
}