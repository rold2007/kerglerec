// <copyright file="Province.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   public sealed record Province
   {
      public Province()
            : this(new Population(), new Food())
      {
      }

      public Province(Population population, Food food)
      {
         Population = population;
         Food = food;
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

      public Province Add(Population population)
      {
         return new Province(Population.Add(population), Food);
      }

      public Province Add(Food food)
      {
         return new Province(Population, Food.Add(food));
      }

      public Province Remove(Food food)
      {
         return new Province(Population, Food.Remove(food));
      }

      public Province Remove(Population population)
      {
         return new Province(Population.Remove(population), Food);
      }
   }
}
