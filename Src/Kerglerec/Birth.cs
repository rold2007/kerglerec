// <copyright file="Birth.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   public sealed record Birth
   {
      private Month springStartMonth = Month.April;
      private Month fallEndMonth = Month.November;

      // TODO Apply different rates for each season (Spring, Fall), or event each month.
      private double summerBirthRate = 0.03;
      private double winterBirthRate = 0.01;

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
