﻿// <copyright file="Province.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   /// <summary>
   /// Manages the characteristics of a province.
   /// </summary>
   public sealed record Province
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Province"/> class.
      /// </summary>
      public Province()
            : this(new Population(), new Food())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="Province"/> class.
      /// </summary>
      /// <param name="population">Population for the province.</param>
      /// <param name="food">Food for the province.</param>
      public Province(Population population, Food food)
      {
         this.Population = population;
         this.Food = food;
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
      /// <returns>New province with added population.</returns>
      public Province Add(Population population)
      {
         return new Province(this.Population.Add(population), this.Food);
      }

      /// <summary>
      /// Add food to the province.
      /// </summary>
      /// <param name="food">Food to add.</param>
      /// <returns>New province with added food.</returns>
      public Province Add(Food food)
      {
         return new Province(this.Population, this.Food.Add(food));
      }

      /// <summary>
      /// Remove food from the province.
      /// </summary>
      /// <param name="food">Food to remove.</param>
      /// <returns>New province with removed food.</returns>
      public Province Remove(Food food)
      {
         return new Province(this.Population, this.Food.Remove(food));
      }

      /// <summary>
      /// Remove the population from the province.
      /// </summary>
      /// <param name="population">Population to remove.</param>
      /// <returns>New province with removed population.</returns>
      public Province Remove(Population population)
      {
         return new Province(this.Population.Remove(population), this.Food);
      }
   }
}
