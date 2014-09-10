﻿using System;
using System.Collections.Generic;
using NPCGen.Common.Races;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress
{
    [TestFixture]
    public class RaceGeneratorTests : StressTests
    {
        private IEnumerable<String> baseRaces;
        private IEnumerable<String> metaraces;
        private IEnumerable<String> sizes;

        [SetUp]
        public void Setup()
        {
            baseRaces = RaceConstants.BaseRaces.GetBaseRaces();
            metaraces = RaceConstants.Metaraces.GetAllMetaraces();
            sizes = RaceConstants.Sizes.GetSizes();
        }

        protected override void MakeAssertions()
        {
            var race = GenerateRace();
            Assert.That(baseRaces, Contains.Item(race.BaseRace));
            Assert.That(metaraces, Contains.Item(race.Metarace));
            Assert.That(sizes, Contains.Item(race.Size));
            Assert.That(race.LandSpeed, Is.AtLeast(20));
            Assert.That(race.LandSpeed % 10, Is.EqualTo(0));
            Assert.That(race.AerialSpeed, Is.Not.Negative);
            Assert.That(race.MetaraceSpecies, Is.Not.Null);
        }

        private Race GenerateRace()
        {
            var alignment = GetNewAlignment();
            var characterClass = GetNewCharacterClass(alignment);

            return RaceGenerator.GenerateWith(alignment, characterClass, BaseRaceRandomizer, MetaraceRandomizer);
        }

        [Test]
        public void MetaraceHappens()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && race.Metarace == RaceConstants.Metaraces.None);

            AssertIterations();
            Assert.That(race.Metarace, Is.Not.EqualTo(RaceConstants.Metaraces.None));
        }

        [Test]
        public void MetaraceDoesNotHappen()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && race.Metarace != RaceConstants.Metaraces.None);

            AssertIterations();
            Assert.That(race.Metarace, Is.EqualTo(RaceConstants.Metaraces.None));
        }

        [Test]
        public void WingsHappen()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && !race.HasWings);

            AssertIterations();
            Assert.That(race.HasWings, Is.True);
            Assert.That(race.AerialSpeed, Is.Positive);
        }

        [Test]
        public void WingsDoNotHappen()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && race.HasWings);

            AssertIterations();
            Assert.That(race.HasWings, Is.False);
            Assert.That(race.AerialSpeed, Is.EqualTo(0));
        }

        [Test]
        public void MaleHappens()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && !race.Male);

            AssertIterations();
            Assert.That(race.Male, Is.True);
        }

        [Test]
        public void FemaleHappens()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && race.Male);

            AssertIterations();
            Assert.That(race.Male, Is.False);
        }

        [Test]
        public void MetaraceSpeciesHappen()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && String.IsNullOrEmpty(race.MetaraceSpecies));

            AssertIterations();
            Assert.That(race.MetaraceSpecies, Is.Not.Empty);
        }

        [Test]
        public void MetaraceSpeciesDoNotHappen()
        {
            var race = new Race();

            do race = GenerateRace();
            while (TestShouldKeepRunning() && !String.IsNullOrEmpty(race.MetaraceSpecies));

            AssertIterations();
            Assert.That(race.MetaraceSpecies, Is.Empty);
        }
    }
}