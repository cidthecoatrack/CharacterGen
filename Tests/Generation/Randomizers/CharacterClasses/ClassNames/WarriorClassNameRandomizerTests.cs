﻿using NPCGen.Core.Data.CharacterClasses;
using NPCGen.Core.Generation.Randomizers.CharacterClasses.ClassNames;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class WarriorClassNameRandomizerTests : ClassNameRandomizerTests
    {
        [SetUp]
        public void Setup()
        {
            randomizer = new WarriorClassNameRandomizer(mockPercentileResultProvider.Object);
        }

        [Test]
        public void FighterAlwaysAllowed()
        {
            AssertClassIsAlwaysAllowed(CharacterClassConstants.Fighter);
        }

        [Test]
        public void ClericNeverAllowed()
        {
            AssertClassIsNeverAllowed(CharacterClassConstants.Cleric);
        }

        [Test]
        public void RangerAlwaysAllowed()
        {
            AssertClassIsAlwaysAllowed(CharacterClassConstants.Ranger);
        }

        [Test]
        public void SorcererNeverAllowed()
        {
            AssertClassIsNeverAllowed(CharacterClassConstants.Sorcerer);
        }

        [Test]
        public void RogueNeverAllowed()
        {
            AssertClassIsNeverAllowed(CharacterClassConstants.Rogue);
        }

        [Test]
        public void WizardNeverAllowed()
        {
            AssertClassIsNeverAllowed(CharacterClassConstants.Wizard);
        }

        [Test]
        public void BarbarianAllowedIfAlignmentIsNotLawful()
        {
            AssertClassMustNotBeLawful(CharacterClassConstants.Barbarian);
        }

        [Test]
        public void BardNeverAllowed()
        {
            AssertClassIsNeverAllowed(CharacterClassConstants.Bard);
        }

        [Test]
        public void DruidNeverAllowed()
        {
            AssertClassIsNeverAllowed(CharacterClassConstants.Druid);
        }

        [Test]
        public void MonkAllowedIfAlignmentIsLawful()
        {
            AssertMonkIsAllowed();
        }

        [Test]
        public void PaladinAllowedIfAlignmentIsLawfulGood()
        {
            AssertPaladinIsAllowed();
        }
    }
}