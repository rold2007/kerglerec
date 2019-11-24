// <copyright file="ProvinceTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   /// <summary>
   /// Contains tests for the Province class.
   /// </summary>
   public class ProvinceTests
   {
      /// <summary>
      /// Test the Province constructor.
      /// </summary>
      [Fact]
      public void ConstructorTest()
      {
         Province province = new Province();

         province.Population.ShouldBe(0);
      }

      /// <summary>
      /// Test the Province::Add() method.
      /// </summary>
      [Fact]
      public void AddTest()
      {
         Province province = new Province();

         province.Add(42);

         province.Population.ShouldBe(42);
      }
   }
}
