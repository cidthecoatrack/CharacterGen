﻿using System;
using NPCGen.Generators.Providers.Interfaces;

namespace NPCGen.Generators.Randomizers.Races.BaseRaces
{
    public class AnyBaseRaceRandomizer : BaseBaseRace
    {
        public AnyBaseRaceRandomizer(IPercentileResultProvider percentileResultProvider, ILevelAdjustmentsProvider levelAdjustmentProvider)
            : base(percentileResultProvider, levelAdjustmentProvider) { }

        protected override Boolean BaseRaceIsAllowed(String baseRace)
        {
            return true;
        }
    }
}