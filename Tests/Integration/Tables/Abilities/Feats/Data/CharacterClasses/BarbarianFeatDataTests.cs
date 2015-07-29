﻿using CharacterGen.Common.Abilities.Feats;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Common.Items;
using CharacterGen.Tables;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses
{
    [TestFixture]
    public class BarbarianFeatDataTests : CharacterClassFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Barbarian); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                FeatConstants.SimpleWeaponProficiency,
                FeatConstants.MartialWeaponProficiency,
                FeatConstants.LightArmorProficiency,
                FeatConstants.MediumArmorProficiency,
                FeatConstants.ShieldProficiency,
                FeatConstants.FastMovement,
                FeatConstants.Illiteracy,
                FeatConstants.Rage + "1",
                FeatConstants.Rage + "2",
                FeatConstants.Rage + "3",
                FeatConstants.Rage + "4",
                FeatConstants.Rage + "5",
                FeatConstants.Rage + "6",
                FeatConstants.UncannyDodge,
                FeatConstants.TrapSense + "1",
                FeatConstants.TrapSense + "2",
                FeatConstants.TrapSense + "3",
                FeatConstants.TrapSense + "4",
                FeatConstants.TrapSense + "5",
                FeatConstants.TrapSense + "6",
                FeatConstants.ImprovedUncannyDodge,
                FeatConstants.DamageReduction + "1",
                FeatConstants.DamageReduction + "2",
                FeatConstants.DamageReduction + "3",
                FeatConstants.DamageReduction + "4",
                FeatConstants.DamageReduction + "5",
                FeatConstants.GreaterRage,
                FeatConstants.IndomitableWill,
                FeatConstants.TirelessRage,
                FeatConstants.MightyRage
            };

            AssertCollectionNames(names);
        }

        [TestCase(FeatConstants.SimpleWeaponProficiency,
            FeatConstants.SimpleWeaponProficiency,
            ProficiencyConstants.All,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MartialWeaponProficiency,
            FeatConstants.MartialWeaponProficiency,
            ProficiencyConstants.All,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.LightArmorProficiency,
            FeatConstants.LightArmorProficiency,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MediumArmorProficiency,
            FeatConstants.MediumArmorProficiency,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ShieldProficiency,
            FeatConstants.ShieldProficiency,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.FastMovement,
            FeatConstants.FastMovement,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.Illiteracy,
            FeatConstants.Illiteracy,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.Rage + "1",
            FeatConstants.Rage,
            "",
            1,
            "",
            FeatConstants.Frequencies.Day,
            1,
            3,
            0,
            "")]
        [TestCase(FeatConstants.Rage + "2",
            FeatConstants.Rage,
            "",
            2,
            "",
            FeatConstants.Frequencies.Day,
            4,
            7,
            0,
            "")]
        [TestCase(FeatConstants.Rage + "3",
            FeatConstants.Rage,
            "",
            3,
            "",
            FeatConstants.Frequencies.Day,
            8,
            11,
            0,
            "")]
        [TestCase(FeatConstants.Rage + "4",
            FeatConstants.Rage,
            "",
            4,
            "",
            FeatConstants.Frequencies.Day,
            12,
            15,
            0,
            "")]
        [TestCase(FeatConstants.Rage + "5",
            FeatConstants.Rage,
            "",
            5,
            "",
            FeatConstants.Frequencies.Day,
            16,
            19,
            0,
            "")]
        [TestCase(FeatConstants.Rage + "6",
            FeatConstants.Rage,
            "",
            6,
            "",
            FeatConstants.Frequencies.Day,
            20,
            0,
            0,
            "")]
        [TestCase(FeatConstants.UncannyDodge,
            FeatConstants.UncannyDodge,
            "",
            0,
            "",
            "",
            2,
            0,
            0,
            "")]
        [TestCase(FeatConstants.TrapSense + "1",
            FeatConstants.TrapSense,
            "",
            0,
            "",
            "",
            3,
            5,
            1,
            "")]
        [TestCase(FeatConstants.TrapSense + "2",
            FeatConstants.TrapSense,
            "",
            0,
            "",
            "",
            6,
            8,
            2,
            "")]
        [TestCase(FeatConstants.TrapSense + "3",
            FeatConstants.TrapSense,
            "",
            0,
            "",
            "",
            9,
            11,
            3,
            "")]
        [TestCase(FeatConstants.TrapSense + "4",
            FeatConstants.TrapSense,
            "",
            0,
            "",
            "",
            12,
            14,
            4,
            "")]
        [TestCase(FeatConstants.TrapSense + "5",
            FeatConstants.TrapSense,
            "",
            0,
            "",
            "",
            15,
            17,
            5,
            "")]
        [TestCase(FeatConstants.TrapSense + "6",
            FeatConstants.TrapSense,
            "",
            0,
            "",
            "",
            18,
            0,
            6,
            "")]
        [TestCase(FeatConstants.ImprovedUncannyDodge,
            FeatConstants.ImprovedUncannyDodge,
            "",
            0,
            "",
            "",
            5,
            0,
            0,
            "")]
        [TestCase(FeatConstants.DamageReduction + "1",
            FeatConstants.DamageReduction,
            "",
            0,
            "",
            "",
            7,
            9,
            1,
            "")]
        [TestCase(FeatConstants.DamageReduction + "2",
            FeatConstants.DamageReduction,
            "",
            0,
            "",
            "",
            10,
            12,
            2,
            "")]
        [TestCase(FeatConstants.DamageReduction + "3",
            FeatConstants.DamageReduction,
            "",
            0,
            "",
            "",
            13,
            15,
            3,
            "")]
        [TestCase(FeatConstants.DamageReduction + "4",
            FeatConstants.DamageReduction,
            "",
            0,
            "",
            "",
            16,
            18,
            4,
            "")]
        [TestCase(FeatConstants.DamageReduction + "5",
            FeatConstants.DamageReduction,
            "",
            0,
            "",
            "",
            19,
            0,
            5,
            "")]
        [TestCase(FeatConstants.GreaterRage,
            FeatConstants.GreaterRage,
            "",
            0,
            "",
            "",
            11,
            0,
            0,
            "")]
        [TestCase(FeatConstants.IndomitableWill,
            FeatConstants.IndomitableWill,
            "",
            0,
            "",
            "",
            14,
            0,
            0,
            "")]
        [TestCase(FeatConstants.TirelessRage,
            FeatConstants.TirelessRage,
            "",
            0,
            "",
            "",
            17,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MightyRage,
            FeatConstants.MightyRage,
            "",
            0,
            "",
            "",
            20,
            0,
            0,
            "")]
        public override void Data(String name, String feat, String focusType, Int32 frequencyQuantity, String frequencyQuantityStat, String frequencyTimePeriod, Int32 minimumLevel, Int32 maximumLevel, Int32 strength, String sizeRequirement)
        {
            base.Data(name, feat, focusType, frequencyQuantity, frequencyQuantityStat, frequencyTimePeriod, minimumLevel, maximumLevel, strength, sizeRequirement);
        }
    }
}
