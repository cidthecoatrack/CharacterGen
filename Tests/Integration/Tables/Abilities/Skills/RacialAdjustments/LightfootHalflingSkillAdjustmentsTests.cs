﻿using System;
using System.Collections.Generic;
using NPCGen.Common.Abilities.Skills;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Skills.RacialAdjustments
{
    [TestFixture]
    public class LightfootHalflingSkillAdjustmentsTests : AdjustmentsTests
    {
        protected override String tableName
        {
            get { return "LightfootHalflingSkillAdjustments"; }
        }

        [TestCase(SkillConstants.Climb, 2)]
        [TestCase(SkillConstants.Jump, 2)]
        [TestCase(SkillConstants.Listen, 2)]
        [TestCase(SkillConstants.MoveSilently, 2)]
        public override void Adjustment(String name, Int32 adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}