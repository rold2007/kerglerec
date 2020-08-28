// <copyright file="Calendar.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   /// <summary>
   /// Manages time flow.
   /// </summary>
   public sealed class Calendar
   {
      private static readonly Calendar EmptyCalendar = new Calendar();

      /// <summary>
      /// Initializes a new instance of the <see cref="Calendar"/> class.
      /// </summary>
      private Calendar()
      {
         this.Month = 1;
         this.Year = 1;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="Calendar"/> class.
      /// </summary>
      private Calendar(int month, int year)
      {
         this.Month = month;
         this.Year = year;
      }

      /// <summary>
      /// Gets an empty calendar.
      /// </summary>
      public static Calendar Empty
      {
         get
         {
            return EmptyCalendar;
         }
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
      /// <returns>New calendar with added months.</returns>
      public Calendar Add(int monthCount)
      {
         int month = this.Month + monthCount;

         return new Calendar(month % 12, this.Year);
      }

      /// <summary>
      /// Advance time by X months and Y years.
      /// </summary>
      /// <param name="monthCount">Months to add.</param>
      /// <param name="yearCount">Years to add.</param>
      /// <returns>New calendar with added months and years.</returns>
      public Calendar Add(int monthCount, int yearCount)
      {
         return new Calendar(this.Add(monthCount).Month, this.Year + yearCount);
      }
   }
}
