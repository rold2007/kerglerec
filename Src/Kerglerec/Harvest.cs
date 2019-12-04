// <copyright file="Harvest.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;
   using System.Collections.Generic;
   using System.Text;

   /// <summary>
   /// Manages the production of food.
   /// </summary>
   public class Harvest
   {
      private int springStartMonth = 4;
      private int fallEndMonth = 9;
      private double springHarvestRate = 2.0;
      private double fallHarvestRate = 6.0;

      /// <summary>
      /// Initializes a new instance of the <see cref="Harvest"/> class.
      /// </summary>
      public Harvest()
      {
      }

      /// <summary>
      /// Evaluate the food production based on the time of the year.
      /// </summary>
      /// <param name="calendar">Next month.</param>
      /// <param name="province">Province to compute.</param>
      /// <returns>Produced food.</returns>
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

         if (calendar.Month >= this.springStartMonth && calendar.Month <= this.fallEndMonth)
         {
            if (calendar.Month == this.fallEndMonth)
            {
               food.Add(Convert.ToInt32(this.fallHarvestRate * province.Population.Adult));
            }
            else
            {
               food.Add(Convert.ToInt32(this.springHarvestRate * province.Population.Adult));
            }
         }

         return food;
      }
   }
}
