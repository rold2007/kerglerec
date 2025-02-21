// <copyright file="ProvinceTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using Shouldly;
   using Xunit;

   public class LandTests
   {
      [Fact]
      public void ConstructorTest()
      {
         Land land = new();

         land.AgricultureLevel.ShouldBe(0);
         land.StructureLevel.ShouldBe(0);
      }

      [Fact]
      public void ImproveAgricultureLevelTest()
      {
         Land land = new();

         land = land.ImproveAgricultureLevel(10);
         land.AgricultureLevel.ShouldBe(10);
      }

      [Fact]
      public void ImproveStructureLevelTest()
      {
         Land land = new();

         land = land.ImproveStructureLevel(10);
         land.StructureLevel.ShouldBe(10);

      }
   }
}
