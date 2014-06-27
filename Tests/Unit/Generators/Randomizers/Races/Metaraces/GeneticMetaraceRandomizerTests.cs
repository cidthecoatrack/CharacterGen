﻿using System;
using NPCGen.Common.Races;
using NPCGen.Generators.Randomizers.Races.Metaraces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class GeneticMetaraceRandomizerTests : MetaraceRandomizerTests
    {
        [SetUp]
        public void Setup()
        {
            randomizer = new GeneticMetaraceRandomizer(mockPercentileResultSelector.Object, mockAdjustmentsSelector.Object);
        }

        [TestCase(RaceConstants.Metaraces.HalfCelestial)]
        [TestCase(RaceConstants.Metaraces.HalfDragon)]
        [TestCase(RaceConstants.Metaraces.HalfFiend)]
        [TestCase("")]
        public void Allowed(String race)
        {
            AssertRaceIsAllowed(race);
        }

        [TestCase(RaceConstants.Metaraces.Werebear)]
        [TestCase(RaceConstants.Metaraces.Wereboar)]
        [TestCase(RaceConstants.Metaraces.Weretiger)]
        [TestCase(RaceConstants.Metaraces.Wererat)]
        [TestCase(RaceConstants.Metaraces.Werewolf)]
        public void NotAllowed(String race)
        {
            AssertRaceIsNotAllowed(race);
        }
    }
}