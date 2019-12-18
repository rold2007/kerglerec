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
         Starvation starvation = new Starvation();
         Province province = new Province();
         Food food = new Food();
         Population population = new Population();

         Population deathByStarvation = starvation.Death(province, food);

         deathByStarvation.Adult.ShouldBe(0);

         population.Add(1000);
         province.Add(population);

         deathByStarvation = starvation.Death(province, food);

         deathByStarvation.Adult.ShouldBeGreaterThan(0);
      }

      /// <summary>
      /// Test the Starvation::Death() method with invalid parameter.
      /// </summary>
      [Fact]
      public void DeathParameterTest()
      {
         Starvation starvation = new Starvation();
         Province province = new Province();
         Food food = new Food();

         Should.Throw<ArgumentNullException>(() => { starvation.Death(null, food); }).Message.ShouldContain("province");

         Should.Throw<ArgumentNullException>(() => { starvation.Death(province, null); }).Message.ShouldContain("food");
      }
   }
}
