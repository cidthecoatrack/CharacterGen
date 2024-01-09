﻿using DnDGen.CharacterGen.CharacterClasses;
using DnDGen.CharacterGen.Tables;
using DnDGen.CharacterGen.Races;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.CharacterGen.Tests.Integration.Tables.CharacterClasses
{
    [TestFixture]
    public class SpecialistFieldsTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.SpecialistFields; }
        }

        [Test]
        public override void CollectionNames()
        {
            var baseRaceGroups = collectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var metaraceGroups = collectionsMapper.Map(TableNameConstants.Set.Collection.MetaraceGroups);
            var classGroups = collectionsMapper.Map(TableNameConstants.Set.Collection.ClassNameGroups);
            var names = baseRaceGroups[GroupConstants.All].Union(metaraceGroups[GroupConstants.All]).Union(classGroups[GroupConstants.All]);

            AssertCollectionNames(names);
        }

        [TestCase(CharacterClassConstants.Adept)]
        [TestCase(CharacterClassConstants.Aristocrat)]
        [TestCase(CharacterClassConstants.Barbarian)]
        [TestCase(CharacterClassConstants.Bard)]
        [TestCase(CharacterClassConstants.Cleric,
            CharacterClassConstants.Domains.Air,
            CharacterClassConstants.Domains.Animal,
            CharacterClassConstants.Domains.Chaos,
            CharacterClassConstants.Domains.Death,
            CharacterClassConstants.Domains.Destruction,
            CharacterClassConstants.Domains.Earth,
            CharacterClassConstants.Domains.Evil,
            CharacterClassConstants.Domains.Fire,
            CharacterClassConstants.Domains.Good,
            CharacterClassConstants.Domains.Healing,
            CharacterClassConstants.Domains.Knowledge,
            CharacterClassConstants.Domains.Law,
            CharacterClassConstants.Domains.Luck,
            CharacterClassConstants.Domains.Magic,
            CharacterClassConstants.Domains.Plant,
            CharacterClassConstants.Domains.Protection,
            CharacterClassConstants.Domains.Strength,
            CharacterClassConstants.Domains.Sun,
            CharacterClassConstants.Domains.Travel,
            CharacterClassConstants.Domains.Trickery,
            CharacterClassConstants.Domains.War,
            CharacterClassConstants.Domains.Water)]
        [TestCase(CharacterClassConstants.Commoner)]
        [TestCase(CharacterClassConstants.Druid)]
        [TestCase(CharacterClassConstants.Expert)]
        [TestCase(CharacterClassConstants.Fighter)]
        [TestCase(CharacterClassConstants.Monk)]
        [TestCase(CharacterClassConstants.Paladin)]
        [TestCase(CharacterClassConstants.Ranger)]
        [TestCase(CharacterClassConstants.Rogue)]
        [TestCase(CharacterClassConstants.Sorcerer)]
        [TestCase(CharacterClassConstants.Warrior)]
        [TestCase(CharacterClassConstants.Wizard,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant,
            CharacterClassConstants.Domains.Death,
            CharacterClassConstants.Domains.Evil,
            CharacterClassConstants.Domains.Good,
            CharacterClassConstants.Domains.Strength,
            CharacterClassConstants.Domains.Sun,
            CharacterClassConstants.Domains.Trickery,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.BaseRaces.FireGiant,
            CharacterClassConstants.Domains.Evil,
            CharacterClassConstants.Domains.Law,
            CharacterClassConstants.Domains.Trickery,
            CharacterClassConstants.Domains.War,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant,
            CharacterClassConstants.Domains.Chaos,
            CharacterClassConstants.Domains.Destruction,
            CharacterClassConstants.Domains.Evil,
            CharacterClassConstants.Domains.War,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.BaseRaces.Githyanki,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.BaseRaces.KuoToa,
            CharacterClassConstants.Domains.Destruction,
            CharacterClassConstants.Domains.Evil,
            CharacterClassConstants.Domains.Water,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.BaseRaces.Orc,
            CharacterClassConstants.Domains.Air,
            CharacterClassConstants.Domains.Animal,
            CharacterClassConstants.Domains.Chaos,
            CharacterClassConstants.Domains.Death,
            CharacterClassConstants.Domains.Destruction,
            CharacterClassConstants.Domains.Earth,
            CharacterClassConstants.Domains.Evil,
            CharacterClassConstants.Domains.Fire,
            CharacterClassConstants.Domains.Good,
            CharacterClassConstants.Domains.Healing,
            CharacterClassConstants.Domains.Knowledge,
            CharacterClassConstants.Domains.Law,
            CharacterClassConstants.Domains.Luck,
            CharacterClassConstants.Domains.Magic,
            CharacterClassConstants.Domains.Plant,
            CharacterClassConstants.Domains.Protection,
            CharacterClassConstants.Domains.Strength,
            CharacterClassConstants.Domains.Travel,
            CharacterClassConstants.Domains.Trickery,
            CharacterClassConstants.Domains.War,
            CharacterClassConstants.Domains.Water,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.BaseRaces.StormGiant,
            CharacterClassConstants.Domains.Chaos,
            CharacterClassConstants.Domains.Good,
            CharacterClassConstants.Domains.Protection,
            CharacterClassConstants.Domains.War,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        [TestCase(RaceConstants.Metaraces.Vampire,
            CharacterClassConstants.Domains.Chaos,
            CharacterClassConstants.Domains.Destruction,
            CharacterClassConstants.Domains.Evil,
            CharacterClassConstants.Domains.Trickery,
            CharacterClassConstants.Schools.Abjuration,
            CharacterClassConstants.Schools.Conjuration,
            CharacterClassConstants.Schools.Divination,
            CharacterClassConstants.Schools.Enchantment,
            CharacterClassConstants.Schools.Evocation,
            CharacterClassConstants.Schools.Illusion,
            CharacterClassConstants.Schools.Necromancy,
            CharacterClassConstants.Schools.Transmutation)]
        public void SpecialistFields(string name, params string[] fields)
        {
            base.DistinctCollection(name, fields);
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar)]
        [TestCase(RaceConstants.BaseRaces.AquaticElf)]
        [TestCase(RaceConstants.BaseRaces.Azer)]
        [TestCase(RaceConstants.BaseRaces.BlueSlaad)]
        [TestCase(RaceConstants.BaseRaces.Bugbear)]
        [TestCase(RaceConstants.BaseRaces.Centaur)]
        [TestCase(RaceConstants.BaseRaces.DeathSlaad)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling)]
        [TestCase(RaceConstants.BaseRaces.Derro)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger)]
        [TestCase(RaceConstants.BaseRaces.Drow)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome)]
        [TestCase(RaceConstants.BaseRaces.Gargoyle)]
        [TestCase(RaceConstants.BaseRaces.Githzerai)]
        [TestCase(RaceConstants.BaseRaces.Gnoll)]
        [TestCase(RaceConstants.BaseRaces.Goblin)]
        [TestCase(RaceConstants.BaseRaces.GrayElf)]
        [TestCase(RaceConstants.BaseRaces.GraySlaad)]
        [TestCase(RaceConstants.BaseRaces.GreenSlaad)]
        [TestCase(RaceConstants.BaseRaces.Grimlock)]
        [TestCase(RaceConstants.BaseRaces.HalfElf)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc)]
        [TestCase(RaceConstants.BaseRaces.Harpy)]
        [TestCase(RaceConstants.BaseRaces.HighElf)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf)]
        [TestCase(RaceConstants.BaseRaces.HillGiant)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin)]
        [TestCase(RaceConstants.BaseRaces.HoundArchon)]
        [TestCase(RaceConstants.BaseRaces.Human)]
        [TestCase(RaceConstants.BaseRaces.Janni)]
        [TestCase(RaceConstants.BaseRaces.Kapoacinth)]
        [TestCase(RaceConstants.BaseRaces.Kobold)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk)]
        [TestCase(RaceConstants.BaseRaces.Locathah)]
        [TestCase(RaceConstants.BaseRaces.Merfolk)]
        [TestCase(RaceConstants.BaseRaces.Merrow)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer)]
        [TestCase(RaceConstants.BaseRaces.Minotaur)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf)]
        [TestCase(RaceConstants.BaseRaces.Ogre)]
        [TestCase(RaceConstants.BaseRaces.OgreMage)]
        [TestCase(RaceConstants.BaseRaces.Pixie)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa)]
        [TestCase(RaceConstants.BaseRaces.RedSlaad)]
        [TestCase(RaceConstants.BaseRaces.RockGnome)]
        [TestCase(RaceConstants.BaseRaces.Sahuagin)]
        [TestCase(RaceConstants.BaseRaces.Satyr)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk)]
        [TestCase(RaceConstants.BaseRaces.Scrag)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling)]
        [TestCase(RaceConstants.BaseRaces.Tiefling)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte)]
        [TestCase(RaceConstants.BaseRaces.Troll)]
        [TestCase(RaceConstants.BaseRaces.WildElf)]
        [TestCase(RaceConstants.BaseRaces.WoodElf)]
        [TestCase(RaceConstants.BaseRaces.YuanTiAbomination)]
        [TestCase(RaceConstants.BaseRaces.YuanTiHalfblood)]
        [TestCase(RaceConstants.BaseRaces.YuanTiPureblood)]
        [TestCase(RaceConstants.Metaraces.Ghost)]
        [TestCase(RaceConstants.Metaraces.HalfCelestial)]
        [TestCase(RaceConstants.Metaraces.HalfDragon)]
        [TestCase(RaceConstants.Metaraces.HalfFiend)]
        [TestCase(RaceConstants.Metaraces.Lich)]
        [TestCase(RaceConstants.Metaraces.Mummy)]
        [TestCase(RaceConstants.Metaraces.None)]
        [TestCase(RaceConstants.Metaraces.Werebear)]
        [TestCase(RaceConstants.Metaraces.Wereboar)]
        [TestCase(RaceConstants.Metaraces.Wererat)]
        [TestCase(RaceConstants.Metaraces.Weretiger)]
        [TestCase(RaceConstants.Metaraces.Werewolf)]
        public void RaceHasAllSpecialistFields(string race)
        {
            var fields = new[]
            {
                CharacterClassConstants.Domains.Air,
                CharacterClassConstants.Domains.Animal,
                CharacterClassConstants.Domains.Chaos,
                CharacterClassConstants.Domains.Death,
                CharacterClassConstants.Domains.Destruction,
                CharacterClassConstants.Domains.Earth,
                CharacterClassConstants.Domains.Evil,
                CharacterClassConstants.Domains.Fire,
                CharacterClassConstants.Domains.Good,
                CharacterClassConstants.Domains.Healing,
                CharacterClassConstants.Domains.Knowledge,
                CharacterClassConstants.Domains.Law,
                CharacterClassConstants.Domains.Luck,
                CharacterClassConstants.Domains.Magic,
                CharacterClassConstants.Domains.Plant,
                CharacterClassConstants.Domains.Protection,
                CharacterClassConstants.Domains.Strength,
                CharacterClassConstants.Domains.Sun,
                CharacterClassConstants.Domains.Travel,
                CharacterClassConstants.Domains.Trickery,
                CharacterClassConstants.Domains.War,
                CharacterClassConstants.Domains.Water,
                CharacterClassConstants.Schools.Abjuration,
                CharacterClassConstants.Schools.Conjuration,
                CharacterClassConstants.Schools.Divination,
                CharacterClassConstants.Schools.Enchantment,
                CharacterClassConstants.Schools.Evocation,
                CharacterClassConstants.Schools.Illusion,
                CharacterClassConstants.Schools.Necromancy,
                CharacterClassConstants.Schools.Transmutation,
            };

            DistinctCollection(race, fields);
        }
    }
}