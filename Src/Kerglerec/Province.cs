// <copyright file="Province.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   /// <summary>
   /// Manages the characteristics of a province.
   /// </summary>
   public class Province
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Province"/> class.
      /// </summary>
      public Province()
      {
         this.Population = 0;
      }

      /// <summary>
      ///  Gets the population for the province.
      /// </summary>
      public int Population
      {
         get;
         private set;
      }

      /// <summary>
      /// Add population to the province.
      /// </summary>
      /// <param name="population">Population to add.</param>
      public void Add(int population)
      {
         this.Population += population;
      }
   }
}
