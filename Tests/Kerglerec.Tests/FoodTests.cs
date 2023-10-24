// <copyright file="FoodTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   public class FoodTests
   {
      [Fact]
      public void ConstructorTest()
      {
         Food food = new Food();

         food.Rice.ShouldBe(0);
      }

      [Fact]
      public void AddTest()
      {
         Food food = new Food();

         food = food.Add(42);

         food.Rice.ShouldBe(42);

         Food foodAdd = new Food();

         foodAdd = foodAdd.Add(54);

         food = food.Add(foodAdd);

         food.Rice.ShouldBe(96);
         foodAdd.Rice.ShouldBe(54);
      }

      [Fact]
      public void AddParameterTest()
      {
         Food food = new Food();

         Should.Throw<ArgumentNullException>(() => { food.Add(null); }).Message.ShouldContain("food");
      }

      [Fact]
      public void RemoveTest()
      {
         Food food = new Food();
         Food foodToRemove = new Food();

         food = food.Add(42);
         foodToRemove = foodToRemove.Add(30);
         food = food.Remove(foodToRemove);

         food.Rice.ShouldBe(12);
      }

      [Fact]
      public void RemoveParameterTest()
      {
         Food food = new Food();

         Should.Throw<ArgumentNullException>(() => { food.Remove(null); }).Message.ShouldContain("food");

         Food foodToRemove = new Food();

         foodToRemove = foodToRemove.Add(1);

         Should.Throw<ArgumentOutOfRangeException>(() => { food.Remove(foodToRemove); }).Message.ShouldContain("food");
      }
   }
}
