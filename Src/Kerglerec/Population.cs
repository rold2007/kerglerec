// <copyright file="Population.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>
namespace Kerglerec
{
   using System;
   using Shouldly;

   /// <summary>
   /// Manages population count.
   /// </summary>
   public sealed record Population
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Population"/> class.
      /// </summary>
      /// <param name="adults">Initial adults count.</param>
      public Population(int adults = 0)
      {
         adults.ShouldBeGreaterThanOrEqualTo(0);

         this.Adults = adults;
      }

      /// <summary>
      /// Gets the adults count.
      /// </summary>
      public int Adults
      {
         get;
      }

      /// <summary>
      /// Add adults to the population count.
      /// </summary>
      /// <param name="adults">Adults to add.</param>
      /// <returns>New population with added adults.</returns>
      public Population Add(int adults)
      {
         adults.ShouldBeGreaterThanOrEqualTo(0);

         int newAdultsPopulation = this.Adults + adults;

         return new Population(newAdultsPopulation);
      }

      /// <summary>
      /// Add population.
      /// </summary>
      /// <param name="population">Population to add.</param>
      /// <returns>New population with added adults.</returns>
      public Population Add(Population population)
      {
         if (population == null)
         {
            throw new ArgumentNullException(nameof(population));
         }

         return this.Add(population.Adults);
      }

      /// <summary>
      /// Remove adults from the population count.
      /// </summary>
      /// <param name="adults">Adults to remove.</param>
      /// <returns>New population with removed adults.</returns>
      public Population Remove(int adults)
      {
         adults.ShouldBeGreaterThanOrEqualTo(0);

         int newAdultsPopulation = this.Adults - adults;

         newAdultsPopulation.ShouldBeGreaterThanOrEqualTo(0);

         return new Population(newAdultsPopulation);
      }

      /// <summary>
      /// Remove population.
      /// </summary>
      /// <param name="population">Population to remove.</param>
      /// <returns>New population with removed adults.</returns>
      public Population Remove(Population population)
      {
         if (population == null)
         {
            throw new ArgumentNullException(nameof(population));
         }

         return this.Remove(population.Adults);
      }
   }
}
