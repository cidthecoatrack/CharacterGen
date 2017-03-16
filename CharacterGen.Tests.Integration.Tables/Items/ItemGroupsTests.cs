﻿using CharacterGen.Abilities.Feats;
using CharacterGen.Domain.Tables;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;

namespace CharacterGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class ItemGroupsTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.ItemGroups; }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                ArmorConstants.AbsorbingShield,
                ArmorConstants.ArmorOfArrowAttraction,
                ArmorConstants.ArmorOfRage,
                ArmorConstants.BandedMail,
                ArmorConstants.BandedMailOfLuck,
                ArmorConstants.Breastplate,
                ArmorConstants.BreastplateOfCommand,
                ArmorConstants.Buckler,
                ArmorConstants.CastersShield,
                ArmorConstants.CelestialArmor,
                ArmorConstants.Chainmail,
                ArmorConstants.ChainShirt,
                ArmorConstants.DemonArmor,
                ArmorConstants.DwarvenPlate,
                ArmorConstants.ElvenChain,
                ArmorConstants.FullPlate,
                ArmorConstants.FullPlateOfSpeed,
                ArmorConstants.HalfPlate,
                ArmorConstants.HeavySteelShield,
                ArmorConstants.HeavyWoodenShield,
                ArmorConstants.HideArmor,
                ArmorConstants.LeatherArmor,
                ArmorConstants.LightSteelShield,
                ArmorConstants.LightWoodenShield,
                ArmorConstants.LionsShield,
                ArmorConstants.PaddedArmor,
                ArmorConstants.PlateArmorOfTheDeep,
                ArmorConstants.RhinoHide,
                ArmorConstants.ScaleMail,
                ArmorConstants.SpinedShield,
                ArmorConstants.SplintMail,
                ArmorConstants.StuddedLeatherArmor,
                ArmorConstants.TowerShield,
                ArmorConstants.WingedShield,
                AttributeConstants.Ammunition,
                AttributeConstants.Melee,
                AttributeConstants.TwoHanded,
                FeatConstants.LightArmorProficiency,
                FeatConstants.MediumArmorProficiency,
                FeatConstants.HeavyArmorProficiency,
                FeatConstants.ShieldProficiency,
                FeatConstants.TowerShieldProficiency,
                FeatConstants.Foci.UnarmedStrike,
                FeatConstants.Foci.Weapons,
                GroupConstants.Standard + ItemTypeConstants.Armor,
                WeaponConstants.Arrow,
                WeaponConstants.AssassinsDagger,
                WeaponConstants.BastardSword,
                WeaponConstants.Battleaxe,
                WeaponConstants.BerserkingSword,
                WeaponConstants.Club,
                WeaponConstants.CompositeLongbow,
                WeaponConstants.CompositeShortbow,
                WeaponConstants.CrossbowBolt,
                WeaponConstants.CursedBackbiterSpear,
                WeaponConstants.CursedMinus2Sword,
                WeaponConstants.Dagger,
                WeaponConstants.DaggerOfVenom,
                WeaponConstants.Dart,
                WeaponConstants.DireFlail,
                WeaponConstants.DwarvenThrower,
                WeaponConstants.DwarvenUrgrosh,
                WeaponConstants.DwarvenWaraxe,
                WeaponConstants.Falchion,
                WeaponConstants.FlameTongue,
                WeaponConstants.FrostBrand,
                WeaponConstants.Gauntlet,
                WeaponConstants.Glaive,
                WeaponConstants.GnomeHookedHammer,
                WeaponConstants.Greataxe,
                WeaponConstants.GreaterSlayingArrow,
                WeaponConstants.Greatclub,
                WeaponConstants.Greatsword,
                WeaponConstants.Guisarme,
                WeaponConstants.Halberd,
                WeaponConstants.Halfspear,
                WeaponConstants.Handaxe,
                WeaponConstants.HandCrossbow,
                WeaponConstants.HeavyCrossbow,
                WeaponConstants.HeavyFlail,
                WeaponConstants.HeavyMace,
                WeaponConstants.HeavyPick,
                WeaponConstants.HolyAvenger,
                WeaponConstants.Javelin,
                WeaponConstants.JavelinOfLightning,
                WeaponConstants.Kama,
                WeaponConstants.Kukri,
                WeaponConstants.Lance,
                WeaponConstants.LifeDrinker,
                WeaponConstants.LightCrossbow,
                WeaponConstants.LightFlail,
                WeaponConstants.LightHammer,
                WeaponConstants.LightMace,
                WeaponConstants.LightPick,
                WeaponConstants.Longbow,
                WeaponConstants.Longspear,
                WeaponConstants.Longsword,
                WeaponConstants.LuckBlade,
                WeaponConstants.MaceOfBlood,
                WeaponConstants.MaceOfSmiting,
                WeaponConstants.MaceOfTerror,
                WeaponConstants.Morningstar,
                WeaponConstants.NineLivesStealer,
                WeaponConstants.Net,
                WeaponConstants.NetOfSnaring,
                WeaponConstants.Nunchaku,
                WeaponConstants.Oathbow,
                WeaponConstants.OrcDoubleAxe,
                WeaponConstants.PunchingDagger,
                WeaponConstants.Quarterstaff,
                WeaponConstants.Ranseur,
                WeaponConstants.Rapier,
                WeaponConstants.RapierOfPuncturing,
                WeaponConstants.HeavyRepeatingCrossbow,
                WeaponConstants.LightRepeatingCrossbow,
                WeaponConstants.Sap,
                WeaponConstants.Scimitar,
                WeaponConstants.ScreamingBolt,
                WeaponConstants.Scythe,
                WeaponConstants.Shatterspike,
                WeaponConstants.ShiftersSorrow,
                WeaponConstants.Shortbow,
                WeaponConstants.Shortspear,
                WeaponConstants.ShortSword,
                WeaponConstants.Shuriken,
                WeaponConstants.Siangham,
                WeaponConstants.Sickle,
                WeaponConstants.SlayingArrow,
                WeaponConstants.SleepArrow,
                WeaponConstants.Sling,
                WeaponConstants.SlingBullet,
                WeaponConstants.SpikedChain,
                WeaponConstants.SpikedGauntlet,
                WeaponConstants.SunBlade,
                WeaponConstants.SwordOfLifeStealing,
                WeaponConstants.SwordOfSubtlety,
                WeaponConstants.SwordOfThePlanes,
                WeaponConstants.SylvanScimitar,
                WeaponConstants.ThrowingAxe,
                WeaponConstants.Trident,
                WeaponConstants.TridentOfFishCommand,
                WeaponConstants.TridentOfWarning,
                WeaponConstants.TwoBladedSword,
                WeaponConstants.Warhammer,
                WeaponConstants.Whip,
            };

            AssertCollectionNames(names);
        }

        [TestCase(ArmorConstants.AbsorbingShield, ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.ArmorOfArrowAttraction, ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.ArmorOfRage, ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.BandedMail, ArmorConstants.BandedMail)]
        [TestCase(ArmorConstants.BandedMailOfLuck, ArmorConstants.BandedMail)]
        [TestCase(ArmorConstants.Breastplate, ArmorConstants.Breastplate)]
        [TestCase(ArmorConstants.BreastplateOfCommand, ArmorConstants.Breastplate)]
        [TestCase(ArmorConstants.Buckler, ArmorConstants.Buckler)]
        [TestCase(ArmorConstants.CastersShield, ArmorConstants.LightWoodenShield)]
        [TestCase(ArmorConstants.CelestialArmor, ArmorConstants.CelestialArmor)]
        [TestCase(ArmorConstants.Chainmail, ArmorConstants.Chainmail)]
        [TestCase(ArmorConstants.ChainShirt, ArmorConstants.ChainShirt)]
        [TestCase(ArmorConstants.DemonArmor, ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.DwarvenPlate, ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.ElvenChain, ArmorConstants.ElvenChain)]
        [TestCase(ArmorConstants.FullPlate, ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.FullPlateOfSpeed, ArmorConstants.FullPlateOfSpeed)]
        [TestCase(ArmorConstants.HalfPlate, ArmorConstants.HalfPlate)]
        [TestCase(ArmorConstants.HeavySteelShield, ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.HeavyWoodenShield, ArmorConstants.HeavyWoodenShield)]
        [TestCase(ArmorConstants.HideArmor, ArmorConstants.HideArmor)]
        [TestCase(ArmorConstants.LeatherArmor, ArmorConstants.LeatherArmor)]
        [TestCase(ArmorConstants.LightSteelShield, ArmorConstants.LightSteelShield)]
        [TestCase(ArmorConstants.LightWoodenShield, ArmorConstants.LightWoodenShield)]
        [TestCase(ArmorConstants.LionsShield, ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.PaddedArmor, ArmorConstants.PaddedArmor)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep, ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.RhinoHide, ArmorConstants.HideArmor)]
        [TestCase(ArmorConstants.ScaleMail, ArmorConstants.ScaleMail)]
        [TestCase(ArmorConstants.SpinedShield, ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.SplintMail, ArmorConstants.SplintMail)]
        [TestCase(ArmorConstants.StuddedLeatherArmor, ArmorConstants.StuddedLeatherArmor)]
        [TestCase(ArmorConstants.TowerShield, ArmorConstants.TowerShield)]
        [TestCase(ArmorConstants.WingedShield, ArmorConstants.HeavyWoodenShield)]
        [TestCase(FeatConstants.MediumArmorProficiency,
            ArmorConstants.HideArmor,
            ArmorConstants.ScaleMail,
            ArmorConstants.Chainmail,
            ArmorConstants.Breastplate,
            ArmorConstants.FullPlateOfSpeed)]
        [TestCase(FeatConstants.HeavyArmorProficiency,
            ArmorConstants.SplintMail,
            ArmorConstants.BandedMail,
            ArmorConstants.HalfPlate,
            ArmorConstants.FullPlate)]
        [TestCase(FeatConstants.ShieldProficiency,
            ArmorConstants.Buckler,
            ArmorConstants.HeavySteelShield,
            ArmorConstants.HeavyWoodenShield,
            ArmorConstants.LightSteelShield,
            ArmorConstants.LightWoodenShield)]
        [TestCase(FeatConstants.TowerShieldProficiency,
            ArmorConstants.TowerShield)]
        [TestCase(FeatConstants.LightArmorProficiency,
            ArmorConstants.PaddedArmor,
            ArmorConstants.LeatherArmor,
            ArmorConstants.StuddedLeatherArmor,
            ArmorConstants.ChainShirt,
            ArmorConstants.ElvenChain,
            ArmorConstants.CelestialArmor)]
        [TestCase(GroupConstants.Standard + ItemTypeConstants.Armor,
            ArmorConstants.BandedMail,
            ArmorConstants.Breastplate,
            ArmorConstants.Buckler,
            ArmorConstants.ChainShirt,
            ArmorConstants.Chainmail,
            ArmorConstants.FullPlate,
            ArmorConstants.HalfPlate,
            ArmorConstants.HeavySteelShield,
            ArmorConstants.HeavyWoodenShield,
            ArmorConstants.HideArmor,
            ArmorConstants.LeatherArmor,
            ArmorConstants.LightSteelShield,
            ArmorConstants.LightWoodenShield,
            ArmorConstants.PaddedArmor,
            ArmorConstants.ScaleMail,
            ArmorConstants.SplintMail,
            ArmorConstants.StuddedLeatherArmor,
            ArmorConstants.TowerShield)]
        [TestCase(WeaponConstants.Arrow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.AssassinsDagger, WeaponConstants.Dagger)]
        [TestCase(WeaponConstants.BastardSword, WeaponConstants.BastardSword)]
        [TestCase(WeaponConstants.Battleaxe, WeaponConstants.Battleaxe)]
        [TestCase(WeaponConstants.BerserkingSword, WeaponConstants.Greatsword)]
        [TestCase(WeaponConstants.Club, WeaponConstants.Club)]
        [TestCase(WeaponConstants.CompositeLongbow, WeaponConstants.Longbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeShortbow, WeaponConstants.Shortbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CrossbowBolt, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.CursedBackbiterSpear, WeaponConstants.Shortspear)]
        [TestCase(WeaponConstants.CursedMinus2Sword, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.Dagger, WeaponConstants.Dagger)]
        [TestCase(WeaponConstants.DaggerOfVenom, WeaponConstants.Dagger)]
        [TestCase(WeaponConstants.Dart, WeaponConstants.Dart)]
        [TestCase(WeaponConstants.DireFlail, WeaponConstants.DireFlail)]
        [TestCase(WeaponConstants.DwarvenThrower, WeaponConstants.Warhammer)]
        [TestCase(WeaponConstants.DwarvenUrgrosh, WeaponConstants.DwarvenUrgrosh)]
        [TestCase(WeaponConstants.DwarvenWaraxe, WeaponConstants.DwarvenWaraxe)]
        [TestCase(WeaponConstants.Falchion, WeaponConstants.Falchion)]
        [TestCase(WeaponConstants.FlameTongue, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.FrostBrand, WeaponConstants.Greatsword)]
        [TestCase(WeaponConstants.Gauntlet, WeaponConstants.Gauntlet)]
        [TestCase(WeaponConstants.Glaive, WeaponConstants.Glaive)]
        [TestCase(WeaponConstants.GnomeHookedHammer, WeaponConstants.GnomeHookedHammer)]
        [TestCase(WeaponConstants.Greataxe, WeaponConstants.Greataxe)]
        [TestCase(WeaponConstants.Greatclub, WeaponConstants.Greatclub)]
        [TestCase(WeaponConstants.GreaterSlayingArrow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Greatsword, WeaponConstants.Greatsword)]
        [TestCase(WeaponConstants.Guisarme, WeaponConstants.Guisarme)]
        [TestCase(WeaponConstants.Halberd, WeaponConstants.Halberd)]
        [TestCase(WeaponConstants.Halfspear, WeaponConstants.Halfspear)]
        [TestCase(WeaponConstants.Handaxe, WeaponConstants.Handaxe)]
        [TestCase(WeaponConstants.HandCrossbow, WeaponConstants.HandCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.HeavyCrossbow, WeaponConstants.HeavyCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.HeavyFlail, WeaponConstants.HeavyFlail)]
        [TestCase(WeaponConstants.HeavyMace, WeaponConstants.HeavyMace)]
        [TestCase(WeaponConstants.HeavyPick, WeaponConstants.HeavyPick)]
        [TestCase(WeaponConstants.HolyAvenger, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.Javelin, WeaponConstants.Javelin)]
        [TestCase(WeaponConstants.JavelinOfLightning, WeaponConstants.Javelin)]
        [TestCase(WeaponConstants.Kama, WeaponConstants.Kama)]
        [TestCase(WeaponConstants.Kukri, WeaponConstants.Kukri)]
        [TestCase(WeaponConstants.Lance, WeaponConstants.Lance)]
        [TestCase(WeaponConstants.LifeDrinker, WeaponConstants.Greataxe)]
        [TestCase(WeaponConstants.LightCrossbow, WeaponConstants.LightCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.LightFlail, WeaponConstants.LightFlail)]
        [TestCase(WeaponConstants.LightHammer, WeaponConstants.LightHammer)]
        [TestCase(WeaponConstants.LightMace, WeaponConstants.LightMace)]
        [TestCase(WeaponConstants.LightPick, WeaponConstants.LightPick)]
        [TestCase(WeaponConstants.Longbow, WeaponConstants.Longbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Longspear, WeaponConstants.Longspear)]
        [TestCase(WeaponConstants.Longsword, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.LuckBlade, WeaponConstants.ShortSword)]
        [TestCase(WeaponConstants.MaceOfBlood, WeaponConstants.HeavyMace)]
        [TestCase(WeaponConstants.MaceOfSmiting, WeaponConstants.HeavyMace)]
        [TestCase(WeaponConstants.MaceOfTerror, WeaponConstants.HeavyMace)]
        [TestCase(WeaponConstants.Morningstar, WeaponConstants.Morningstar)]
        [TestCase(WeaponConstants.Net, WeaponConstants.Net)]
        [TestCase(WeaponConstants.NetOfSnaring, WeaponConstants.Net)]
        [TestCase(WeaponConstants.NineLivesStealer, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.Nunchaku, WeaponConstants.Nunchaku)]
        [TestCase(WeaponConstants.Oathbow, WeaponConstants.Longbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.OrcDoubleAxe, WeaponConstants.OrcDoubleAxe)]
        [TestCase(WeaponConstants.PunchingDagger, WeaponConstants.PunchingDagger)]
        [TestCase(WeaponConstants.Quarterstaff, WeaponConstants.Quarterstaff)]
        [TestCase(WeaponConstants.Ranseur, WeaponConstants.Ranseur)]
        [TestCase(WeaponConstants.Rapier, WeaponConstants.Rapier)]
        [TestCase(WeaponConstants.RapierOfPuncturing, WeaponConstants.Rapier)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, WeaponConstants.HeavyRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, WeaponConstants.LightRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.Sap, WeaponConstants.Sap)]
        [TestCase(WeaponConstants.Scimitar, WeaponConstants.Scimitar)]
        [TestCase(WeaponConstants.ScreamingBolt, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.Scythe, WeaponConstants.Scythe)]
        [TestCase(WeaponConstants.Shatterspike, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.ShiftersSorrow, WeaponConstants.TwoBladedSword)]
        [TestCase(WeaponConstants.Shortbow, WeaponConstants.Shortbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Shortspear, WeaponConstants.Shortspear)]
        [TestCase(WeaponConstants.ShortSword, WeaponConstants.ShortSword)]
        [TestCase(WeaponConstants.Shuriken, WeaponConstants.Shuriken)]
        [TestCase(WeaponConstants.Siangham, WeaponConstants.Siangham)]
        [TestCase(WeaponConstants.Sickle, WeaponConstants.Sickle)]
        [TestCase(WeaponConstants.SlayingArrow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.SleepArrow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Sling, WeaponConstants.Sling, WeaponConstants.SlingBullet)]
        [TestCase(WeaponConstants.SlingBullet, WeaponConstants.SlingBullet)]
        [TestCase(WeaponConstants.SpikedChain, WeaponConstants.SpikedChain)]
        [TestCase(WeaponConstants.SpikedGauntlet, WeaponConstants.SpikedGauntlet)]
        [TestCase(WeaponConstants.SunBlade, WeaponConstants.ShortSword)]
        [TestCase(WeaponConstants.SwordOfLifeStealing, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.SwordOfSubtlety, WeaponConstants.ShortSword)]
        [TestCase(WeaponConstants.SwordOfThePlanes, WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.SylvanScimitar, WeaponConstants.Scimitar)]
        [TestCase(WeaponConstants.ThrowingAxe, WeaponConstants.ThrowingAxe)]
        [TestCase(WeaponConstants.Trident, WeaponConstants.Trident)]
        [TestCase(WeaponConstants.TridentOfFishCommand, WeaponConstants.Trident)]
        [TestCase(WeaponConstants.TridentOfWarning, WeaponConstants.Trident)]
        [TestCase(WeaponConstants.TwoBladedSword, WeaponConstants.TwoBladedSword)]
        [TestCase(WeaponConstants.Warhammer, WeaponConstants.Warhammer)]
        [TestCase(WeaponConstants.Whip, WeaponConstants.Whip)]
        [TestCase(FeatConstants.Foci.UnarmedStrike)]
        [TestCase(AttributeConstants.Ammunition,
            WeaponConstants.Arrow,
            WeaponConstants.CrossbowBolt,
            WeaponConstants.SlingBullet)]
        public void ItemGroup(string name, params string[] collection)
        {
            base.DistinctCollection(name, collection);
        }

        [Test]
        public void NoAmmunitionIsAlsoMelee()
        {
            var itemGroups = CollectionsMapper.Map(tableName);
            var meleeWeapons = itemGroups[AttributeConstants.Melee];
            var ammunitions = itemGroups[AttributeConstants.Ammunition];
            var meleeAmmunitions = meleeWeapons.Intersect(ammunitions);

            Assert.That(meleeAmmunitions, Is.Empty);
        }

        [Test]
        public void Weapons()
        {
            var items = new[]
            {
                WeaponConstants.Arrow,
                WeaponConstants.BastardSword,
                WeaponConstants.Battleaxe,
                WeaponConstants.Club,
                WeaponConstants.CrossbowBolt,
                WeaponConstants.Dagger,
                WeaponConstants.Dart,
                WeaponConstants.DireFlail,
                WeaponConstants.DwarvenUrgrosh,
                WeaponConstants.DwarvenWaraxe,
                WeaponConstants.Falchion,
                WeaponConstants.Gauntlet,
                WeaponConstants.Glaive,
                WeaponConstants.GnomeHookedHammer,
                WeaponConstants.Greataxe,
                WeaponConstants.Greatclub,
                WeaponConstants.Greatsword,
                WeaponConstants.Guisarme,
                WeaponConstants.Halberd,
                WeaponConstants.Halfspear,
                WeaponConstants.Handaxe,
                WeaponConstants.HandCrossbow,
                WeaponConstants.HeavyCrossbow,
                WeaponConstants.HeavyFlail,
                WeaponConstants.HeavyMace,
                WeaponConstants.HeavyPick,
                WeaponConstants.Javelin,
                WeaponConstants.Kama,
                WeaponConstants.Kukri,
                WeaponConstants.Lance,
                WeaponConstants.LightCrossbow,
                WeaponConstants.LightFlail,
                WeaponConstants.LightHammer,
                WeaponConstants.LightMace,
                WeaponConstants.LightPick,
                WeaponConstants.Longbow,
                WeaponConstants.Longspear,
                WeaponConstants.Longsword,
                WeaponConstants.Morningstar,
                WeaponConstants.Net,
                WeaponConstants.Nunchaku,
                WeaponConstants.OrcDoubleAxe,
                WeaponConstants.PunchingDagger,
                WeaponConstants.Quarterstaff,
                WeaponConstants.Ranseur,
                WeaponConstants.Rapier,
                WeaponConstants.HeavyRepeatingCrossbow,
                WeaponConstants.LightRepeatingCrossbow,
                WeaponConstants.Sap,
                WeaponConstants.Scimitar,
                WeaponConstants.Scythe,
                WeaponConstants.Shortbow,
                WeaponConstants.Shortspear,
                WeaponConstants.ShortSword,
                WeaponConstants.Shuriken,
                WeaponConstants.Siangham,
                WeaponConstants.Sickle,
                WeaponConstants.Sling,
                WeaponConstants.SlingBullet,
                WeaponConstants.SpikedChain,
                WeaponConstants.SpikedGauntlet,
                WeaponConstants.ThrowingAxe,
                WeaponConstants.Trident,
                WeaponConstants.TwoBladedSword,
                WeaponConstants.Warhammer,
                WeaponConstants.Whip
            };

            base.DistinctCollection(FeatConstants.Foci.Weapons, items);
        }

        [Test]
        public void MeleeWeapons()
        {
            var items = new[]
            {
                WeaponConstants.BastardSword,
                WeaponConstants.Battleaxe,
                WeaponConstants.Club,
                WeaponConstants.Dagger,
                WeaponConstants.DireFlail,
                WeaponConstants.DwarvenUrgrosh,
                WeaponConstants.DwarvenWaraxe,
                WeaponConstants.Falchion,
                WeaponConstants.Gauntlet,
                WeaponConstants.Glaive,
                WeaponConstants.GnomeHookedHammer,
                WeaponConstants.Greataxe,
                WeaponConstants.Greatclub,
                WeaponConstants.Greatsword,
                WeaponConstants.Guisarme,
                WeaponConstants.Halberd,
                WeaponConstants.Halfspear,
                WeaponConstants.Handaxe,
                WeaponConstants.HeavyFlail,
                WeaponConstants.HeavyMace,
                WeaponConstants.HeavyPick,
                WeaponConstants.Kama,
                WeaponConstants.Kukri,
                WeaponConstants.Lance,
                WeaponConstants.LightFlail,
                WeaponConstants.LightHammer,
                WeaponConstants.LightMace,
                WeaponConstants.LightPick,
                WeaponConstants.Longspear,
                WeaponConstants.Longsword,
                WeaponConstants.Morningstar,
                WeaponConstants.Nunchaku,
                WeaponConstants.OrcDoubleAxe,
                WeaponConstants.PunchingDagger,
                WeaponConstants.Quarterstaff,
                WeaponConstants.Ranseur,
                WeaponConstants.Rapier,
                WeaponConstants.Sap,
                WeaponConstants.Scimitar,
                WeaponConstants.Scythe,
                WeaponConstants.Shortspear,
                WeaponConstants.ShortSword,
                WeaponConstants.Siangham,
                WeaponConstants.Sickle,
                WeaponConstants.SpikedChain,
                WeaponConstants.SpikedGauntlet,
                WeaponConstants.Trident,
                WeaponConstants.TwoBladedSword,
                WeaponConstants.Warhammer,
                WeaponConstants.Whip
            };

            base.DistinctCollection(AttributeConstants.Melee, items);
        }

        [Test]
        public void TwoHandedWeapons()
        {
            var items = new[]
            {
                WeaponConstants.BastardSword,
                WeaponConstants.DireFlail,
                WeaponConstants.DwarvenUrgrosh,
                WeaponConstants.Falchion,
                WeaponConstants.Glaive,
                WeaponConstants.GnomeHookedHammer,
                WeaponConstants.Greataxe,
                WeaponConstants.Greatclub,
                WeaponConstants.Greatsword,
                WeaponConstants.Guisarme,
                WeaponConstants.Halberd,
                WeaponConstants.Halfspear,
                WeaponConstants.HandCrossbow,
                WeaponConstants.HeavyCrossbow,
                WeaponConstants.HeavyFlail,
                WeaponConstants.Lance,
                WeaponConstants.LightCrossbow,
                WeaponConstants.Longbow,
                WeaponConstants.Longspear,
                WeaponConstants.Net,
                WeaponConstants.OrcDoubleAxe,
                WeaponConstants.Quarterstaff,
                WeaponConstants.Ranseur,
                WeaponConstants.HeavyRepeatingCrossbow,
                WeaponConstants.LightRepeatingCrossbow,
                WeaponConstants.Scythe,
                WeaponConstants.Shortbow,
                WeaponConstants.Sling,
                WeaponConstants.SpikedChain,
                WeaponConstants.TwoBladedSword
            };

            base.DistinctCollection(AttributeConstants.TwoHanded, items);
        }
    }
}
