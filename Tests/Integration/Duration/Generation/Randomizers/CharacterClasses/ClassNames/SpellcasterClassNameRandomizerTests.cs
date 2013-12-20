﻿using Ninject;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Randomizers.CharacterClasses.ClassNames;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Duration.Generation.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class SpellcasterClassNameRandomizerTests : DurationTest
    {
        [Inject]
        public Alignment Alignment { get; set; }

        public SpellcasterClassNameRandomizerTests()
        {
            ClassNameRandomizer = kernel.Get<SpellcasterClassNameRandomizer>();
        }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void SpellcasterClassNameSingleRandomization()
        {
            ClassNameRandomizer.Randomize(Alignment);
            AssertDuration();
        }
    }
}