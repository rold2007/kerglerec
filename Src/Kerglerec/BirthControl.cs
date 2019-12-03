// <copyright file="BirthControl.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   /// <summary>
   /// Manages population flow.
   /// </summary>
   public class BirthControl
   {
      private int springStartMonth = 4;
      private int fallEndMonth = 11;
      private double summerBirthRate = 0.03;
      private double winterBirthRate = -0.025;

      /// <summary>
      /// Initializes a new instance of the <see cref="BirthControl"/> class.
      /// </summary>
      public BirthControl()
      {
      }

      /// <summary>
      /// Evaluate the change in population based on the time of the year.
      /// </summary>
      /// <param name="calendar">Next month.</param>
      /// <param name="province">Province to compute.</param>
      public void ComputePopulationChange(Calendar calendar, Province province)
      {
         if (calendar == null)
         {
            throw new ArgumentNullException(nameof(calendar));
         }

         if (province == null)
         {
            throw new ArgumentNullException(nameof(province));
         }

         int populationFlow = 0;

         if (calendar.Month >= this.springStartMonth && calendar.Month <= this.fallEndMonth)
         {
            populationFlow = Math.Max(1, Convert.ToInt32(province.Population * this.summerBirthRate));
         }
         else
         {
            populationFlow = Math.Max(1, Convert.ToInt32(-province.Population * this.winterBirthRate));
         }

         province.Add(populationFlow);
      }
   }
}
