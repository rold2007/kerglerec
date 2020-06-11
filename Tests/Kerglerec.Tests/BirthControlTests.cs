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
      /// Tests the BirthControl::PopulationChange method.
      /// </summary>
      [Fact]
      public void PopulationChangeTest()
      {
         Population startPopulation = Population.Empty.Add(1000);
         BirthControl birthControl = new BirthControl();
         Calendar calendar = new Calendar();
         Province province = new Province();

         province.Add(startPopulation);

         Population populationFlow = Population.Empty;

         for (int i = 0; i < 12; i++)
         {
            calendar.Add(1);

            populationFlow = populationFlow.Add(birthControl.PopulationFlow(calendar, province));
         }

         populationFlow.Adults.ShouldBeGreaterThan(0);
         populationFlow.Adults.ShouldBeLessThan(startPopulation.Adults);
      }

      /// <summary>
      /// Tests the BirthControl::PopulationChange method with invalid parameters.
      /// </summary>
      [Fact]
      public void PopulationChangeParameterTest()
      {
         BirthControl birthControl = new BirthControl();

         Should.Throw<ArgumentNullException>(() => { birthControl.PopulationFlow(null, null); }).Message.ShouldContain("calendar");

         Should.Throw<ArgumentNullException>(() => { birthControl.PopulationFlow(new Calendar(), null); }).Message.ShouldContain("province");
      }
   }
}
