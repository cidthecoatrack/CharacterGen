﻿using System;
using System.Linq;
using NPCGen.Common.Alignments;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Generators.Randomizers.Races.BaseRaces
{
    public class NonEvilBaseRaceRandomizer : BaseBaseRace
    {
        private ICollectionsSelector collectionsSelector;

        public NonEvilBaseRaceRandomizer(IPercentileSelector percentileResultSelector, IAdjustmentsSelector levelAdjustmentSelector, ICollectionsSelector collectionsSelector)
            : base(percentileResultSelector, levelAdjustmentSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        protected override Boolean BaseRaceIsAllowed(String baseRace)
        {
            var evilBaseRaces = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.Names,
                AlignmentConstants.Evil);
            var goodBaseRaces = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.Names,
                AlignmentConstants.Good);
            var neutralBaseRaces = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.Names,
                AlignmentConstants.Neutral);
            var forbiddenBaseRaces = evilBaseRaces.Except(neutralBaseRaces).Except(goodBaseRaces);

            return !forbiddenBaseRaces.Contains(baseRace);
        }
    }
}