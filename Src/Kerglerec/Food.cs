// <copyright file="Food.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   public sealed record Food // ncrunch: no coverage
   {
      public Food() : this(0)
      {
      }

      private Food(int rice)
      {
         Rice = rice;
      }

      public int Rice
      {
         get;
         private set;
      }

      public Food Add(int rice)
      {
         return new Food(Rice + rice);
      }

      public Food Add(Food food)
      {
         if (food == null)
         {
            throw new ArgumentNullException(nameof(food));
         }

         return new Food(Rice + food.Rice);
      }

      public Food Remove(Food food)
      {
         if (food == null)
         {
            throw new ArgumentNullException(nameof(food));
         }

         if (Rice < food.Rice)
         {
            throw new ArgumentOutOfRangeException(nameof(food));
         }

         return new Food(Rice - food.Rice);
      }
   }
}
