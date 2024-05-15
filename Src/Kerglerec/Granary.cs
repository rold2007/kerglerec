// <copyright file="Granary.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   public sealed record Granary // ncrunch: no coverage
   {
      private double[] monthlyConsumptionRates =
      {
            1.25, // Januray
            1.25,
            1.25,
            1.20, // April
            1.15,
            1.10,
            1.10, // July
            1.10,
            1.10,
            1.15, // October
            1.20,
            1.25
      };

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
         foodRequired = foodRequired.Add(Math.Max(1, Convert.ToInt32(monthlyConsumptionRates[(int)calendar.Month] * province.Population.Adults)));

         Food foodConsumption = new Food();

         foodConsumption = foodConsumption.Add(Math.Min(foodRequired.Rice, province.Food.Rice));

         return foodConsumption;
      }
   }
}
