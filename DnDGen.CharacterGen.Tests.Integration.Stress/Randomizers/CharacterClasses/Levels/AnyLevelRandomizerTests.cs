﻿using DnDGen.CharacterGen.Randomizers.CharacterClasses;
using Ninject;
using NUnit.Framework;

namespace DnDGen.CharacterGen.Tests.Integration.Stress.Randomizers.CharacterClasses.Levels
{
    [TestFixture]
    public class AnyLevelRandomizerTests : StressTests
    {
        [Inject, Named(LevelRandomizerTypeConstants.Any)]
        public ILevelRandomizer AnyLevelRandomizer { get; set; }

        [Test]
        public void StressAnyLevel()
        {
            stressor.Stress(AssertLevel);
        }

        protected void AssertLevel()
        {
            var level = levelRandomizer.Randomize();
            Assert.That(level, Is.InRange(1, 20));
        }
    }
}