// <copyright file="World.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System.Collections.Generic;
   using System.Collections.Immutable;
   using System.Linq;

   public sealed record World
   {
      private ImmutableHashSet<Province> provinces;
      private Calendar calendar;

      public World()
            : this(ImmutableHashSet<Province>.Empty, new Calendar())
      {
      }

      public World(ImmutableHashSet<Province> provinces, Calendar calendar)
      {
         this.provinces = provinces;
         this.calendar = calendar;
      }

      public IReadOnlyCollection<Province> Provinces
      {
         get
         {
            return provinces;
         }
      }

      public World Add(Province province)
      {
         return new World(provinces.Add(province), calendar);
      }

      public World Tick()
      {
         Calendar calendar = this.calendar.Add(1);

         ImmutableHashSet<Province> provinces = this.provinces.Select(province =>
         {
            Harvest harvest = new Harvest();
            Birth birth = new Birth();
            Granary granary = new Granary();
            Starvation starvation = new Starvation();

            Food foodProduction = harvest.FoodProduction(this.calendar, province);

            province = province.Add(foodProduction);

            Population populationFlow = birth.PopulationFlow(this.calendar, province);

            province = province.Add(populationFlow);

            Food foodConsumption = granary.FoodConsumption(this.calendar, province);

            province = province.Remove(foodConsumption);

            Population deathByStarvation = starvation.Death(province, foodConsumption);

            province = province.Remove(deathByStarvation);

            return province;
         }).ToImmutableHashSet();

         return new World(provinces, calendar);
      }
   }
}
