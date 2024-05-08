// <copyright file="StarvationTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   public class StarvationTests
   {
      [Fact]
      public void DeathTest()
      {
         Starvation starvation = new Starvation();
         Province province = new Province();
         Food food = new Food();
         Population population = new Population().Add(1000);

         Population deathByStarvation = starvation.Death(province, food);

         deathByStarvation.Adults.ShouldBe(0);

         province = province.Update(province.Population.Add(population));

         deathByStarvation = starvation.Death(province, food);

         deathByStarvation.Adults.ShouldBeGreaterThan(0);
      }

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
