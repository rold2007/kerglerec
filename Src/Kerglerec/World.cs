// <copyright file="World.cs" company="David Rolland">
// Copyright (c) David Rolland. All rights reserved.
// </copyright>

namespace Kerglerec
{
   using System.Collections.Generic;
   using System.Collections.Immutable;
   using System.Linq;

   // TODO Add actions per province so that basic a AI can be built
   public sealed record World
   {
      private ImmutableList<Province> provinces;
      private Calendar calendar;
      private ImmutableList<PlayerAction> playerActions;

      public World()
            : this(
               ImmutableList<Province>.Empty,
               new Calendar(),
               ImmutableList<PlayerAction>.Empty)
      {
      }

      private World(ImmutableList<Province> provinces, Calendar calendar, ImmutableList<PlayerAction> playerActions)
      {
         this.provinces = provinces;
         this.calendar = calendar;
         this.playerActions = playerActions;
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
         return new World(provinces.Add(province), calendar, playerActions);
      }

      public World Add(PlayerAction playerAction)
      {
         return new World(provinces, calendar, playerActions.Add(playerAction));
      }

      public World Tick()
      {
         Calendar calendar = this.calendar.Add(1);

         playerActions.ForEach(p => ProcessPlayerAction(p));
         playerActions.Clear();

         ImmutableList<Province> provinces = this.provinces.Select(province =>
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
         }).ToImmutableList<Province>();

         return new World(provinces, calendar, playerActions);
      }

      public void ProcessPlayerAction(PlayerAction playerAction)
      {
         // UNDONE The action needs a unique ID on the province to apply the action
         // UNDONE There should be one player action class for each time of
      }
   }
}
