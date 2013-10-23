﻿using System;
using System.Linq;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Data.CharacterClasses;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Randomizers.CharacterClasses.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class ClassNameRandomizerTests
    {
        protected Mock<IPercentileResultProvider> mockPercentileResultProvider;
        protected IClassNameRandomizer randomizer;

        private Alignment alignment;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetAllResults(It.IsAny<String>())).Returns(CharacterClassConstants.GetClassNames());
            alignment = new Alignment();
        }

        protected void AssertClassIsAlwaysAllowed(String className)
        {
            foreach (var lawfulness in AlignmentConstants.GetLawfulnesses())
            {
                foreach (var goodness in AlignmentConstants.GetGoodnesses())
                {
                    alignment.Lawfulness = lawfulness;
                    alignment.Goodness = goodness;
                    
                    AssertClassIsAllowed(className);
                }
            }
        }

        protected void AssertPaladinIsAllowed()
        {
            foreach (var lawfulness in AlignmentConstants.GetLawfulnesses())
            {
                foreach (var goodness in AlignmentConstants.GetGoodnesses())
                {
                    alignment.Lawfulness = lawfulness;
                    alignment.Goodness = goodness;

                    if (alignment.IsLawful() && alignment.IsGood())
                        AssertClassIsAllowed(CharacterClassConstants.Paladin);
                    else
                        AssertClassIsNotAllowed(CharacterClassConstants.Paladin);
                }
            }
        }

        protected void AssertDruidIsAllowed()
        {
            foreach (var lawfulness in AlignmentConstants.GetLawfulnesses())
            {
                foreach (var goodness in AlignmentConstants.GetGoodnesses())
                {
                    alignment.Lawfulness = lawfulness;
                    alignment.Goodness = goodness;

                    if (alignment.IsNeutral())
                        AssertClassIsAllowed(CharacterClassConstants.Druid);
                    else
                        AssertClassIsNotAllowed(CharacterClassConstants.Druid);
                }
            }
        }

        protected void AssertMonkIsAllowed()
        {
            foreach (var lawfulness in AlignmentConstants.GetLawfulnesses())
            {
                foreach (var goodness in AlignmentConstants.GetGoodnesses())
                {
                    alignment.Lawfulness = lawfulness;
                    alignment.Goodness = goodness;

                    if (alignment.IsLawful())
                        AssertClassIsAllowed(CharacterClassConstants.Monk);
                    else
                        AssertClassIsNotAllowed(CharacterClassConstants.Monk);
                }
            }
        }

        protected void AssertClassMustNotBeLawful(String className)
        {
            foreach (var lawfulness in AlignmentConstants.GetLawfulnesses())
            {
                foreach (var goodness in AlignmentConstants.GetGoodnesses())
                {
                    alignment.Lawfulness = lawfulness;
                    alignment.Goodness = goodness;

                    if (alignment.IsLawful())
                        AssertClassIsNotAllowed(className);
                    else
                        AssertClassIsAllowed(className);
                }
            }
        }

        protected void AssertClassIsNeverAllowed(String className)
        {
            foreach (var lawfulness in AlignmentConstants.GetLawfulnesses())
            {
                foreach (var goodness in AlignmentConstants.GetGoodnesses())
                {
                    alignment.Lawfulness = lawfulness;
                    alignment.Goodness = goodness;

                    AssertClassIsNotAllowed(className);
                }
            }
        }

        private void AssertClassIsAllowed(String className)
        {
            var results = randomizer.GetAllPossibleResults(alignment);
            Assert.That(results.Contains(className), Is.True);
        }

        private void AssertClassIsNotAllowed(String className)
        {
            var results = randomizer.GetAllPossibleResults(alignment);
            Assert.That(results.Contains(className), Is.False);
        }
    }
}