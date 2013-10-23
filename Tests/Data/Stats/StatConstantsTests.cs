﻿using NPCGen.Core.Data.Stats;
using NUnit.Framework;

namespace NPCGen.Tests.Data.Stats
{
    [TestFixture]
    public class StatConstantsTests
    {
        [Test]
        public void StrengthConstant()
        {
            Assert.That(StatConstants.Strength, Is.EqualTo("Strength"));
        }

        [Test]
        public void ConstitutionConstant()
        {
            Assert.That(StatConstants.Constitution, Is.EqualTo("Constitution"));
        }

        [Test]
        public void DexterityConstant()
        {
            Assert.That(StatConstants.Dexterity, Is.EqualTo("Dexterity"));
        }

        [Test]
        public void IntelligenceConstant()
        {
            Assert.That(StatConstants.Intelligence, Is.EqualTo("Intelligence"));
        }

        [Test]
        public void WisdomConstant()
        {
            Assert.That(StatConstants.Wisdom, Is.EqualTo("Wisdom"));
        }

        [Test]
        public void CharismaConstant()
        {
            Assert.That(StatConstants.Charisma, Is.EqualTo("Charisma"));
        }
    }
}