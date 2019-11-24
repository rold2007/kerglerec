// <copyright file="CalendarTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using System.Collections.Generic;
   using System.Text;
   using Shouldly;
   using Xunit;

   /// <summary>
   /// Contains tests for the Calendar class.
   /// </summary>
   public class CalendarTests
   {
      /// <summary>
      /// Test the Calendar constructor.
      /// </summary>
      [Fact]
      public void ConstructorTest()
      {
         Calendar calendar = new Calendar();

         calendar.Month.ShouldBe(1);
      }

      /// <summary>
      /// Test the Calendar::Add() method.
      /// </summary>
      [Fact]
      public void AddTest()
      {
         Calendar calendar = new Calendar();

         calendar.Add(1);

         calendar.Month.ShouldBe(2);

         calendar.Add(13);

         calendar.Month.ShouldBe(3);
      }
   }
}
