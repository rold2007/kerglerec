﻿// <copyright file="CalendarTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using Shouldly;
   using Xunit;

   public class CalendarTests
   {
      [Fact]
      public void AddMonthTest()
      {
         Calendar calendar = new Calendar();

         calendar = calendar.Add(1);

         calendar.Month.ShouldBe(Month.February);

         calendar = calendar.Add(13);

         calendar.Month.ShouldBe(Month.March);
      }

      [Fact]
      public void AddMonthYearTest()
      {
         Calendar calendar = new Calendar();

         calendar = calendar.Add(1, 0);

         calendar.Month.ShouldBe(Month.February);
         calendar.Year.ShouldBe(1);

         calendar = calendar.Add(0, 1);

         calendar.Month.ShouldBe(Month.February);
         calendar.Year.ShouldBe(2);

         calendar = calendar.Add(2, 3);

         calendar.Month.ShouldBe(Month.April);
         calendar.Year.ShouldBe(5);
      }
   }
}
