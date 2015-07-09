﻿using System;
using EquipmentGen.Common.Items;
using NPCGen.Common.Abilities.Feats;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Items;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses
{
    [TestFixture]
    public class RogueFeatDataTests : CharacterClassFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Rogue); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[] 
            {
                FeatConstants.SneakAttackId + "1",
                FeatConstants.SneakAttackId + "2",
                FeatConstants.SneakAttackId + "3",
                FeatConstants.SneakAttackId + "4",
                FeatConstants.SneakAttackId + "5",
                FeatConstants.SneakAttackId + "6",
                FeatConstants.SneakAttackId + "7",
                FeatConstants.SneakAttackId + "8",
                FeatConstants.SneakAttackId + "9",
                FeatConstants.SneakAttackId + "10",
                FeatConstants.TrapfindingId,
                FeatConstants.EvasionId,
                FeatConstants.UncannyDodgeId,
                FeatConstants.TrapSenseId + "1",
                FeatConstants.TrapSenseId + "2",
                FeatConstants.TrapSenseId + "3",
                FeatConstants.TrapSenseId + "4",
                FeatConstants.TrapSenseId + "5",
                FeatConstants.TrapSenseId + "6",
                FeatConstants.ImprovedUncannyDodgeId,
                FeatConstants.SimpleWeaponProficiencyId,
                FeatConstants.ExoticWeaponProficiencyId + WeaponConstants.HandCrossbow,
                FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Rapier,
                FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Sap,
                FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Shortbow,
                FeatConstants.MartialWeaponProficiencyId + WeaponConstants.ShortSword,
                FeatConstants.LightArmorProficiencyId
            };

            AssertCollectionNames(names);
        }

        [TestCase(FeatConstants.SneakAttackId + "1",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            1,
            2,
            1)]
        [TestCase(FeatConstants.SneakAttackId + "2",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            3,
            4,
            2)]
        [TestCase(FeatConstants.SneakAttackId + "3",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            5,
            6,
            3)]
        [TestCase(FeatConstants.SneakAttackId + "4",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            7,
            8,
            4)]
        [TestCase(FeatConstants.SneakAttackId + "5",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            9,
            10,
            5)]
        [TestCase(FeatConstants.SneakAttackId + "6",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            11,
            12,
            6)]
        [TestCase(FeatConstants.SneakAttackId + "7",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            13,
            14,
            7)]
        [TestCase(FeatConstants.SneakAttackId + "8",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            15,
            16,
            8)]
        [TestCase(FeatConstants.SneakAttackId + "9",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            17,
            18,
            9)]
        [TestCase(FeatConstants.SneakAttackId + "10",
            FeatConstants.SneakAttackId,
            "",
            0,
            "",
            "",
            19,
            0,
            10)]
        [TestCase(FeatConstants.TrapfindingId,
            FeatConstants.TrapfindingId,
            "",
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.EvasionId,
            FeatConstants.EvasionId,
            "",
            0,
            "",
            "",
            2,
            0,
            0)]
        [TestCase(FeatConstants.UncannyDodgeId,
            FeatConstants.UncannyDodgeId,
            "",
            0,
            "",
            "",
            4,
            0,
            0)]
        [TestCase(FeatConstants.TrapSenseId + "1",
            FeatConstants.TrapSenseId,
            "",
            0,
            "",
            "",
            3,
            5,
            1)]
        [TestCase(FeatConstants.TrapSenseId + "2",
            FeatConstants.TrapSenseId,
            "",
            0,
            "",
            "",
            6,
            8,
            2)]
        [TestCase(FeatConstants.TrapSenseId + "3",
            FeatConstants.TrapSenseId,
            "",
            0,
            "",
            "",
            9,
            11,
            3)]
        [TestCase(FeatConstants.TrapSenseId + "4",
            FeatConstants.TrapSenseId,
            "",
            0,
            "",
            "",
            12,
            14,
            4)]
        [TestCase(FeatConstants.TrapSenseId + "5",
            FeatConstants.TrapSenseId,
            "",
            0,
            "",
            "",
            15,
            17,
            5)]
        [TestCase(FeatConstants.TrapSenseId + "6",
            FeatConstants.TrapSenseId,
            "",
            0,
            "",
            "",
            18,
            0,
            6)]
        [TestCase(FeatConstants.ImprovedUncannyDodgeId,
            FeatConstants.ImprovedUncannyDodgeId,
            "",
            0,
            "",
            "",
            8,
            0,
            0)]
        [TestCase(FeatConstants.SimpleWeaponProficiencyId,
            FeatConstants.SimpleWeaponProficiencyId,
            ProficiencyConstants.All,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.ExoticWeaponProficiencyId + WeaponConstants.HandCrossbow,
            FeatConstants.ExoticWeaponProficiencyId,
            WeaponConstants.HandCrossbow,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Rapier,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.Rapier,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Sap,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.Sap,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.Shortbow,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.Shortbow,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId + WeaponConstants.ShortSword,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponConstants.ShortSword,
            0,
            "",
            "",
            1,
            0,
            0)]
        [TestCase(FeatConstants.LightArmorProficiencyId,
            FeatConstants.LightArmorProficiencyId,
            "",
            0,
            "",
            "",
            1,
            0,
            0)]
        public override void Data(String name, String featId, String focusType, Int32 frequencyQuantity, String frequencyQuantityStat, String frequencyTimePeriod, Int32 minimumLevel, Int32 maximumLevel, Int32 strength)
        {
            base.Data(name, featId, focusType, frequencyQuantity, frequencyQuantityStat, frequencyTimePeriod, minimumLevel, maximumLevel, strength);
        }
    }
}
