// <copyright file="Calendar.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   public sealed record Calendar
   {
      public Calendar() : this(Month.January, 1)
      {
      }

      private Calendar(Month month, int year)
      {
         Month = month;
         Year = year;
      }

      public Month Month
      {
         get;
         private set;
      }

      public int Year
      {
         get;
         private set;
      }

      public Calendar Add(int monthCount)
      {
         int month = (int)Month + monthCount;

         return new Calendar((Kerglerec.Month)(month % 12), Year);
      }

      public Calendar Add(int monthCount, int yearCount)
      {
         return new Calendar(Add(monthCount).Month, Year + yearCount);
      }
   }
}
