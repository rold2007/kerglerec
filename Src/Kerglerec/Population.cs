// <copyright file="Population.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;
   using System.Collections.Generic;
   using System.Text;

   /// <summary>
   /// Manages population count.
   /// </summary>
   public class Population
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Population"/> class.
      /// </summary>
      public Population()
      {
         this.Adult = 0;
      }

      /// <summary>
      /// Gets the adults count.
      /// </summary>
      public int Adult
      {
         get;
         private set;
      }

      /// <summary>
      /// Add adults to the population count.
      /// </summary>
      /// <param name="adults">Adults to add.</param>
      public void Add(int adults)
      {
         this.Adult += adults;
      }

      /// <summary>
      /// Add population.
      /// </summary>
      /// <param name="population">Population to add.</param>
      public void Add(Population population)
      {
         if (population == null)
         {
            throw new ArgumentNullException(nameof(population));
         }

         this.Adult += population.Adult;
      }

      /// <summary>
      /// Remove population.
      /// </summary>
      /// <param name="population">Population to remove.</param>
      public void Remove(Population population)
      {
         if (population == null)
         {
            throw new ArgumentNullException(nameof(population));
         }

         if (this.Adult < population.Adult)
         {
            throw new ArgumentOutOfRangeException(nameof(population));
         }

         this.Adult -= population.Adult;
      }
   }
}
