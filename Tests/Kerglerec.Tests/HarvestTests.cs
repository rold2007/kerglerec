// <copyright file="HarvestTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   public class HarvestTests
   {
      [Fact]
      public void FoodProductionTest()
      {
         Harvest harvest = new Harvest();
         Calendar calendar = new Calendar();
         Province province = new Province();
         Population startPopulation = new Population().Add(1000);

         Food food = harvest.FoodProduction(calendar, province);

         food.Rice.ShouldBe(0);

         province = province.Add(startPopulation);

         calendar.Month.ShouldBe(Month.January);
         food = harvest.FoodProduction(calendar, province);
         food.Rice.ShouldBe(0);

         calendar = calendar.Add(4);
         food = harvest.FoodProduction(calendar, province);
         food.Rice.ShouldBeGreaterThan(0);

         calendar = new Calendar();
         calendar.Month.ShouldBe(Month.January);
         food = new Food();
         food.Rice.ShouldBe(0);

         for (int month = 0; month < 12; month++)
         {
            food = food.Add(harvest.FoodProduction(calendar, province));
            calendar = calendar.Add(1);
         }

         food.Rice.ShouldBeGreaterThan(12 * province.Population.Adults);
      }

      [Fact]
      public void FoodProductionParameterTest()
      {
         Harvest harvest = new Harvest();

         Should.Throw<ArgumentNullException>(() => { harvest.FoodProduction(null, null); }).Message.ShouldContain("calendar");

         Should.Throw<ArgumentNullException>(() => { harvest.FoodProduction(new Calendar(), null); }).Message.ShouldContain("province");
      }
   }
}
