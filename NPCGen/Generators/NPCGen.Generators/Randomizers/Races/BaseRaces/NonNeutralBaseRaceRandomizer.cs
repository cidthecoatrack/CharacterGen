﻿using System;
using System.Linq;
using NPCGen.Common.Alignments;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Generators.Randomizers.Races.BaseRaces
{
    public class NonNeutralBaseRaceRandomizer : BaseBaseRace
    {
        private ICollectionsSelector collectionsSelector;

        public NonNeutralBaseRaceRandomizer(IPercentileSelector percentileResultSelector, IAdjustmentsSelector levelAdjustmentSelector, INameSelector nameSelector,
            ICollectionsSelector collectionsSelector)
            : base(percentileResultSelector, levelAdjustmentSelector, nameSelector)
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
            var forbiddenBaseRaces = neutralBaseRaces.Except(goodBaseRaces).Except(evilBaseRaces);

            return !forbiddenBaseRaces.Contains(baseRace);
        }
    }
}