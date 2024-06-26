﻿// <copyright file="WorldTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System.Collections.Generic;
   using System.Linq;
   using Shouldly;
   using Xunit;

   public class WorldTests
   {
      [Fact]
      public void AddTest()
      {
         World world = new World();
         Province province = new Province();

         world.Provinces.Count.ShouldBe(0);

         world = world.Add(province);

         world.Provinces.Count.ShouldBe(1);
         world.Provinces.ShouldContain(province);
      }

      [Fact]
      public void TickTest()
      {
         World world = new World();
         Province province = new Province();
         Population population = new Population().Add(1000);
         Food food = new Food();

         food = food.Add(12000);

         province = province.Update(province.Population.Add(population));
         province = province.Update(province.Food.Add(food));

         world = world.Add(province);

         for (int month = 0; month < 12; month++)
         {
            world = world.Tick();
         }

         province = world.Provinces.Single();
         province.Population.Adults.ShouldBeGreaterThan(population.Adults);
         province.Food.Rice.ShouldBeGreaterThan(food.Rice);
      }

      [Fact]
      public void IntegrationTest()
      {
         const int provincesCount = 4;
         const int initialPopulation = 1000;
         const int initialRice = 12000;
         World world = new World();

         for (int i = 0; i < provincesCount; i++)
         {
            Province province = new Province();
            Population population = new Population().Add(initialPopulation);
            Food food = new Food();

            food = food.Add(initialRice);

            province = province.Update(province.Population.Add(population));
            province = province.Update(province.Food.Add(food));
            world = world.Add(province);
         }

         for (int month = 0; month < 24; month++)
         {
            world = world.Tick();

            world = world.Add(new PlayerAction());
         }

         world.Provinces.Count().ShouldBe(provincesCount);

         foreach (Province province in world.Provinces)
         {
            province.Population.Adults.ShouldBeGreaterThan(initialPopulation);
            province.Food.Rice.ShouldBeGreaterThan(initialRice);
         }
      }
   }
}
