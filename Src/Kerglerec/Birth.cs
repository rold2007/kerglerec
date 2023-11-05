// <copyright file="Birth.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   public sealed record Birth
   {
      private double[] monthlyBirthRates =
      {
            0.01, // Januray
            0.01,
            0.02,
            0.03, // April
            0.05,
            0.03,
            0.03, // July
            0.03,
            0.03,
            0.02, // October
            0.01,
            0.01
      };

      public Birth()
      {
      }

      public Population PopulationFlow(Calendar calendar, Province province)
      {
         if (calendar == null)
         {
            throw new ArgumentNullException(nameof(calendar));
         }

         if (province == null)
         {
            throw new ArgumentNullException(nameof(province));
         }

         Population populationFlow = new Population();

         // HACK Need to do something different when the population is very low (<10) ?
         populationFlow = populationFlow.Add(Math.Max(1, Convert.ToInt32(province.Population.Adults * monthlyBirthRates[(int)calendar.Month])));

         return populationFlow;
      }
   }
}
