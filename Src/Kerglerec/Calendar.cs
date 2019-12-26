// <copyright file="Calendar.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   /// <summary>
   /// Manages time flow.
   /// </summary>
   public class Calendar
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Calendar"/> class.
      /// </summary>
      public Calendar()
      {
         this.Month = 1;
         this.Year = 1;
      }

      /// <summary>
      /// Gets the current month of the calendar.
      /// </summary>
      public int Month
      {
         get;
         private set;
      }

      /// <summary>
      /// Gets the current year of the calendar.
      /// </summary>
      public int Year
      {
         get;
         private set;
      }

      /// <summary>
      /// Advance time by X months.
      /// </summary>
      /// <param name="monthCount">Months to add.</param>
      public void Add(int monthCount)
      {
         int month = this.Month + monthCount;

         this.Month = month % 12;
      }

      /// <summary>
      /// Advance time by X months and Y years.
      /// </summary>
      /// <param name="monthCount">Months to add.</param>
      /// <param name="yearCount">Years to add.</param>
      public void Add(int monthCount, int yearCount)
      {
         this.Add(monthCount);

         this.Year += yearCount;
      }
   }
}
