// <copyright file="WorldTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System.Linq;
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
         Province province = Province.Empty;

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
         Province province = Province.Empty;
         Population population = Population.Empty.Add(1000);
         Food food = Food.Empty;

         food = food.Add(12000);

         province = province.Add(population);
         province = province.Add(food);

         world.Add(province);

         for (int month = 0; month < 12; month++)
         {
            world.Tick();
         }

         province = world.Provinces.Single();
         province.Population.Adults.ShouldBeGreaterThan(population.Adults);
         province.Food.Rice.ShouldBeGreaterThan(food.Rice);
      }
   }
}
