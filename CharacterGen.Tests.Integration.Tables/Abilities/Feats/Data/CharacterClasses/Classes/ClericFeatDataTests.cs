﻿using CharacterGen.Abilities.Feats;
using CharacterGen.Abilities.Stats;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses.Classes
{
    [TestFixture]
    public class ClericFeatDataTests : CharacterClassFeatDataTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Cleric); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                FeatConstants.SimpleWeaponProficiency,
                FeatConstants.LightArmorProficiency,
                FeatConstants.MediumArmorProficiency,
                FeatConstants.HeavyArmorProficiency,
                FeatConstants.ShieldProficiency,
                FeatConstants.Turn
            };

            AssertCollectionNames(names);
        }

        [TestCase(FeatConstants.SimpleWeaponProficiency,
            FeatConstants.SimpleWeaponProficiency,
            FeatConstants.Foci.All,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.LightArmorProficiency,
            FeatConstants.LightArmorProficiency,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.MediumArmorProficiency,
            FeatConstants.MediumArmorProficiency,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.HeavyArmorProficiency,
            FeatConstants.HeavyArmorProficiency,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.ShieldProficiency,
            FeatConstants.ShieldProficiency,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.Turn,
            FeatConstants.Turn,
            "Undead",
            3,
            StatConstants.Charisma,
            FeatConstants.Frequencies.Day,
            1,
            0,
            0,
            "", true)]
        public override void ClassFeatData(string name, string feat, string focusType, int frequencyQuantity, string frequencyQuantityStat, string frequencyTimePeriod, int minimumLevel, int maximumLevel, int strength, string sizeRequirement, bool allowFocusOfAll)
        {
            base.ClassFeatData(name, feat, focusType, frequencyQuantity, frequencyQuantityStat, frequencyTimePeriod, minimumLevel, maximumLevel, strength, sizeRequirement, allowFocusOfAll);
        }
    }
}