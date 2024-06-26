// <copyright file="Land.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

using System;
using Shouldly;

namespace Kerglerec
{
   public sealed record Land // ncrunch: no coverage
   {
      public Land() : this(0, 0)
      {
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

      public Land ImproveAgricultureLevel(int value)
      {
         value.ShouldBePositive();

         return new Land(Math.Min(AgricultureLevel + value, 100), StructureLevel);
      }

      public Land ImproveStructureLevel(int value)
      {
         value.ShouldBePositive();

         return new Land(AgricultureLevel, Math.Min(StructureLevel + value, 100));
      }
   }
}