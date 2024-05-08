// <copyright file="Province.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   public sealed record Province
   {
      public Province() : this(new Population(), new Food(), new Land())
      {
      }

      private Province(Population population, Food food, Land land)
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

      public Province Update(Population population)
      {
         return new Province(population, Food, Land);
      }

      public Province Update(Food food)
      {
         return new Province(Population, food, Land);
      }

      public Province Update(Land land)
      {
         return new Province(Population, Food, land);
      }
   }
}
