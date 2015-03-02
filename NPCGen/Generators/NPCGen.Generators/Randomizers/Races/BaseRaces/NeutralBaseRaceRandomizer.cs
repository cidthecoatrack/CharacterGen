﻿using System;
using System.Linq;
using NPCGen.Common.Alignments;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Generators.Randomizers.Races.BaseRaces
{
    public class NeutralBaseRaceRandomizer : BaseBaseRace
    {
        private ICollectionsSelector collectionsSelector;

        public NeutralBaseRaceRandomizer(IPercentileSelector percentileResultSelector, IAdjustmentsSelector levelAdjustmentSelector, INameSelector nameSelector,
            ICollectionsSelector collectionsSelector)
            : base(percentileResultSelector, levelAdjustmentSelector, nameSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        protected override Boolean BaseRaceIsAllowed(String baseRace)
        {
            var allowedBaseRaces = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.Names,
                AlignmentConstants.Neutral);
            return allowedBaseRaces.Contains(baseRace);
        }
    }
}