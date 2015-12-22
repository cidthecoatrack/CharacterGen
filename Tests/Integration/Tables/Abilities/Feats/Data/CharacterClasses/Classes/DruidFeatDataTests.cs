﻿using CharacterGen.Common.Abilities.Feats;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Tables;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses.Classes
{
    [TestFixture]
    public class DruidFeatDataTests : CharacterClassFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Druid); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Quarterstaff,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Dagger,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Club,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Dart,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Sling,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Shortspear,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Longspear,
                FeatConstants.MartialWeaponProficiency + WeaponConstants.Scimitar,
                FeatConstants.SimpleWeaponProficiency + WeaponConstants.Sickle,
                FeatConstants.LightArmorProficiency,
                FeatConstants.MediumArmorProficiency,
                FeatConstants.ShieldProficiency,
                FeatConstants.NatureSense,
                FeatConstants.WildEmpathy,
                FeatConstants.WildShape + "1",
                FeatConstants.WildShape + "2",
                FeatConstants.WildShape + "3",
                FeatConstants.WildShape + "4",
                FeatConstants.WildShape + "5",
                FeatConstants.WildShape + "6",
                FeatConstants.WildShape + "Tiny",
                FeatConstants.WildShape + "Large",
                FeatConstants.WildShape + "Plant",
                FeatConstants.WildShape + "Huge",
                FeatConstants.WildShape + "ElementalHuge",
                FeatConstants.WildShape + "Elemental1",
                FeatConstants.WildShape + "Elemental2",
                FeatConstants.WildShape + "Elemental3",
                FeatConstants.WoodlandStride,
                FeatConstants.TracklessStep,
                FeatConstants.ResistNaturesLure,
                FeatConstants.VenomImmunity,
                FeatConstants.AThousandFaces,
                FeatConstants.TimelessBody
            };

            AssertCollectionNames(names);
        }

        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Quarterstaff,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Quarterstaff,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Dagger,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Dagger,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Club,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Club,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Dart,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Dart,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Sling,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Sling,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Shortspear,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Shortspear,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Longspear,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Longspear,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.SimpleWeaponProficiency + WeaponConstants.Sickle,
            FeatConstants.SimpleWeaponProficiency,
            WeaponConstants.Sickle,
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.MartialWeaponProficiency + WeaponConstants.Scimitar,
            FeatConstants.MartialWeaponProficiency,
            WeaponConstants.Scimitar,
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
        [TestCase(FeatConstants.NatureSense,
            FeatConstants.NatureSense,
            "",
            0,
            "",
            "",
            1,
            0,
            2,
            "", true)]
        [TestCase(FeatConstants.WildEmpathy,
            FeatConstants.WildEmpathy,
            "",
            0,
            "",
            "",
            1,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "1",
            FeatConstants.WildShape,
            "",
            1,
            "",
            FeatConstants.Frequencies.Day,
            5,
            5,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "2",
            FeatConstants.WildShape,
            "",
            2,
            "",
            FeatConstants.Frequencies.Day,
            6,
            6,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "3",
            FeatConstants.WildShape,
            "",
            3,
            "",
            FeatConstants.Frequencies.Day,
            7,
            9,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "4",
            FeatConstants.WildShape,
            "",
            4,
            "",
            FeatConstants.Frequencies.Day,
            10,
            13,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "5",
            FeatConstants.WildShape,
            "",
            5,
            "",
            FeatConstants.Frequencies.Day,
            14,
            17,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "6",
            FeatConstants.WildShape,
            "",
            6,
            "",
            FeatConstants.Frequencies.Day,
            18,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "Large",
            FeatConstants.WildShape,
            "Large",
            0,
            "",
            "",
            8,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "Tiny",
            FeatConstants.WildShape,
            "Tiny",
            0,
            "",
            "",
            11,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "Plant",
            FeatConstants.WildShape,
            "Plant",
            0,
            "",
            "",
            12,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "Huge",
            FeatConstants.WildShape,
            "Huge",
            0,
            "",
            "",
            15,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "Elemental1",
            FeatConstants.WildShape,
            "Elemental",
            1,
            "",
            FeatConstants.Frequencies.Day,
            16,
            17,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "Elemental2",
            FeatConstants.WildShape,
            "Elemental",
            2,
            "",
            FeatConstants.Frequencies.Day,
            18,
            19,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "Elemental3",
            FeatConstants.WildShape,
            "Elemental",
            3,
            "",
            FeatConstants.Frequencies.Day,
            20,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WildShape + "ElementalHuge",
            FeatConstants.WildShape,
            "Huge Elemental",
            0,
            "",
            "",
            20,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.WoodlandStride,
            FeatConstants.WoodlandStride,
            "",
            0,
            "",
            "",
            2,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.TracklessStep,
            FeatConstants.TracklessStep,
            "",
            0,
            "",
            "",
            3,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.ResistNaturesLure,
            FeatConstants.ResistNaturesLure,
            "",
            0,
            "",
            "",
            4,
            0,
            4,
            "", true)]
        [TestCase(FeatConstants.AThousandFaces,
            FeatConstants.AThousandFaces,
            "",
            0,
            "",
            "",
            13,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.TimelessBody,
            FeatConstants.TimelessBody,
            "",
            0,
            "",
            "",
            15,
            0,
            0,
            "", true)]
        [TestCase(FeatConstants.VenomImmunity,
            FeatConstants.VenomImmunity,
            "",
            0,
            "",
            "",
            9,
            0,
            0,
            "", true)]
        public override void Data(string name, string feat, string focusType, int frequencyQuantity, string frequencyQuantityStat, string frequencyTimePeriod, int minimumLevel, int maximumLevel, int strength, string sizeRequirement, bool allowFocusOfAll)
        {
            base.Data(name, feat, focusType, frequencyQuantity, frequencyQuantityStat, frequencyTimePeriod, minimumLevel, maximumLevel, strength, sizeRequirement, allowFocusOfAll);
        }
    }
}
