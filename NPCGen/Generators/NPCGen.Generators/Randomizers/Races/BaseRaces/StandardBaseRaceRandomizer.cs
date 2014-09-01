﻿using System;
using System.Linq;
using NPCGen.Selectors.Interfaces;

namespace NPCGen.Generators.Randomizers.Races.BaseRaces
{
    public class StandardBaseRaceRandomizer : BaseBaseRace
    {
        private ICollectionsSelector collectionsSelector;

        public StandardBaseRaceRandomizer(IPercentileSelector percentileResultSelector, IAdjustmentsSelector levelAdjustmentSelector, ICollectionsSelector collectionsSelector)
            : base(percentileResultSelector, levelAdjustmentSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        protected override Boolean BaseRaceIsAllowed(String baseRace)
        {
            var baseRaces = collectionsSelector.SelectFrom("BaseRaceGroups", "Standard");
            return baseRaces.Contains(baseRace);
        }
    }
}