// <copyright file="Granary.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   /// <summary>
   /// Manages food consumption.
   /// </summary>
   public sealed record Granary
   {
      // TODO Replace month int values by an enum
      private int winterStartMonth = 12;
      private int winterEndMonth = 3;

      // TODO Apply different rates for each season (Spring, Fall), or event each month.
      private double winterConsumptionRate = 1.25;
      private double summerConsumptionRate = 1.0;

      /// <summary>
      /// Initializes a new instance of the <see cref="Granary"/> class.
      /// </summary>
      public Granary()
      {
      }

      /// <summary>
      /// Evaluate the food consumption based on the time of the year.
      /// </summary>
      /// <param name="calendar">Next month.</param>
      /// <param name="province">Province to compute.</param>
      /// <returns>Food eaten.</returns>
      public Food FoodConsumption(Calendar calendar, Province province)
      {
         if (calendar == null)
         {
            throw new ArgumentNullException(nameof(calendar));
         }

         if (province == null)
         {
            throw new ArgumentNullException(nameof(province));
         }

         Food foodRequired = new Food();

         // HACK Need to do something different when the population is very low (<10)
         if (calendar.Month > winterEndMonth && calendar.Month < winterStartMonth)
         {
            foodRequired = foodRequired.Add(Math.Max(1, Convert.ToInt32(summerConsumptionRate * province.Population.Adults)));
         }
         else
         {
            foodRequired = foodRequired.Add(Math.Max(1, Convert.ToInt32(winterConsumptionRate * province.Population.Adults)));
         }

         Food foodConsumption = new Food();

         foodConsumption = foodConsumption.Add(Math.Min(foodRequired.Rice, province.Food.Rice));

         return foodConsumption;
      }
   }
}
