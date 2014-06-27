﻿using System;
using NPCGen.Common.Races;
using NPCGen.Generators.Randomizers.Races.Metaraces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class NeutralForcedMetaraceRandomizerTests : MetaraceRandomizerTests
    {
        [SetUp]
        public void Setup()
        {
            randomizer = new NeutralForcedMetaraceRandomizer(mockPercentileResultSelector.Object, mockAdjustmentsSelector.Object);
        }

        [TestCase(RaceConstants.Metaraces.Wereboar)]
        [TestCase(RaceConstants.Metaraces.Weretiger)]
        public void Allowed(String race)
        {
            AssertRaceIsAllowed(race);
        }

        [TestCase(RaceConstants.Metaraces.Werebear)]
        [TestCase(RaceConstants.Metaraces.HalfFiend)]
        [TestCase(RaceConstants.Metaraces.HalfCelestial)]
        [TestCase(RaceConstants.Metaraces.HalfDragon)]
        [TestCase(RaceConstants.Metaraces.Wererat)]
        [TestCase(RaceConstants.Metaraces.Werewolf)]
        [TestCase("")]
        public void NotAllowed(String race)
        {
            AssertRaceIsNotAllowed(race);
        }
    }
}