﻿// <copyright file="Province.cs" company="David Rolland">
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
         this.Population = new Population();
         this.Food = new Food();
      }

      /// <summary>
      ///  Gets the population for the province.
      /// </summary>
      public Population Population
      {
         get;
         private set;
      }

      /// <summary>
      /// Gets the food for the province.
      /// </summary>
      public Food Food
      {
         get;
         private set;
      }

      /// <summary>
      /// Add population to the province.
      /// </summary>
      /// <param name="population">Population to add.</param>
      public void Add(Population population)
      {
         this.Population.Add(population);
      }

      /// <summary>
      /// Add food to the province.
      /// </summary>
      /// <param name="food">Food to add.</param>
      public void Add(Food food)
      {
         this.Food.Add(food);
      }
   }
}