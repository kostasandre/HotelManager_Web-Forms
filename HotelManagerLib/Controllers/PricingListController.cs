﻿// --------------------------------------------------------------------------------------------------------------------
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

    using DBContext;
    using Enums;
    using Exceptions;
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
        /// The get pricing list for hotel.
        /// </summary>
        /// <param name="hotelId">
        /// The hotel id.
        /// </param>
        /// <returns>
        /// The <see cref="IList{PricingList}"/>.
        /// </returns>
        public IList<PricingList> GetPricingListForHotel(int hotelId)
        {
            using (var context = new DataBaseContext())
            {
                var pricingListQuery = this.Repository.ReadAllQuery(context);
                var servicesForHotel = context.Services.Where(service => service.HotelId == hotelId);
                return pricingListQuery.Where(
                    pricingList =>
                        pricingList.TypeOfBillableEntity == TypeOfBillableEntity.RoomType
                        || (pricingList.TypeOfBillableEntity == TypeOfBillableEntity.Service
                            && servicesForHotel.Any(service => service.Id == pricingList.BillableEntityId))).ToList();
            }
        }

        /// <summary>
        /// The room pricing.
        /// </summary>
        /// <param name="dateFromSender">
        /// The date from sender.
        /// </param>
        /// <param name="dateToSender">
        /// The date to sender.
        /// </param>
        /// <param name="roomTypeId">
        /// The room type id.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The given dates are null
        /// </exception>
        /// <exception cref="WrongGivenPeriodException">
        /// Given From date is larger than given To date
        /// </exception>
        /// <exception cref="DataException">
        /// Can't read from database
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Doesn't exist pricing List for these period
        /// </exception>
        /// <exception cref="PricingPeriodDuplicateException">
        /// There are two pricing List for this period
        /// </exception>
        public double RoomPricing(object dateFromSender, object dateToSender, int roomTypeId)
        {
            if (dateFromSender == null || dateToSender == null)
            {
                throw new ArgumentNullException($"Please insert correct dates");
            }

            var dateFrom = Convert.ToDateTime(dateFromSender);
            var dateTo = Convert.ToDateTime(dateToSender);

            if (dateFrom > dateTo)
            {
                throw new WrongGivenPeriodException("Given From date is larger than given To date!");
            }

            List<PricingList> pricingListsOfTheRoomForWholeYear;
            double sum = 0;
            
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
                var flag = 0;
                foreach (var pricingListOfTheRoomForOnePeriod in pricingListsOfTheRoomForWholeYear)
                {
                    if (date >= pricingListOfTheRoomForOnePeriod.ValidFrom && date <= pricingListOfTheRoomForOnePeriod.ValidTo)
                    {
                        sum += pricingListOfTheRoomForOnePeriod.Price
                                + (pricingListOfTheRoomForOnePeriod.Price * pricingListOfTheRoomForOnePeriod.VatPrc / 100);
                        flag++;
                        if (flag > 1)
                        {
                            throw new PricingPeriodDuplicateException($"At least one of the given days is in two Pricing Lists", new List<PricingList> { pricingListOfTheRoomForOnePeriod });
                        }
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
                catch (Exception exception)
                {
                    throw new DataException(" ", exception);
                }
            }

            if (tempPricingList == null)
            {
                throw new NullReferenceException($"No pricing list for given days!");
            }

            return tempPricingList.Price + (tempPricingList.Price * tempPricingList.VatPrc / 100);
        }

        /// <summary>
        /// The validation date for pricing list.
        /// </summary>
        /// <param name="dateFromSender">
        /// The date from sender.
        /// </param>
        /// <param name="dateToSender">
        /// The date to sender.
        /// </param>
        /// <param name="typeOfEntityEnum">
        /// The type of entity enum.
        /// </param>
        /// <param name="billableEntityId">
        /// The billable entity id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="DataException">
        /// Can't read from database
        /// </exception>
        public bool ValidationDateForPricingList(object dateFromSender, object dateToSender, TypeOfBillableEntity typeOfEntityEnum, int billableEntityId)
        {
            var dateFrom = Convert.ToDateTime(dateFromSender);
            var dateTo = Convert.ToDateTime(dateToSender);

            List<PricingList> pricingListsOfTheBillableEntityForWholeYear;

            try
            {
                using (var context = new DataBaseContext())
                {
                    pricingListsOfTheBillableEntityForWholeYear =
                        this.Repository.ReadAllQuery(context)
                            .Where(
                                x =>
                                    x.BillableEntityId == billableEntityId
                                    && x.TypeOfBillableEntity == typeOfEntityEnum)
                            .ToList();
                }
            }
            catch (Exception exception)
            {
                throw new DataException($" Error retreiving data!", exception);
            }

            foreach (var pricingListOfTheBillableEntityForOnePeriod in pricingListsOfTheBillableEntityForWholeYear)
            {
                if (pricingListOfTheBillableEntityForOnePeriod.ValidFrom <= dateTo && pricingListOfTheBillableEntityForOnePeriod.ValidTo >= dateFrom)
                {
                    return false;
                }
            }

            return true;
        }
    }
}