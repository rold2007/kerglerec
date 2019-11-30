// <copyright file="FoodTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   /// <summary>
   /// Contains tests for the Food class.
   /// </summary>
   public class FoodTests
   {
      /// <summary>
      /// Tests the Food constructor.
      /// </summary>
      [Fact]
      public void ConstructorTest()
      {
         Food food = new Food();

         food.Rice.ShouldBe(0);
      }

      /// <summary>
      /// Tests the Food::Add() method.
      /// </summary>
      [Fact]
      public void AddTest()
      {
         Food food = new Food();

         food.Add(42);

         food.Rice.ShouldBe(42);

         Food foodAdd = new Food();

         foodAdd.Add(54);

         food.Add(foodAdd);

         food.Rice.ShouldBe(96);
         foodAdd.Rice.ShouldBe(54);
      }

      /// <summary>
      /// Test the Food::Add() method with invalid parameter.
      /// </summary>
      [Fact]
      public void AddParameterTest()
      {
         Food food = new Food();

         Should.Throw<ArgumentNullException>(() => { food.Add(null); }).Message.ShouldContain("food");
      }
   }
}
