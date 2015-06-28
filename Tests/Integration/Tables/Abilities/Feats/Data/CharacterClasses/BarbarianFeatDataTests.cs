﻿using System;
using NPCGen.Common.Abilities.Feats;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Items;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses
{
    [TestFixture]
    public class BarbarianFeatDataTests : CharacterClassFeatDataTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, CharacterClassConstants.Barbarian); }
        }

        [TestCase(FeatConstants.SimpleWeaponProficiencyId,
            FeatConstants.SimpleWeaponProficiencyId,
            WeaponProficiencyConstants.All,
            0,
            "",
            "",
            0,
            0,
            0)]
        [TestCase(FeatConstants.MartialWeaponProficiencyId,
            FeatConstants.MartialWeaponProficiencyId,
            WeaponProficiencyConstants.All,
            0,
            "",
            "",
            0,
            0,
            0)]
        [TestCase(FeatConstants.LightArmorProficiencyId,
            FeatConstants.LightArmorProficiencyId,
            "",
            0,
            "",
            "",
            0,
            0,
            0)]
        [TestCase(FeatConstants.MediumArmorProficiencyId,
            FeatConstants.MediumArmorProficiencyId,
            "",
            0,
            "",
            "",
            0,
            0,
            0)]
        [TestCase(FeatConstants.ShieldProficiencyId,
            FeatConstants.ShieldProficiencyId,
            "",
            0,
            "",
            "",
            0,
            0,
            0)]
        [TestCase(FeatConstants.FastMovementId,
            FeatConstants.FastMovementId,
            "",
            0,
            "",
            "",
            0,
            0,
            0)]
        [TestCase(FeatConstants.IlliteracyId,
            FeatConstants.IlliteracyId,
            "",
            0,
            "",
            "",
            0,
            0,
            0)]
        [TestCase(FeatConstants.RageId + "1",
            FeatConstants.RageId,
            "",
            1,
            "",
            FeatConstants.Frequencies.Day,
            1,
            3,
            0)]
        [TestCase(FeatConstants.RageId + "2",
            FeatConstants.RageId,
            "",
            2,
            "",
            FeatConstants.Frequencies.Day,
            4,
            7,
            0)]
        [TestCase(FeatConstants.RageId + "3",
            FeatConstants.RageId,
            "",
            3,
            "",
            FeatConstants.Frequencies.Day,
            8,
            11,
            0)]
        [TestCase(FeatConstants.RageId + "4",
            FeatConstants.RageId,
            "",
            4,
            "",
            FeatConstants.Frequencies.Day,
            12,
            15,
            0)]
        [TestCase(FeatConstants.RageId + "5",
            FeatConstants.RageId,
            "",
            5,
            "",
            FeatConstants.Frequencies.Day,
            16,
            19,
            0)]
        [TestCase(FeatConstants.RageId + "6",
            FeatConstants.RageId,
            "",
            6,
            "",
            FeatConstants.Frequencies.Day,
            20,
            0,
            0)]
        [TestCase(FeatConstants.UncannyDodgeId,
            FeatConstants.UncannyDodgeId,
            "",
            0,
            "",
            "",
            2,
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
            5,
            0,
            0)]
        [TestCase(FeatConstants.DamageReductionId + "1",
            FeatConstants.DamageReductionId,
            "",
            0,
            "",
            "",
            7,
            9,
            1)]
        [TestCase(FeatConstants.DamageReductionId + "2",
            FeatConstants.DamageReductionId,
            "",
            0,
            "",
            "",
            10,
            12,
            2)]
        [TestCase(FeatConstants.DamageReductionId + "3",
            FeatConstants.DamageReductionId,
            "",
            0,
            "",
            "",
            13,
            15,
            3)]
        [TestCase(FeatConstants.DamageReductionId + "4",
            FeatConstants.DamageReductionId,
            "",
            0,
            "",
            "",
            16,
            18,
            4)]
        [TestCase(FeatConstants.DamageReductionId + "5",
            FeatConstants.DamageReductionId,
            19,
            0,
            "",
            "",
            "",
            5,
            0)]
        [TestCase(FeatConstants.GreaterRageId,
            FeatConstants.GreaterRageId,
            "",
            0,
            "",
            "",
            11,
            0,
            0)]
        [TestCase(FeatConstants.IndomitableWillId,
            FeatConstants.IndomitableWillId,
            "",
            0,
            "",
            "",
            14,
            0,
            0)]
        [TestCase(FeatConstants.TirelessRageId,
            FeatConstants.TirelessRageId,
            "",
            0,
            "",
            "",
            17,
            0,
            0)]
        [TestCase(FeatConstants.MightyRageId,
            FeatConstants.MightyRageId,
            "",
            0,
            "",
            "",
            20,
            0,
            0)]
        public override void Data(String name, String featId, String focusType, Int32 frequencyQuantity, String frequencyQuantityStat, String frequencyTimePeriod, Int32 minimumLevel, Int32 maximumLevel, Int32 strength)
        {
            base.Data(name, featId, focusType, frequencyQuantity, frequencyQuantityStat, frequencyTimePeriod, minimumLevel, maximumLevel, strength);
        }
    }
}
