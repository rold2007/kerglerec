﻿// <copyright file="Food.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System;
   using System.Collections.Generic;
   using System.Text;

   /// <summary>
   /// Manages food quantities.
   /// </summary>
   public class Food
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Food"/> class.
      /// </summary>
      public Food()
      {
         this.Rice = 0;
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
      public void Add(int rice)
      {
         this.Rice += rice;
      }

      /// <summary>
      /// Add food.
      /// </summary>
      /// <param name="food">Food to add.</param>
      public void Add(Food food)
      {
         if (food == null)
         {
            throw new ArgumentNullException(nameof(food));
         }

         this.Rice += food.Rice;
      }
   }
}
