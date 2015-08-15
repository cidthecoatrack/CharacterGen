﻿using CharacterGen.Common.Items;
using NUnit.Framework;

namespace CharacterGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class EquipmentTests
    {
        private Equipment equipment;

        [SetUp]
        public void Setup()
        {
            equipment = new Equipment();
        }

        [Test]
        public void EquipmentInitialized()
        {
            Assert.That(equipment.Armor, Is.Null);
            Assert.That(equipment.OffHand, Is.Null);
            Assert.That(equipment.PrimaryHand, Is.Not.Null);
            Assert.That(equipment.Treasure, Is.Not.Null);
        }
    }
}