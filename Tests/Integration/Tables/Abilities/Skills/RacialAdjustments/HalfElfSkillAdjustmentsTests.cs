﻿using System;
using System.Collections.Generic;
using NPCGen.Common.Abilities.Skills;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Skills.RacialAdjustments
{
    [TestFixture]
    public class HalfElfSkillAdjustmentsTests : AdjustmentsTests
    {
        protected override String tableName
        {
            get { return "HalfElfSkillAdjustments"; }
        }

        [TestCase(SkillConstants.Listen, 1)]
        [TestCase(SkillConstants.Search, 1)]
        [TestCase(SkillConstants.Spot, 1)]
        public override void Adjustment(String name, Int32 adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}