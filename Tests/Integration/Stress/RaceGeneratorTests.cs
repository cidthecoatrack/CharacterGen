﻿using NPCGen.Common.Races;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress
{
    [TestFixture]
    public class RaceGeneratorTests : StressTests
    {
        protected override void MakeAssertions()
        {
            var alignment = GetNewAlignment();
            var characterClass = GetNewCharacterClass(alignment);

            var race = RaceGenerator.GenerateWith(alignment.Goodness, characterClass, BaseRaceRandomizer, MetaraceRandomizer);
            Assert.That(race.BaseRace, Is.Not.Empty);
            Assert.That(race.Metarace, Is.Not.Null);
        }

        [Test]
        public void MetaraceHappens()
        {
            var race = new Race();

            do
            {
                var alignment = GetNewAlignment();
                var characterClass = GetNewCharacterClass(alignment);

                race = RaceGenerator.GenerateWith(alignment.Goodness, characterClass, BaseRaceRandomizer, MetaraceRandomizer);
            } while (TestShouldKeepRunning() && race.Metarace == RaceConstants.Metaraces.None);

            Assert.That(race.Metarace, Is.Not.EqualTo(RaceConstants.Metaraces.None));
            AssertIterations();
        }

        [Test]
        public void MetaraceDoesNotHappen()
        {
            var race = new Race();

            do
            {
                var alignment = GetNewAlignment();
                var characterClass = GetNewCharacterClass(alignment);

                race = RaceGenerator.GenerateWith(alignment.Goodness, characterClass, BaseRaceRandomizer, MetaraceRandomizer);
            } while (TestShouldKeepRunning() && race.Metarace != RaceConstants.Metaraces.None);

            Assert.That(race.Metarace, Is.EqualTo(RaceConstants.Metaraces.None));
            AssertIterations();
        }
    }
}