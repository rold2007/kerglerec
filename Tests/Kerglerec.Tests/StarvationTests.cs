// <copyright file="StarvationTests.cs" company="David Rolland">
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
   /// Contains tests for the Starvation class.
   /// </summary>
   public class StarvationTests
   {
      /// <summary>
      /// Tests the Starvation::Death method.
      /// </summary>
      [Fact]
      public void DeathTest()
      {
         Starvation starvation = Starvation.Empty;
         Province province = Province.Empty;
         Food food = Food.Empty;
         Population population = Population.Empty.Add(1000);

         Population deathByStarvation = starvation.Death(province, food);

         deathByStarvation.Adults.ShouldBe(0);

         province = province.Add(population);

         deathByStarvation = starvation.Death(province, food);

         deathByStarvation.Adults.ShouldBeGreaterThan(0);
      }

      /// <summary>
      /// Test the Starvation::Death() method with invalid parameter.
      /// </summary>
      [Fact]
      public void DeathParameterTest()
      {
         Starvation starvation = Starvation.Empty;
         Province province = Province.Empty;
         Food food = Food.Empty;

         Should.Throw<ArgumentNullException>(() => { starvation.Death(null, food); }).Message.ShouldContain("province");

         Should.Throw<ArgumentNullException>(() => { starvation.Death(province, null); }).Message.ShouldContain("food");
      }
   }
}
