// <copyright file="World.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System.Collections.Generic;
   using System.Collections.Immutable;
   using System.Linq;

   /// <summary>
   /// Class which represent the whole world.
   /// </summary>
   public sealed class World
   {
      private static readonly World EmptyWorld = new World(ImmutableHashSet<Province>.Empty, Calendar.Empty);

      private ImmutableHashSet<Province> provinces;
      private Calendar calendar;

      /// <summary>
      /// Initializes a new instance of the <see cref="World"/> class.
      /// </summary>
      private World(ImmutableHashSet<Province> provinces, Calendar calendar)
      {
         this.provinces = provinces;
         this.calendar = calendar;
      }

      /// <summary>
      /// Gets an empty world.
      /// </summary>
      public static World Empty
      {
         get
         {
            return EmptyWorld;
         }
      }

      /// <summary>
      /// Gets all the provinces in the world.
      /// </summary>
      public IReadOnlyCollection<Province> Provinces
      {
         get
         {
            return this.provinces;
         }
      }

      /// <summary>
      /// Add a province to the world.
      /// </summary>
      /// <param name="province">Province to add.</param>
      /// <returns>New world with added provinces.</returns>
      public World Add(Province province)
      {
         return new World(this.provinces.Add(province), this.calendar);
      }

      /// <summary>
      /// Advance world time one step.
      /// </summary>
      /// <returns>New world with updated time frame.</returns>
      public World Tick()
      {
         Calendar calendar = this.calendar.Add(1);

         ImmutableHashSet<Province> provinces = this.provinces.Select(province =>
         {
            Harvest harvest = Harvest.Empty;
            BirthControl birthControl = BirthControl.Empty;
            Granary granary = Granary.Empty;
            Starvation starvation = Starvation.Empty;

            Food foodProduction = harvest.FoodProduction(this.calendar, province);

            province = province.Add(foodProduction);

            Population populationFlow = birthControl.PopulationFlow(this.calendar, province);

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
