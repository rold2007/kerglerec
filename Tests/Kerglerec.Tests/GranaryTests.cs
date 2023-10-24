// <copyright file="GranaryTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   public class GranaryTests
   {
      [Fact]
      public void FoodConsumptionTest()
      {
         Granary granary = new Granary();
         Calendar calendar = new Calendar();
         Province province = new Province();
         Population startPopulation = new Population().Add(1000);
         Food foodStock = new Food();

         foodStock = foodStock.Add(500);

         Food foodConsumption = granary.FoodConsumption(calendar, province);

         foodConsumption.Rice.ShouldBe(0);

         province = province.Add(startPopulation);
         province = province.Add(foodStock);

         calendar.Month.ShouldBe(Month.January);
         foodConsumption = granary.FoodConsumption(calendar, province);
         foodConsumption.Rice.ShouldNotBe(0);
         foodConsumption.Rice.ShouldBeLessThanOrEqualTo(province.Food.Rice);

         calendar.Add(4);
         foodConsumption = granary.FoodConsumption(calendar, province);
         foodConsumption.Rice.ShouldBeGreaterThan(0);
         foodConsumption.Rice.ShouldBeLessThanOrEqualTo(province.Food.Rice);

         calendar = new Calendar();

         calendar.Month.ShouldBe(Month.January);

         foodConsumption = new Food();

         foodConsumption.Rice.ShouldBe(0);

         foodStock = foodStock.Add(50000);
         province = province.Add(foodStock);

         for (int month = 0; month < 12; month++)
         {
            foodConsumption = foodConsumption.Add(granary.FoodConsumption(calendar, province));
            calendar.Add(1);
         }

         foodConsumption.Rice.ShouldBeGreaterThan(12 * province.Population.Adults);
         foodConsumption.Rice.ShouldBeLessThanOrEqualTo(province.Food.Rice);
      }

      [Fact]
      public void FoodConsumptionParameterTest()
      {
         Granary granary = new Granary();

         Should.Throw<ArgumentNullException>(() => { granary.FoodConsumption(null, null); }).Message.ShouldContain("calendar");

         Should.Throw<ArgumentNullException>(() => { granary.FoodConsumption(new Calendar(), null); }).Message.ShouldContain("province");
      }
   }
}
