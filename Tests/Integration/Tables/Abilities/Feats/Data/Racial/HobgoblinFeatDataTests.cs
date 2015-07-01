﻿using System;
using NPCGen.Common.Abilities.Feats;
using NPCGen.Common.Abilities.Skills;
using NPCGen.Common.Races;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Feats.Data.Racial
{
    [TestFixture]
    public class HobgoblinFeatDataTests : RacialFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.RACEFeatData, RaceConstants.BaseRaces.HobgoblinId); }
        }

        [TestCase(FeatConstants.DarkvisionId,
            FeatConstants.DarkvisionId,
            "",
            0,
            "",
            0,
            "",
            60)]
        [TestCase(FeatConstants.SkillBonusId,
            FeatConstants.SkillBonusId,
            SkillConstants.MoveSilently,
            0,
            "",
            0,
            "",
            4)]
        public override void Data(String name, String featId, String focus, Int32 frequencyQuantity, String frequencyTimePeriod, Int32 minimumHitDiceRequirement, String sizeRequirement, Int32 strength)
        {
            base.Data(name, featId, focus, frequencyQuantity, frequencyTimePeriod, minimumHitDiceRequirement, sizeRequirement, strength);
        }
    }
}
