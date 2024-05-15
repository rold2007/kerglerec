// <copyright file="Population.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>
namespace Kerglerec
{
   using System;
   using Shouldly;

   public sealed record Population // ncrunch: no coverage
   {
      public Population() : this(0)
      {
      }

      private Population(int adults)
      {
         adults.ShouldBeGreaterThanOrEqualTo(0);

         Adults = adults;
      }

      public int Adults
      {
         get;
      }

      public Population Add(int adults)
      {
         adults.ShouldBeGreaterThanOrEqualTo(0);

         int newAdultsPopulation = Adults + adults;

         return new Population(newAdultsPopulation);
      }

      public Population Add(Population population)
      {
         if (population == null)
         {
            throw new ArgumentNullException(nameof(population));
         }

         return Add(population.Adults);
      }

      public Population Remove(int adults)
      {
         adults.ShouldBeGreaterThanOrEqualTo(0);

         int newAdultsPopulation = Adults - adults;

         newAdultsPopulation.ShouldBeGreaterThanOrEqualTo(0);

         return new Population(newAdultsPopulation);
      }

      public Population Remove(Population population)
      {
         if (population == null)
         {
            throw new ArgumentNullException(nameof(population));
         }

         return Remove(population.Adults);
      }
   }
}
