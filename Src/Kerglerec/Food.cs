// <copyright file="Food.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;

   /// <summary>
   /// Manages food quantities.
   /// </summary>
   public sealed record Food
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Food"/> record.
      /// </summary>
      /// <param name="rice">Initial rice quantity.</param>
      public Food(int rice = 0)
      {
         this.Rice = rice;
      }

      /// <summary>
      /// Gets the rice quantities.
      /// </summary>
      public int Rice
      {
         get;
         private set;
      }

      /// <summary>
      /// Add rice to the food quantitites.
      /// </summary>
      /// <param name="rice">Rice to add.</param>
      /// <returns>New food with added rice.</returns>
      public Food Add(int rice)
      {
         return new Food(this.Rice + rice);
      }

      /// <summary>
      /// Add food.
      /// </summary>
      /// <param name="food">Food to add.</param>
      /// <returns>New food with added rice.</returns>
      public Food Add(Food food)
      {
         if (food == null)
         {
            throw new ArgumentNullException(nameof(food));
         }

         return new Food(this.Rice + food.Rice);
      }

      /// <summary>
      /// Remove food.
      /// </summary>
      /// <param name="food">Food to remove.</param>
      /// <returns>New food with removed rice.</returns>
      public Food Remove(Food food)
      {
         if (food == null)
         {
            throw new ArgumentNullException(nameof(food));
         }

         if (this.Rice < food.Rice)
         {
            throw new ArgumentOutOfRangeException(nameof(food));
         }

         return new Food(this.Rice - food.Rice);
      }
   }
}
