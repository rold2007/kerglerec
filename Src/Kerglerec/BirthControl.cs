// <copyright file="BirthControl.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   /// <summary>
   /// Manages population flow.
   /// </summary>
   public sealed record BirthControl
   {
      private int springStartMonth = 4;
      private int fallEndMonth = 11;
      private double summerBirthRate = 0.03;
      private double winterBirthRate = -0.025;

      /// <summary>
      /// Initializes a new instance of the <see cref="BirthControl"/> record.
      /// </summary>
      public BirthControl()
      {
      }

      /// <summary>
      /// Evaluate the change in population based on the time of the year.
      /// </summary>
      /// <param name="calendar">Next month.</param>
      /// <param name="province">Province to compute.</param>
      /// <returns>Population flow.</returns>
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

         if (calendar.Month >= this.springStartMonth && calendar.Month <= this.fallEndMonth)
         {
            populationFlow = populationFlow.Add(Math.Max(1, Convert.ToInt32(province.Population.Adults * this.summerBirthRate)));
         }
         else
         {
            populationFlow = populationFlow.Add(Math.Max(1, Convert.ToInt32(-province.Population.Adults * this.winterBirthRate)));
         }

         return populationFlow;
      }
   }
}
