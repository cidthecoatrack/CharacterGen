﻿using NPCGen.Common.Races;
using NPCGen.Generators.Randomizers.Races.Metaraces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class NonGoodForcedMetaraceRandomizerTests : MetaraceRandomizerTests
    {
        [SetUp]
        public void Setup()
        {
            randomizer = new NonGoodForcedMetaraceRandomizer(mockPercentileResultSelector.Object, mockLevelAdjustmentsSelector.Object);
        }

        [Test]
        public void HalfCelestialIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.Metaraces.HalfCelestial);
        }

        [Test]
        public void HalfDragonIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.HalfDragon);
        }

        [Test]
        public void HalfFiendIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.HalfFiend);
        }

        [Test]
        public void WerebearIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.Metaraces.Werebear);
        }

        [Test]
        public void WereboarIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.Wereboar);
        }

        [Test]
        public void WereratIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.Wererat);
        }

        [Test]
        public void WeretigerIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.Weretiger);
        }

        [Test]
        public void WerewolfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.Metaraces.Werewolf);
        }
    }
}