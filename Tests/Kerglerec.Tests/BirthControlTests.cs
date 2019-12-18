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
         Population startPopulation = new Population();
         BirthControl birthControl = new BirthControl();
         Calendar calendar = new Calendar();
         Province province = new Province();

         startPopulation.Add(1000);

         province.Add(startPopulation);

         Population populationFlow = new Population();

         for (int i = 0; i < 12; i++)
         {
            calendar.Add(1);

            populationFlow.Add(birthControl.PopulationFlow(calendar, province));
         }

         populationFlow.Adult.ShouldBeGreaterThan(0);
         populationFlow.Adult.ShouldBeLessThan(startPopulation.Adult);
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
