// <copyright file="PopulationTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   /// <summary>
   /// Contains tests for the Population class.
   /// </summary>
   public class PopulationTests
   {
      /// <summary>
      /// Tests the Population constructor.
      /// </summary>
      [Fact]
      public void ConstructorTest()
      {
         Population population = Population.Empty;

         population.Adults.ShouldBe(0);
      }

      /// <summary>
      /// Tests the Population::Add method.
      /// </summary>
      [Fact]
      public void AddTest()
      {
         Population population = Population.Empty.Add(42);

         population.Adults.ShouldBe(42);

         Population populationAdd = Population.Empty.Add(54);

         population = population.Add(populationAdd);

         population.Adults.ShouldBe(96);
         populationAdd.Adults.ShouldBe(54);
      }

      /// <summary>
      /// Test the Population::Add() method with invalid parameter.
      /// </summary>
      [Fact]
      public void AddParameterTest()
      {
         Population population = Population.Empty;

         Should.Throw<ArgumentNullException>(() => { population.Add(null); }).Message.ShouldContain("population");
      }

      /// <summary>
      /// Tests the Population::Remove method.
      /// </summary>
      [Fact]
      public void RemoveTest()
      {
         Population population = Population.Empty.Add(42);
         Population populationToRemove = Population.Empty.Add(30);

         population = population.Remove(populationToRemove);
         population.Adults.ShouldBe(12);
      }

      /// <summary>
      /// Test the Population::Remove() method with invalid parameter.
      /// </summary>
      [Fact]
      public void RemoveParameterTest()
      {
         Population population = Population.Empty;

         Should.Throw<ArgumentNullException>(() => { population.Remove(null); }).Message.ShouldContain("population");

         Population populationToRemove = Population.Empty.Add(1);

         Should.Throw<Shouldly.ShouldAssertException>(() => { population.Remove(populationToRemove); }).Message.ShouldContain("population");
      }
   }
}
