// <copyright file="Harvest.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   /// <summary>
   /// Manages the production of food.
   /// </summary>
   public sealed class Harvest
   {
      private static readonly Harvest EmptyHarvest = new Harvest();

      private int springStartMonth = 4;
      private int fallEndMonth = 9;
      private double springHarvestRate = 2.0;
      private double fallHarvestRate = 6.0;

      /// <summary>
      /// Initializes a new instance of the <see cref="Harvest"/> class.
      /// </summary>
      private Harvest()
      {
      }

      /// <summary>
      /// Gets an empty harvest.
      /// </summary>
      public static Harvest Empty
      {
         get
         {
            return EmptyHarvest;
         }
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

         Food food = Food.Empty;

         if (calendar.Month >= this.springStartMonth && calendar.Month <= this.fallEndMonth)
         {
            if (calendar.Month == this.fallEndMonth)
            {
               food = food.Add(Convert.ToInt32(this.fallHarvestRate * province.Population.Adults));
            }
            else
            {
               food = food.Add(Convert.ToInt32(this.springHarvestRate * province.Population.Adults));
            }
         }

         return food;
      }
   }
}
