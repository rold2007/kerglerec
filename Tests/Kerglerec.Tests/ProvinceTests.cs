// <copyright file="ProvinceTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using Shouldly;
   using Xunit;

   /// <summary>
   /// Contains tests for the Province class.
   /// </summary>
   public class ProvinceTests
   {
      /// <summary>
      /// Tests the Province constructor.
      /// </summary>
      [Fact]
      public void ConstructorTest()
      {
         Province province = new Province();

         province.Population.Adults.ShouldBe(0);
      }

      /// <summary>
      /// Tests the Province::Add() method.
      /// </summary>
      [Fact]
      public void AddTest()
      {
         Population population = Population.Empty.Add(42);
         Province province = new Province();

         province.Add(population);

         province.Population.Adults.ShouldBe(42);

         Food food = Food.Empty;

         food = food.Add(42);

         province.Food.Rice.ShouldBe(0);

         province.Add(food);

         province.Food.Rice.ShouldBe(42);
      }
   }
}
