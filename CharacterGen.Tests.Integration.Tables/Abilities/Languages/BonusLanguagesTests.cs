﻿using CharacterGen.Abilities;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Languages
{
    [TestFixture]
    public class BonusLanguagesTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.BonusLanguages; }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                CharacterClassConstants.Adept,
                CharacterClassConstants.Aristocrat,
                CharacterClassConstants.Barbarian,
                CharacterClassConstants.Bard,
                CharacterClassConstants.Cleric,
                CharacterClassConstants.Commoner,
                CharacterClassConstants.Druid,
                CharacterClassConstants.Expert,
                CharacterClassConstants.Fighter,
                CharacterClassConstants.Monk,
                CharacterClassConstants.Paladin,
                CharacterClassConstants.Ranger,
                CharacterClassConstants.Rogue,
                CharacterClassConstants.Sorcerer,
                CharacterClassConstants.Warrior,
                CharacterClassConstants.Wizard,
            };

            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var allBaseRaces = baseRaceGroups[GroupConstants.All];
            names = names.Union(allBaseRaces).ToArray();

            AssertCollectionNames(names);
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Draconic,
            LanguageConstants.Halfling,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.Bugbear,
            LanguageConstants.Giant,
            LanguageConstants.Elven,
            LanguageConstants.Gnoll,
            LanguageConstants.Draconic,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Centaur,
            LanguageConstants.Common,
            LanguageConstants.Gnome,
            LanguageConstants.Halfling)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant,
            LanguageConstants.Aquan,
            LanguageConstants.Auran,
            LanguageConstants.Draconic,
            LanguageConstants.Elven,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf,
            LanguageConstants.Goblin,
            LanguageConstants.Gnome,
            LanguageConstants.Giant,
            LanguageConstants.Orc,
            LanguageConstants.Terran,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.Derro,
            LanguageConstants.Goblin,
            LanguageConstants.Gnome,
            LanguageConstants.Giant,
            LanguageConstants.Orc,
            LanguageConstants.Terran,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger,
            LanguageConstants.Auran,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Giant,
            LanguageConstants.Halfling,
            LanguageConstants.Terran)]
        [TestCase(RaceConstants.BaseRaces.Drow,
            LanguageConstants.Abyssal,
            LanguageConstants.Aquan,
            LanguageConstants.Draconic,
            LanguageConstants.Gnome,
            LanguageConstants.Goblin)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf,
            LanguageConstants.Giant,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Draconic,
            LanguageConstants.Terran)]
        [TestCase(RaceConstants.BaseRaces.FireGiant,
            LanguageConstants.Draconic,
            LanguageConstants.Elven,
            LanguageConstants.Goblin,
            LanguageConstants.Ignan,
            LanguageConstants.Infernal,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Draconic,
            LanguageConstants.Goblin,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant,
            LanguageConstants.Abyssal,
            LanguageConstants.Aquan,
            LanguageConstants.Draconic,
            LanguageConstants.Elven,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Gnoll,
            LanguageConstants.Common,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Draconic,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.Goblin,
            LanguageConstants.Draconic,
            LanguageConstants.Elven,
            LanguageConstants.Giant,
            LanguageConstants.Gnoll,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.GrayElf,
            LanguageConstants.Draconic,
            LanguageConstants.Gnoll,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Gnome,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.Grimlock,
            LanguageConstants.Draconic,
            LanguageConstants.Dwarven,
            LanguageConstants.Gnome,
            LanguageConstants.Terran,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc,
            LanguageConstants.Abyssal,
            LanguageConstants.Goblin,
            LanguageConstants.Giant,
            LanguageConstants.Gnoll,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.Harpy,
            LanguageConstants.Elven,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.HighElf,
            LanguageConstants.Draconic,
            LanguageConstants.Gnoll,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Gnome,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf,
            LanguageConstants.Goblin,
            LanguageConstants.Gnome,
            LanguageConstants.Giant,
            LanguageConstants.Orc,
            LanguageConstants.Terran,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.HillGiant,
            LanguageConstants.Common,
            LanguageConstants.Draconic,
            LanguageConstants.Elven,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin,
            LanguageConstants.Dwarven,
            LanguageConstants.Infernal,
            LanguageConstants.Orc,
            LanguageConstants.Draconic,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.Janni,
            LanguageConstants.Abyssal,
            LanguageConstants.Aquan,
            LanguageConstants.Auran,
            LanguageConstants.Celestial,
            LanguageConstants.Ignan,
            LanguageConstants.Infernal,
            LanguageConstants.Terran)]
        [TestCase(RaceConstants.BaseRaces.Kobold,
            LanguageConstants.Common,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk,
            LanguageConstants.Aquan,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Gnoll)]
        [TestCase(RaceConstants.BaseRaces.Minotaur,
            LanguageConstants.Terran,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf,
            LanguageConstants.Goblin,
            LanguageConstants.Gnome,
            LanguageConstants.Giant,
            LanguageConstants.Orc,
            LanguageConstants.Terran,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.Ogre,
            LanguageConstants.Terran,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.OgreMage,
            LanguageConstants.Infernal,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.Orc,
            LanguageConstants.Giant,
            LanguageConstants.Goblin,
            LanguageConstants.Gnoll,
            LanguageConstants.Dwarven,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.Pixie,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Halfling)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa,
            LanguageConstants.Sylvan,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.RockGnome,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Draconic,
            LanguageConstants.Goblin,
            LanguageConstants.Giant,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Satyr,
            LanguageConstants.Common,
            LanguageConstants.Elven,
            LanguageConstants.Gnome)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant,
            LanguageConstants.Common,
            LanguageConstants.Draconic,
            LanguageConstants.Elven,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.StormGiant,
            LanguageConstants.Auran,
            LanguageConstants.Celestial,
            LanguageConstants.Draconic,
            LanguageConstants.Elven,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Terran,
            LanguageConstants.Goblin,
            LanguageConstants.Giant,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Goblin,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Tiefling,
            LanguageConstants.Draconic,
            LanguageConstants.Dwarven,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Goblin,
            LanguageConstants.Halfling,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte,
            LanguageConstants.Common,
            LanguageConstants.Goblin,
            LanguageConstants.Giant,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Troll,
            LanguageConstants.Common,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.WildElf,
            LanguageConstants.Draconic,
            LanguageConstants.Gnoll,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Gnome,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.WoodElf,
            LanguageConstants.Draconic,
            LanguageConstants.Gnoll,
            LanguageConstants.Goblin,
            LanguageConstants.Orc,
            LanguageConstants.Gnome,
            LanguageConstants.Sylvan)]
        [TestCase(CharacterClassConstants.Cleric,
            LanguageConstants.Abyssal,
            LanguageConstants.Celestial,
            LanguageConstants.Infernal)]
        [TestCase(CharacterClassConstants.Druid,
            LanguageConstants.Sylvan)]
        [TestCase(CharacterClassConstants.Wizard,
            LanguageConstants.Draconic)]
        [TestCase(CharacterClassConstants.Barbarian)]
        [TestCase(CharacterClassConstants.Bard)]
        [TestCase(CharacterClassConstants.Fighter)]
        [TestCase(CharacterClassConstants.Monk)]
        [TestCase(CharacterClassConstants.Paladin)]
        [TestCase(CharacterClassConstants.Ranger)]
        [TestCase(CharacterClassConstants.Rogue)]
        [TestCase(CharacterClassConstants.Sorcerer)]
        [TestCase(CharacterClassConstants.Adept)]
        [TestCase(CharacterClassConstants.Aristocrat)]
        [TestCase(CharacterClassConstants.Commoner)]
        [TestCase(CharacterClassConstants.Expert)]
        [TestCase(CharacterClassConstants.Warrior)]
        public override void DistinctCollection(string name, params string[] collection)
        {
            base.DistinctCollection(name, collection);
        }

        [TestCase(RaceConstants.BaseRaces.HalfElf)]
        [TestCase(RaceConstants.BaseRaces.Human)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk)]
        public void AllLanguagesExceptDruidicAreBonusLanguages(string name)
        {
            var allLanguages = LanguageConstants.GetLanguages();
            var bonusLanguages = allLanguages.Except(new[] { LanguageConstants.Druidic }).ToArray();

            base.DistinctCollection(name, bonusLanguages);
        }
    }
}