// <copyright file="Harvest.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   public sealed record Harvest
   {
      private Month springStartMonth = Month.April;
      private Month fallEndMonth = Month.September;
      private double springHarvestRate = 2.0;
      private double fallHarvestRate = 6.0;

      public Harvest()
      {
      }

      public Food FoodProduction(Calendar calendar, Province province)
      {
         if (calendar == null)
         {
            throw new ArgumentNullException(nameof(calendar));
         }

         if (province == null)
         {
            throw new ArgumentNullException(nameof(province));
         }

         Food food = new Food();

         if (calendar.Month >= springStartMonth && calendar.Month <= fallEndMonth)
         {
            if (calendar.Month == fallEndMonth)
            {
               food = food.Add(Convert.ToInt32(Math.Max(1, fallHarvestRate * province.Population.Adults)));
            }
            else
            {
               food = food.Add(Convert.ToInt32(Math.Max(1, springHarvestRate * province.Population.Adults)));
            }
         }

         return food;
      }
   }
}
