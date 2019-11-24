// <copyright file="Calendar.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;
   using System.Collections.Generic;
   using System.Text;

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
      /// Advance time by X months.
      /// </summary>
      /// <param name="monthCount">Months to add.</param>
      public void Add(int monthCount)
      {
         int month = this.Month + monthCount;

         this.Month = month % 12;
      }
   }
}
