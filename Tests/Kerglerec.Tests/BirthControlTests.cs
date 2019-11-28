// <copyright file="BirthControlTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   /// <summary>
   /// Contains tests for the BirthControl class.
   /// </summary>
   public class BirthControlTests
   {
      /// <summary>
      /// Test the BirthControl class.
      /// </summary>
      [Fact]
      public void ConstructorTest()
      {
         BirthControl birthControl = new BirthControl();
      }

      /// <summary>
      /// Test the ComputePopulationChange method.
      /// </summary>
      [Fact]
      public void ComputePopulationChangeTest()
      {
         const int startPopulation = 1000;
         BirthControl birthControl = new BirthControl();
         Calendar calendar = new Calendar();
         Province province = new Province();

         province.Add(startPopulation);

         for (int i = 0; i < 12; i++)
         {
            calendar.Add(1);

            birthControl.ComputePopulationChange(calendar, province);
         }

         province.Population.ShouldBeGreaterThan(startPopulation);
         province.Population.ShouldBeLessThan(2 * startPopulation);
      }

      /// <summary>
      /// Test the ComputePopulationChange method with invalid parameters.
      /// </summary>
      [Fact]
      public void ComputePopulationChangeParameterTest()
      {
         BirthControl birthControl = new BirthControl();

         Should.Throw<ArgumentNullException>(() => { birthControl.ComputePopulationChange(null, null); }).Message.ShouldContain("calendar");

         Should.Throw<ArgumentNullException>(() => { birthControl.ComputePopulationChange(new Calendar(), null); }).Message.ShouldContain("province");
      }
   }
}
