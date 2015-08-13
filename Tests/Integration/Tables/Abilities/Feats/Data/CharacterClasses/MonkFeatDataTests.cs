﻿using CharacterGen.Common.Abilities.Feats;
using CharacterGen.Common.Abilities.Stats;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Common.Races;
using CharacterGen.Tables;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses
{
    [TestFixture]
    public class MonkFeatDataTests : CharacterClassFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Monk); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Club,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.HeavyCrossbow,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.LightCrossbow,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Dagger,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Sling,
                FeatConstants.MartialWeaponProficiency + WeaponConstants.Handaxe,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Javelin,
                FeatConstants.ExoticWeaponProficiency + WeaponConstants.Kama,
                FeatConstants.ExoticWeaponProficiency + WeaponConstants.Nunchaku,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Quarterstaff,
                FeatConstants.ExoticWeaponProficiency + WeaponConstants.Shuriken,
                FeatConstants.ExoticWeaponProficiency + WeaponConstants.Siangham,
                FeatConstants.ArmorBonus + StatConstants.Wisdom,
                FeatConstants.ArmorBonus + "1",
                FeatConstants.ArmorBonus + "2",
                FeatConstants.ArmorBonus + "3",
                FeatConstants.ArmorBonus + "4",
                FeatConstants.FlurryOfBlows,
                FeatConstants.GreaterFlurry,
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d4",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d6",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d8",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d10",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "2d6",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "2d8",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "1d6",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "1d8",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "1d10",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "2d6",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "2d8",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "2d10",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "1d8",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "2d6",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "2d8",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "3d6",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "3d8",
                FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "4d8",
                FeatConstants.ImprovedUnarmedStrike,
                FeatConstants.MonkBonusFeat + "1",
                FeatConstants.MonkBonusFeat + "2",
                FeatConstants.MonkBonusFeat + "6",
                FeatConstants.ImprovedGrapple + CharacterClassConstants.Monk,
                FeatConstants.StunningFist + CharacterClassConstants.Monk,
                FeatConstants.CombatReflexes + CharacterClassConstants.Monk,
                FeatConstants.DeflectArrows + CharacterClassConstants.Monk,
                FeatConstants.ImprovedDisarm + CharacterClassConstants.Monk,
                FeatConstants.ImprovedTrip + CharacterClassConstants.Monk,
                FeatConstants.Evasion,
                FeatConstants.FastMovement + "10",
                FeatConstants.FastMovement + "20",
                FeatConstants.FastMovement + "30",
                FeatConstants.FastMovement + "40",
                FeatConstants.FastMovement + "50",
                FeatConstants.FastMovement + "60",
                FeatConstants.StillMind,
                FeatConstants.KiStrike + "Magic",
                FeatConstants.KiStrike + "Lawful",
                FeatConstants.KiStrike + "Adamantine",
                FeatConstants.SlowFall + "20",
                FeatConstants.SlowFall + "30",
                FeatConstants.SlowFall + "40",
                FeatConstants.SlowFall + "50",
                FeatConstants.SlowFall + "60",
                FeatConstants.SlowFall + "70",
                FeatConstants.SlowFall + "80",
                FeatConstants.SlowFall + "90",
                FeatConstants.SlowFall + "Any",
                FeatConstants.PurityOfBody,
                FeatConstants.WholenessOfBody,
                FeatConstants.ImprovedEvasion,
                FeatConstants.DiamondBody,
                FeatConstants.AbundantStep,
                FeatConstants.DiamondSoul,
                FeatConstants.QuiveringPalm,
                FeatConstants.TimelessBody,
                FeatConstants.TongueOfSunAndMoon,
                FeatConstants.EmptyBody,
                FeatConstants.PerfectSelf
            };

            AssertCollectionNames(names);
        }

        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Club,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Club,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.HeavyCrossbow,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.HeavyCrossbow,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.LightCrossbow,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.LightCrossbow,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Dagger,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Dagger,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Sling,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Sling,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MartialWeaponProficiency + WeaponConstants.Handaxe,
            FeatConstants.MartialWeaponProficiency,
            WeaponConstants.Handaxe,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Javelin,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Javelin,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ExoticWeaponProficiency + WeaponConstants.Kama,
            FeatConstants.ExoticWeaponProficiency,
            WeaponConstants.Kama,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ExoticWeaponProficiency + WeaponConstants.Nunchaku,
            FeatConstants.ExoticWeaponProficiency,
            WeaponConstants.Nunchaku,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Quarterstaff,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Quarterstaff,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ExoticWeaponProficiency + WeaponConstants.Siangham,
            FeatConstants.ExoticWeaponProficiency,
            WeaponConstants.Siangham,
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ArmorBonus + StatConstants.Wisdom,
            FeatConstants.ArmorBonus,
            "Add Wisdom bonus to AC if unarmored and unencumbered",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ArmorBonus + "1",
            FeatConstants.ArmorBonus,
            "",
            0,
            "",
            "",
            5,
            9,
            1,
            "")]
        [TestCase(FeatConstants.ArmorBonus + "2",
            FeatConstants.ArmorBonus,
            "",
            0,
            "",
            "",
            10,
            14,
            2,
            "")]
        [TestCase(FeatConstants.ArmorBonus + "3",
            FeatConstants.ArmorBonus,
            "",
            0,
            "",
            "",
            15,
            19,
            3,
            "")]
        [TestCase(FeatConstants.ArmorBonus + "4",
            FeatConstants.ArmorBonus,
            "",
            0,
            "",
            "",
            20,
            0,
            4,
            "")]
        [TestCase(FeatConstants.FlurryOfBlows,
            FeatConstants.FlurryOfBlows,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.GreaterFlurry,
            FeatConstants.GreaterFlurry,
            "",
            0,
            "",
            "",
            11,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d4",
            FeatConstants.MonkUnarmedStrike,
            "1d4",
            0,
            "",
            "",
            1,
            3,
            0,
            RaceConstants.Sizes.Small)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d6",
            FeatConstants.MonkUnarmedStrike,
            "1d6",
            0,
            "",
            "",
            4,
            7,
            0,
            RaceConstants.Sizes.Small)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d8",
            FeatConstants.MonkUnarmedStrike,
            "1d8",
            0,
            "",
            "",
            8,
            11,
            0,
            RaceConstants.Sizes.Small)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "1d10",
            FeatConstants.MonkUnarmedStrike,
            "1d10",
            0,
            "",
            "",
            12,
            15,
            0,
            RaceConstants.Sizes.Small)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "2d6",
            FeatConstants.MonkUnarmedStrike,
            "2d6",
            0,
            "",
            "",
            16,
            19,
            0,
            RaceConstants.Sizes.Small)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Small + "2d8",
            FeatConstants.MonkUnarmedStrike,
            "2d8",
            0,
            "",
            "",
            20,
            0,
            0,
            RaceConstants.Sizes.Small)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "1d6",
            FeatConstants.MonkUnarmedStrike,
            "1d6",
            0,
            "",
            "",
            1,
            3,
            0,
            RaceConstants.Sizes.Medium)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "1d8",
            FeatConstants.MonkUnarmedStrike,
            "1d8",
            0,
            "",
            "",
            4,
            7,
            0,
            RaceConstants.Sizes.Medium)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "1d10",
            FeatConstants.MonkUnarmedStrike,
            "1d10",
            0,
            "",
            "",
            8,
            11,
            0,
            RaceConstants.Sizes.Medium)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "2d6",
            FeatConstants.MonkUnarmedStrike,
            "2d6",
            0,
            "",
            "",
            12,
            15,
            0,
            RaceConstants.Sizes.Medium)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "2d8",
            FeatConstants.MonkUnarmedStrike,
            "2d8",
            0,
            "",
            "",
            16,
            19,
            0,
            RaceConstants.Sizes.Medium)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Medium + "2d10",
            FeatConstants.MonkUnarmedStrike,
            "2d10",
            0,
            "",
            "",
            20,
            0,
            0,
            RaceConstants.Sizes.Medium)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "1d8",
            FeatConstants.MonkUnarmedStrike,
            "1d8",
            0,
            "",
            "",
            1,
            3,
            0,
            RaceConstants.Sizes.Large)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "2d6",
            FeatConstants.MonkUnarmedStrike,
            "2d6",
            0,
            "",
            "",
            4,
            7,
            0,
            RaceConstants.Sizes.Large)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "2d8",
            FeatConstants.MonkUnarmedStrike,
            "2d8",
            0,
            "",
            "",
            8,
            11,
            0,
            RaceConstants.Sizes.Large)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "3d6",
            FeatConstants.MonkUnarmedStrike,
            "3d6",
            0,
            "",
            "",
            12,
            15,
            0,
            RaceConstants.Sizes.Large)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "3d8",
            FeatConstants.MonkUnarmedStrike,
            "3d8",
            0,
            "",
            "",
            16,
            19,
            0,
            RaceConstants.Sizes.Large)]
        [TestCase(FeatConstants.MonkUnarmedStrike + RaceConstants.Sizes.Large + "4d8",
            FeatConstants.MonkUnarmedStrike,
            "4d8",
            0,
            "",
            "",
            20,
            0,
            0,
            RaceConstants.Sizes.Large)]
        [TestCase(FeatConstants.ImprovedUnarmedStrike,
            FeatConstants.ImprovedUnarmedStrike,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MonkBonusFeat + "1",
            FeatConstants.MonkBonusFeat,
            FeatConstants.MonkBonusFeat + "1",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MonkBonusFeat + "2",
            FeatConstants.MonkBonusFeat,
            FeatConstants.MonkBonusFeat + "2",
            0,
            "",
            "",
            2,
            0,
            0,
            "")]
        [TestCase(FeatConstants.MonkBonusFeat + "6",
            FeatConstants.MonkBonusFeat,
            FeatConstants.MonkBonusFeat + "6",
            0,
            "",
            "",
            6,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ImprovedGrapple + CharacterClassConstants.Monk,
            FeatConstants.ImprovedGrapple,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.StunningFist + CharacterClassConstants.Monk,
            FeatConstants.StunningFist,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.CombatReflexes + CharacterClassConstants.Monk,
            FeatConstants.CombatReflexes,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.DeflectArrows + CharacterClassConstants.Monk,
            FeatConstants.DeflectArrows,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ImprovedDisarm + CharacterClassConstants.Monk,
            FeatConstants.ImprovedDisarm,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ImprovedTrip + CharacterClassConstants.Monk,
            FeatConstants.ImprovedTrip,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "")]
        [TestCase(FeatConstants.Evasion,
            FeatConstants.Evasion,
            "",
            0,
            "",
            "",
            2,
            0,
            0,
            "")]
        [TestCase(FeatConstants.FastMovement + "10",
            FeatConstants.FastMovement,
            "",
            0,
            "",
            "",
            3,
            5,
            10,
            "")]
        [TestCase(FeatConstants.FastMovement + "20",
            FeatConstants.FastMovement,
            "",
            0,
            "",
            "",
            6,
            8,
            20,
            "")]
        [TestCase(FeatConstants.FastMovement + "30",
            FeatConstants.FastMovement,
            "",
            0,
            "",
            "",
            9,
            11,
            30,
            "")]
        [TestCase(FeatConstants.FastMovement + "40",
            FeatConstants.FastMovement,
            "",
            0,
            "",
            "",
            12,
            14,
            40,
            "")]
        [TestCase(FeatConstants.FastMovement + "50",
            FeatConstants.FastMovement,
            "",
            0,
            "",
            "",
            15,
            17,
            50,
            "")]
        [TestCase(FeatConstants.FastMovement + "60",
            FeatConstants.FastMovement,
            "",
            0,
            "",
            "",
            18,
            0,
            60,
            "")]
        [TestCase(FeatConstants.StillMind,
            FeatConstants.StillMind,
            "",
            0,
            "",
            "",
            3,
            0,
            2,
            "")]
        [TestCase(FeatConstants.KiStrike + "Magic",
            FeatConstants.KiStrike,
            "Magic",
            0,
            "",
            "",
            4,
            0,
            0,
            "")]
        [TestCase(FeatConstants.KiStrike + "Lawful",
            FeatConstants.KiStrike,
            "Lawful",
            0,
            "",
            "",
            10,
            0,
            0,
            "")]
        [TestCase(FeatConstants.KiStrike + "Adamantine",
            FeatConstants.KiStrike,
            "Adamantine",
            0,
            "",
            "",
            16,
            0,
            0,
            "")]
        [TestCase(FeatConstants.SlowFall + "20",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            4,
            5,
            20,
            "")]
        [TestCase(FeatConstants.SlowFall + "30",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            6,
            7,
            30,
            "")]
        [TestCase(FeatConstants.SlowFall + "40",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            8,
            9,
            40,
            "")]
        [TestCase(FeatConstants.SlowFall + "50",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            10,
            11,
            50,
            "")]
        [TestCase(FeatConstants.SlowFall + "60",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            12,
            13,
            60,
            "")]
        [TestCase(FeatConstants.SlowFall + "70",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            14,
            15,
            70,
            "")]
        [TestCase(FeatConstants.SlowFall + "80",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            16,
            17,
            80,
            "")]
        [TestCase(FeatConstants.SlowFall + "90",
            FeatConstants.SlowFall,
            "",
            0,
            "",
            "",
            18,
            19,
            90,
            "")]
        [TestCase(FeatConstants.SlowFall + "Any",
            FeatConstants.SlowFall,
            "Any distance",
            0,
            "",
            "",
            20,
            0,
            0,
            "")]
        [TestCase(FeatConstants.PurityOfBody,
            FeatConstants.PurityOfBody,
            "",
            0,
            "",
            "",
            5,
            0,
            0,
            "")]
        [TestCase(FeatConstants.WholenessOfBody,
            FeatConstants.WholenessOfBody,
            "",
            0,
            "",
            "",
            7,
            0,
            0,
            "")]
        [TestCase(FeatConstants.ImprovedEvasion,
            FeatConstants.ImprovedEvasion,
            "",
            0,
            "",
            "",
            9,
            0,
            0,
            "")]
        [TestCase(FeatConstants.DiamondBody,
            FeatConstants.DiamondBody,
            "",
            0,
            "",
            "",
            11,
            0,
            0,
            "")]
        [TestCase(FeatConstants.AbundantStep,
            FeatConstants.AbundantStep,
            "",
            1,
            "",
            FeatConstants.Frequencies.Day,
            12,
            0,
            0,
            "")]
        [TestCase(FeatConstants.DiamondSoul,
            FeatConstants.DiamondSoul,
            "",
            0,
            "",
            "",
            13,
            0,
            0,
            "")]
        [TestCase(FeatConstants.QuiveringPalm,
            FeatConstants.QuiveringPalm,
            "",
            1,
            "",
            FeatConstants.Frequencies.Week,
            15,
            0,
            0,
            "")]
        [TestCase(FeatConstants.TimelessBody,
            FeatConstants.TimelessBody,
            "",
            0,
            "",
            "",
            17,
            0,
            0,
            "")]
        [TestCase(FeatConstants.TongueOfSunAndMoon,
            FeatConstants.TongueOfSunAndMoon,
            "",
            0,
            "",
            "",
            17,
            0,
            0,
            "")]
        [TestCase(FeatConstants.EmptyBody,
            FeatConstants.EmptyBody,
            "",
            0,
            "",
            "",
            19,
            0,
            0,
            "")]
        [TestCase(FeatConstants.PerfectSelf,
            FeatConstants.PerfectSelf,
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
