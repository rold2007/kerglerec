// <copyright file="Birth.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   /// <summary>
   /// Manages population flow.
   /// </summary>
   public sealed record Birth
   {
      // TODO Replace month int values by an enum
      private int springStartMonth = 4;
      private int fallEndMonth = 11;

      // TODO Apply different rates for each season (Spring, Fall), or event each month.
      private double summerBirthRate = 0.03;
      private double winterBirthRate = 0.01;

      /// <summary>
      /// Initializes a new instance of the <see cref="Birth"/> class.
      /// </summary>
      public Birth()
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

         // HACK Need to do something different when the population is very low (<10) ?
         if (calendar.Month >= springStartMonth && calendar.Month <= fallEndMonth)
         {
            populationFlow = populationFlow.Add(Math.Max(1, Convert.ToInt32(province.Population.Adults * summerBirthRate)));
         }
         else
         {
            populationFlow = populationFlow.Add(Math.Max(1, Convert.ToInt32(province.Population.Adults * winterBirthRate)));
         }

         return populationFlow;
      }
   }
}
