﻿using System;
using NPCGen.Common.Races;
using NPCGen.Selectors.Interfaces.Objects;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Selectors.Objects
{
    [TestFixture]
    public class RacialFeatSelectionTests
    {
        private RacialFeatSelection selection;
        private Race race;

        [SetUp]
        public void Setup()
        {
            selection = new RacialFeatSelection();
            race = new Race();
        }

        [Test]
        public void RacialFeatSelectionInitialization()
        {
            Assert.That(selection.FeatId, Is.Empty);
            Assert.That(selection.Strength, Is.EqualTo(0));
            Assert.That(selection.MinimumHitDieRequirement, Is.EqualTo(0));
            Assert.That(selection.SizeRequirement, Is.Empty);
            Assert.That(selection.Focus, Is.Empty);
            Assert.That(selection.Frequency, Is.Not.Null);
        }

        [Test]
        public void RequirementsMetIfNoRequirements()
        {
            var met = selection.RequirementsMet(race, 0);
            Assert.That(met, Is.True);
        }

        [Test]
        public void RequirementsNotMetIfWrongSize()
        {
            race.Size = "big";
            selection.SizeRequirement = "small";

            var met = selection.RequirementsMet(race, 0);
            Assert.That(met, Is.False);
        }

        [Test]
        public void RequirementsNotMetIfBelowHitDiceRange()
        {
            selection.MinimumHitDieRequirement = 3;

            var met = selection.RequirementsMet(race, 2);
            Assert.That(met, Is.False);
        }

        [TestCase(3)]
        [TestCase(4)]
        public void RequirementsMetForMinimumHitDice(Int32 hitDice)
        {
            selection.MinimumHitDieRequirement = hitDice;

            var met = selection.RequirementsMet(race, hitDice);
            Assert.That(met, Is.True);
        }

        [Test]
        public void AllRequirementsMet()
        {
            race.Size = "big";

            selection.SizeRequirement = race.Size;
            selection.MinimumHitDieRequirement = 3;

            var met = selection.RequirementsMet(race, 4);
            Assert.That(met, Is.True);
        }

        [TestCase(RacialFeatSelection.FeatIdIndex, 0)]
        [TestCase(RacialFeatSelection.SizeRequirementIndex, 1)]
        [TestCase(RacialFeatSelection.MinimumHitDiceRequirementIndex, 2)]
        [TestCase(RacialFeatSelection.StrengthIndex, 3)]
        [TestCase(RacialFeatSelection.FocusIndex, 4)]
        [TestCase(RacialFeatSelection.FrequencyQuantityIndex, 5)]
        [TestCase(RacialFeatSelection.FrequencyTimePeriodIndex, 6)]
        public void IndexConstant(Int32 constant, Int32 value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}