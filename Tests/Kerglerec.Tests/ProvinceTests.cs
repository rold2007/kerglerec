// <copyright file="ProvinceTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using Shouldly;
   using Xunit;

   public class ProvinceTests
   {
      [Fact]
      public void ConstructorTest()
      {
         Province province = new Province();

         province.Population.Adults.ShouldBe(0);
      }

      [Fact]
      public void AddTest()
      {
         Population population = new Population().Add(42);
         Province province = new Province();

         province = province.Add(population);

         province.Population.Adults.ShouldBe(42);

         Food food = new Food();

         food = food.Add(42);

         province.Food.Rice.ShouldBe(0);

         province = province.Add(food);

         province.Food.Rice.ShouldBe(42);
      }
   }
}
