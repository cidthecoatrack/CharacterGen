﻿using System;
using System.Collections.Generic;
using NPCGen.Common.Races;
using NPCGen.Generators.Interfaces.Randomizers.Races;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress.Randomizers.Races.Metaraces
{
    [TestFixture]
    public abstract class ForcableMetaraceRandomizerTests : StressTests
    {
        public virtual IForcableMetaraceRandomizer ForcableMetaraceRandomizer { get; set; }

        public override IMetaraceRandomizer MetaraceRandomizer
        {
            get { return ForcableMetaraceRandomizer; }
            set { base.MetaraceRandomizer = value; }
        }

        protected abstract IEnumerable<String> allowedMetaraces { get; }

        protected override void MakeAssertions()
        {
            var metarace = GenerateMetarace();
            Assert.That(allowedMetaraces, Contains.Item(metarace), testType);
        }

        private String GenerateMetarace()
        {
            var alignment = GetNewAlignment();
            var characterClass = GetNewCharacterClass(alignment);
            return MetaraceRandomizer.Randomize(alignment.Goodness, characterClass);
        }

        public abstract void MetaraceForced();

        public abstract void MetaraceNotForced();

        protected void AssertForcedMetarace()
        {
            ForcableMetaraceRandomizer.ForceMetarace = true;
            var metarace = GenerateMetarace();
            Assert.That(metarace, Is.Not.EqualTo(RaceConstants.Metaraces.NoneId));
        }

        protected void AssertUnforcedMetarace()
        {
            ForcableMetaraceRandomizer.ForceMetarace = false;
            var metarace = String.Empty;

            do metarace = GenerateMetarace();
            while (TestShouldKeepRunning() && metarace != RaceConstants.Metaraces.NoneId);

            Assert.That(metarace, Is.EqualTo(RaceConstants.Metaraces.NoneId));
        }
    }
}