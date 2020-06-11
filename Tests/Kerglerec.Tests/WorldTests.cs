// <copyright file="WorldTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
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
         Population population = Population.Empty.Add(1000);
         Food food = new Food();

         food.Add(12000);

         province.Add(population);
         province.Add(food);

         world.Add(province);

         for (int month = 0; month < 12; month++)
         {
            world.Tick();
         }

         province.Population.Adults.ShouldBeGreaterThan(population.Adults);
         province.Food.Rice.ShouldBeGreaterThan(food.Rice);
      }
   }
}
