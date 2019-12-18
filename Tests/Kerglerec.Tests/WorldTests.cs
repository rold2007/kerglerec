// <copyright file="WorldTests.cs" company="David Rolland">
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
   /// Contains tests for the World class.
   /// </summary>
   public class WorldTests
   {
      /// <summary>
      /// Tests the World::Add method.
      /// </summary>
      [Fact]
      public void AddTest()
      {
         World world = new World();
         Province province = new Province();

         world.Provinces.Count.ShouldBe(0);

         world.Add(province);

         world.Provinces.Count.ShouldBe(1);
         world.Provinces.ShouldContain(province);
      }

      /// <summary>
      /// Tests the World::Tick method.
      /// </summary>
      [Fact]
      public void TickTest()
      {
         World world = new World();
         Province province = new Province();
         Population population = new Population();
         Food food = new Food();

         population.Add(1000);
         food.Add(12000);

         province.Add(population);
         province.Add(food);

         world.Add(province);

         for (int month = 0; month < 12; month++)
         {
            world.Tick();
         }

         province.Population.Adult.ShouldBeGreaterThan(population.Adult);
         province.Food.Rice.ShouldBeGreaterThan(food.Rice);
      }
   }
}
