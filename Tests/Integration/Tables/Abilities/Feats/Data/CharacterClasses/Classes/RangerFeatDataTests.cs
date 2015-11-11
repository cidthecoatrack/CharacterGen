﻿using CharacterGen.Common.Abilities.Feats;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Tables;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses.Classes
{
    [TestFixture]
    public class RangerFeatDataTests : CharacterClassFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Ranger); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                FeatConstants.SimpleWeaponProficiency,
                FeatConstants.MartialWeaponProficiency,
                FeatConstants.LightArmorProficiency,
                FeatConstants.ShieldProficiency,
                FeatConstants.FavoredEnemy + "1",
                FeatConstants.FavoredEnemy + "2",
                FeatConstants.FavoredEnemy + "3",
                FeatConstants.FavoredEnemy + "4",
                FeatConstants.FavoredEnemy + "5",
                FeatConstants.Track,
                FeatConstants.WildEmpathy,
                FeatConstants.CombatStyle,
                FeatConstants.Endurance,
                FeatConstants.ImprovedCombatStyle,
                FeatConstants.WoodlandStride,
                FeatConstants.SwiftTracker,
                FeatConstants.Evasion,
                FeatConstants.CombatStyleMastery,
                FeatConstants.Camouflage,
                FeatConstants.HideInPlainSight,
                FeatConstants.RapidShot + CharacterClassConstants.Ranger,
                FeatConstants.TwoWeaponFighting + CharacterClassConstants.Ranger,
                FeatConstants.Manyshot + CharacterClassConstants.Ranger,
                FeatConstants.ImprovedTwoWeaponFighting + CharacterClassConstants.Ranger,
                FeatConstants.ImprovedPreciseShot + CharacterClassConstants.Ranger,
                FeatConstants.GreaterTwoWeaponFighting + CharacterClassConstants.Ranger
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
            "")]
        [TestCase(FeatConstants.MartialWeaponProficiency,
            FeatConstants.MartialWeaponProficiency,
            FeatConstants.Foci.All,
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
        [TestCase(FeatConstants.FavoredEnemy + "1",
            FeatConstants.FavoredEnemy,
            GroupConstants.FavoredEnemies,
            0,
            "",
            "",
            1,
            0,
            2,
            "")]
        [TestCase(FeatConstants.FavoredEnemy + "2",
            FeatConstants.FavoredEnemy,
            GroupConstants.FavoredEnemies,
            0,
            "",
            "",
            5,
            0,
            2,
            "")]
        [TestCase(FeatConstants.FavoredEnemy + "3",
            FeatConstants.FavoredEnemy,
            GroupConstants.FavoredEnemies,
            0,
            "",
            "",
            10,
            0,
            2,
            "")]
        [TestCase(FeatConstants.FavoredEnemy + "4",
            FeatConstants.FavoredEnemy,
            GroupConstants.FavoredEnemies,
            0,
            "",
            "",
            15,
            0,
            2,
            "")]
        [TestCase(FeatConstants.FavoredEnemy + "5",
            FeatConstants.FavoredEnemy,
            GroupConstants.FavoredEnemies,
            0,
            "",
            "",
            20,
            0,
            2,
            "")]
        [TestCase(FeatConstants.Track,
            FeatConstants.Track,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.WildEmpathy,
            FeatConstants.WildEmpathy,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.CombatStyle,
            FeatConstants.CombatStyle,
            FeatConstants.CombatStyle,
            0,
            "",
            "",
            2,
            0,
            0,
            "")]
        [TestCase(FeatConstants.Endurance,
            FeatConstants.Endurance,
            "",
            0,
            "",
            "",
            3,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ImprovedCombatStyle,
            FeatConstants.ImprovedCombatStyle,
            FeatConstants.CombatStyle,
            0,
            "",
            "",
            6,
            0,
            0,
            "")]
        [TestCase(FeatConstants.WoodlandStride,
            FeatConstants.WoodlandStride,
            "",
            0,
            "",
            "",
            7,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SwiftTracker,
            FeatConstants.SwiftTracker,
            "",
            0,
            "",
            "",
            8,
            0,
            0,
            "")]
        [TestCase(FeatConstants.Evasion,
            FeatConstants.Evasion,
            "",
            0,
            "",
            "",
            9,
            0,
            0,
            "")]
        [TestCase(FeatConstants.CombatStyleMastery,
            FeatConstants.CombatStyleMastery,
            FeatConstants.CombatStyle,
            0,
            "",
            "",
            11,
            0,
            0,
            "")]
        [TestCase(FeatConstants.Camouflage,
            FeatConstants.Camouflage,
            "",
            0,
            "",
            "",
            13,
            0,
            0,
            "")]
        [TestCase(FeatConstants.HideInPlainSight,
            FeatConstants.HideInPlainSight,
            "",
            0,
            "",
            "",
            17,
            0,
            0,
            "")]
        [TestCase(FeatConstants.RapidShot + CharacterClassConstants.Ranger,
            FeatConstants.RapidShot,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.TwoWeaponFighting + CharacterClassConstants.Ranger,
            FeatConstants.TwoWeaponFighting,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.Manyshot + CharacterClassConstants.Ranger,
            FeatConstants.Manyshot,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ImprovedTwoWeaponFighting + CharacterClassConstants.Ranger,
            FeatConstants.ImprovedTwoWeaponFighting,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ImprovedPreciseShot + CharacterClassConstants.Ranger,
            FeatConstants.ImprovedPreciseShot,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.GreaterTwoWeaponFighting + CharacterClassConstants.Ranger,
            FeatConstants.GreaterTwoWeaponFighting,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        public override void Data(String name, String feat, String focusType, Int32 frequencyQuantity, String frequencyQuantityStat, String frequencyTimePeriod, Int32 minimumLevel, Int32 maximumLevel, Int32 strength, String sizeRequirement)
        {
            base.Data(name, feat, focusType, frequencyQuantity, frequencyQuantityStat, frequencyTimePeriod, minimumLevel, maximumLevel, strength, sizeRequirement);
        }
    }
}
