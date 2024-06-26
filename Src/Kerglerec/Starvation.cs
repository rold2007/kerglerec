﻿// <copyright file="Starvation.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   public sealed record Starvation // ncrunch: no coverage
   {
      private double starvationFoodRate = 0.5;

      public Starvation()
      {
      }

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

         Population deathByStarvation = new Population();

         if (province.Population.Adults > 0)
         {
            double riceConsumptionRate = foodConsumption.Rice / province.Population.Adults;

            if (riceConsumptionRate < starvationFoodRate)
            {
               // With a starvation rate of 0.5 and consumption of 0.0 we target to lose half of the population.
               deathByStarvation = deathByStarvation.Add(Convert.ToInt32((starvationFoodRate - riceConsumptionRate) * province.Population.Adults));
            }
         }

         return deathByStarvation;
      }
   }
}
