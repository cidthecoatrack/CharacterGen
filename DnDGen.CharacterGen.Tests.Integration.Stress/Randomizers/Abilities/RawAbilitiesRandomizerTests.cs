﻿using DnDGen.CharacterGen.Abilities;
using DnDGen.CharacterGen.Randomizers.Abilities;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.CharacterGen.Tests.Integration.Stress.Randomizers.Abilities
{
    [TestFixture]
    public class RawAbilitiesRandomizerTests : StressTests
    {
        private IAbilitiesRandomizer rawAbilitiesRandomizer;

        [SetUp]
        public void Setup()
        {
            rawAbilitiesRandomizer = GetNewInstanceOf<IAbilitiesRandomizer>(AbilitiesRandomizerTypeConstants.Raw);
        }

        [Test]
        public void StressRawAbilities()
        {
            stressor.Stress(AssertAbilities);
        }

        protected void AssertAbilities()
        {
            var stats = rawAbilitiesRandomizer.Randomize();

            Assert.That(stats.Count, Is.EqualTo(6));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Charisma));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Constitution));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Dexterity));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Intelligence));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Strength));
            Assert.That(stats.Keys, Contains.Item(AbilityConstants.Wisdom));
            Assert.That(stats.Values.Select(s => s.Value), Is.All.InRange(3, 18));
        }
    }
}