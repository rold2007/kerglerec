﻿// <copyright file="GranaryTests.cs" company="David Rolland">
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
   /// Contains tests for the Granary class.
   /// </summary>
   public class GranaryTests
   {
      /// <summary>
      /// Tests the Granary::FoodConsumption method.
      /// </summary>
      [Fact]
      public void FoodConsumptionTest()
      {
         Granary granary = new Granary();
         Calendar calendar = new Calendar();
         Province province = new Province();
         Population startPopulation = new Population();
         Food foodStock = new Food();

         foodStock.Add(500);

         Food foodConsumption = granary.FoodConsumption(calendar, province);

         foodConsumption.Rice.ShouldBe(0);

         startPopulation.Add(1000);
         province.Add(startPopulation);
         province.Add(foodStock);

         calendar.Month.ShouldBe(1);
         foodConsumption = granary.FoodConsumption(calendar, province);
         foodConsumption.Rice.ShouldNotBe(0);
         foodConsumption.Rice.ShouldBeLessThanOrEqualTo(province.Food.Rice);

         calendar.Add(4);
         foodConsumption = granary.FoodConsumption(calendar, province);
         foodConsumption.Rice.ShouldBeGreaterThan(0);
         foodConsumption.Rice.ShouldBeLessThanOrEqualTo(province.Food.Rice);

         calendar = new Calendar();

         calendar.Month.ShouldBe(1);

         foodConsumption = new Food();

         foodConsumption.Rice.ShouldBe(0);

         foodStock.Add(50000);
         province.Add(foodStock);

         for (int month = 0; month < 12; month++)
         {
            foodConsumption.Add(granary.FoodConsumption(calendar, province));
            calendar.Add(1);
         }

         foodConsumption.Rice.ShouldBeGreaterThan(12 * province.Population.Adult);
         foodConsumption.Rice.ShouldBeLessThanOrEqualTo(province.Food.Rice);
      }

      /// <summary>
      /// Tests the Harvest::FoodProduction method with invalid parameters.
      /// </summary>
      [Fact]
      public void FoodConsumptionParameterTest()
      {
         Granary granary = new Granary();

         Should.Throw<ArgumentNullException>(() => { granary.FoodConsumption(null, null); }).Message.ShouldContain("calendar");

         Should.Throw<ArgumentNullException>(() => { granary.FoodConsumption(new Calendar(), null); }).Message.ShouldContain("province");
      }
   }
}
