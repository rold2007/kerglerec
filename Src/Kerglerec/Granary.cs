// <copyright file="Granary.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   public sealed record Granary
   {
      private Month winterStartMonth = Month.December;
      private Month winterEndMonth = Month.March;

      // TODO Apply different rates for each season (Spring, Fall), or event each month.
      private double winterConsumptionRate = 1.25;
      private double summerConsumptionRate = 1.0;

      public Granary()
      {
      }

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
