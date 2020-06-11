// <copyright file="Starvation.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;
   using System.Collections.Generic;
   using System.Text;

   /// <summary>
   /// Manages food needs for the population.
   /// </summary>
   public class Starvation
   {
      private double starvationFoodRate = 0.5;

      /// <summary>
      /// Initializes a new instance of the <see cref="Starvation"/> class.
      /// </summary>
      public Starvation()
      {
      }

      /// <summary>
      /// Computes the population lacking food.
      /// </summary>
      /// <param name="province">Province to compute.</param>
      /// <param name="foodConsumption">Food consumption for the month.</param>
      /// <returns>Populatin dead by hunger.</returns>
      public Population Death(Province province, Food foodConsumption)
      {
         if (province == null)
         {
            throw new ArgumentNullException(nameof(province));
         }

         if (foodConsumption == null)
         {
            throw new ArgumentNullException(nameof(foodConsumption));
         }

         Population deathByStarvation = Population.Empty;

         if (province.Population.Adults > 0)
         {
            double riceConsumptionRate = foodConsumption.Rice / province.Population.Adults;

            if (riceConsumptionRate < this.starvationFoodRate)
            {
               // With a starvation rate of 0.5 and consumption of 0.0 we target to lose half of the population.
               deathByStarvation = deathByStarvation.Add(Convert.ToInt32((this.starvationFoodRate - riceConsumptionRate) * province.Population.Adults));
            }
         }

         return deathByStarvation;
      }
   }
}
