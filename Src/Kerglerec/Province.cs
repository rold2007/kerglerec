// <copyright file="Province.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

using System;

namespace Kerglerec
{
   public sealed record Province
   {
      public Province()
            : this(new Population(), new Food(), new Land())
      {
      }

      public Province(Population population, Food food, Land land)
      {
         Population = population;
         Food = food;
         Land = land;
      }

      public Population Population
      {
         get;
         private set;
      }

      public Food Food
      {
         get;
         private set;
      }

      public Land Land
      {
         get;
         private set;
      }

      public Province Add(Population population)
      {
         return new Province(Population.Add(population), Food, Land);
      }

      public Province Add(Food food)
      {
         return new Province(Population, Food.Add(food), Land);
      }

      public Province Remove(Food food)
      {
         return new Province(Population, Food.Remove(food), Land);
      }

      public Province Remove(Population population)
      {
         return new Province(Population.Remove(population), Food, Land);
      }
   }
}
