// <copyright file="World.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System.Collections.Generic;

   /// <summary>
   /// Class which represent the whole world.
   /// </summary>
   public class World
   {
      private HashSet<Province> provinces;
      private Calendar calendar;

      /// <summary>
      /// Initializes a new instance of the <see cref="World"/> class.
      /// </summary>
      public World()
      {
         this.provinces = new HashSet<Province>();
         this.calendar = Calendar.Empty;
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
      public void Add(Province province)
      {
         this.provinces.Add(province);
      }

      /// <summary>
      /// Advance world time one step.
      /// </summary>
      public void Tick()
      {
         this.calendar = this.calendar.Add(1);

         foreach (Province province in this.provinces)
         {
            Harvest harvest = new Harvest();
            BirthControl birthControl = BirthControl.Empty;
            Granary granary = new Granary();
            Starvation starvation = new Starvation();

            Food foodProduction = harvest.FoodProduction(this.calendar, province);

            province.Add(foodProduction);

            Population populationFlow = birthControl.PopulationFlow(this.calendar, province);

            province.Add(populationFlow);

            Food foodConsumption = granary.FoodConsumption(this.calendar, province);

            province.Remove(foodConsumption);

            Population deathByStarvation = starvation.Death(province, foodConsumption);

            province.Remove(deathByStarvation);
         }
      }
   }
}
