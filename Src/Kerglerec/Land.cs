// <copyright file="Land.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

using System;
using Shouldly;

namespace Kerglerec
{
   public sealed record Land
   {
      public Land()
      {
         AgricultureLevel = 0;
         StructureLevel = 0;
      }

      private Land(int agricultureLevel, int structureLevel)
      {
         AgricultureLevel = agricultureLevel;
         StructureLevel = structureLevel;
      }

      public int AgricultureLevel
      {
         get;
         private set;
      }

      public int StructureLevel
      {
         get;
         private set;
      }

      Land ImproveAgricultureLevel(int value)
      {
         value.ShouldBePositive();

         return new Land(Math.Min(AgricultureLevel + value, 100), StructureLevel);
      }

      Land ImproveStructureLevel(int value)
      {
         value.ShouldBePositive();

         return new Land(AgricultureLevel, Math.Min(StructureLevel + value, 100));
      }
   }
}