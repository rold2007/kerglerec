// <copyright file="BirthTests.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec.Tests
{
   using System;
   using Shouldly;
   using Xunit;

   /// <summary>
   /// Contains tests for the Birth class.
   /// </summary>
   public class BirthTests
   {
      /// <summary>
      /// Tests the Birth::PopulationChange method.
      /// </summary>
      [Fact]
      public void PopulationChangeTest()
      {
         Population startPopulation = new Population().Add(1000);
         Birth birth = new Birth();
         Calendar calendar = new Calendar();
         Province province = new Province();

         province = province.Add(startPopulation);

         Population populationFlow = new Population();

         for (int i = 0; i < 12; i++)
         {
            calendar.Add(1);

            populationFlow = populationFlow.Add(birth.PopulationFlow(calendar, province));
         }

         populationFlow.Adults.ShouldBeGreaterThan(0);
         populationFlow.Adults.ShouldBeLessThan(startPopulation.Adults);
      }

      /// <summary>
      /// Tests the Birth::PopulationChange method with invalid parameters.
      /// </summary>
      [Fact]
      public void PopulationChangeParameterTest()
      {
         Birth birth = new Birth();

         Should.Throw<ArgumentNullException>(() => { birth.PopulationFlow(null, null); }).Message.ShouldContain("calendar");

         Should.Throw<ArgumentNullException>(() => { birth.PopulationFlow(new Calendar(), null); }).Message.ShouldContain("province");
      }
   }
}
