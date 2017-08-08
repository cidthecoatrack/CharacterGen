﻿using CharacterGen.Abilities;
using CharacterGen.Randomizers.Abilities;
using Ninject;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Stress.Randomizers.Abilities
{
    [TestFixture]
    public class TwoTenSidedDiceAbilitiesRandomizerTests : StressTests
    {
        [Inject, Named(AbilitiesRandomizerTypeConstants.TwoTenSidedDice)]
        public IAbilitiesRandomizer TwoTenSidedDiceAbilitiesRandomizer { get; set; }

        [Test]
        public void Stress()
        {
            stressor.Stress(AssertAbilities);
        }

        protected void AssertAbilities()
        {
            var stats = TwoTenSidedDiceAbilitiesRandomizer.Randomize();

            Assert.That(stats.Count, Is.EqualTo(6));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Charisma));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Constitution));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Dexterity));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Intelligence));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Strength));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Wisdom));

            foreach (var kvp in stats)
            {
                Assert.That(kvp.Value.Name, Is.EqualTo(kvp.Key));
                Assert.That(kvp.Value.Value, Is.InRange(2, 20), kvp.Key);
            }
        }

        [Test]
        public void NonDefaultAbilitiesOccur()
        {
            var stats = stressor.GenerateOrFail(TwoTenSidedDiceAbilitiesRandomizer.Randomize, ss => ss.Values.Any(s => s.Value != 10));
            var allAbilitiesAreDefault = stats.Values.All(s => s.Value == 10);
            Assert.That(allAbilitiesAreDefault, Is.False);
        }
    }
}