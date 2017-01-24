﻿using CharacterGen.Abilities;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Languages
{
    [TestFixture]
    public class AutomaticLanguagesTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.AutomaticLanguages; }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                RaceConstants.Metaraces.HalfCelestial,
                RaceConstants.Metaraces.HalfDragon,
                RaceConstants.Metaraces.HalfFiend,
                RaceConstants.Metaraces.Werebear,
                RaceConstants.Metaraces.Wereboar,
                RaceConstants.Metaraces.Wererat,
                RaceConstants.Metaraces.Weretiger,
                RaceConstants.Metaraces.Werewolf,
                RaceConstants.Metaraces.None,
                RaceConstants.Metaraces.Ghost,
                RaceConstants.Metaraces.Lich,
                RaceConstants.Metaraces.Vampire,
                CharacterClassConstants.Barbarian,
                CharacterClassConstants.Bard,
                CharacterClassConstants.Cleric,
                CharacterClassConstants.Druid,
                CharacterClassConstants.Fighter,
                CharacterClassConstants.Monk,
                CharacterClassConstants.Paladin,
                CharacterClassConstants.Ranger,
                CharacterClassConstants.Rogue,
                CharacterClassConstants.Sorcerer,
                CharacterClassConstants.Wizard,
                CharacterClassConstants.Adept,
                CharacterClassConstants.Aristocrat,
                CharacterClassConstants.Commoner,
                CharacterClassConstants.Expert,
                CharacterClassConstants.Warrior
            };

            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var allBaseRaces = baseRaceGroups[GroupConstants.All];
            names = names.Union(allBaseRaces).ToArray();

            AssertCollectionNames(names);
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar,
            LanguageConstants.Common,
            LanguageConstants.Celestial)]
        [TestCase(RaceConstants.BaseRaces.Bugbear,
            LanguageConstants.Common,
            LanguageConstants.Goblin)]
        [TestCase(RaceConstants.BaseRaces.Centaur,
            LanguageConstants.Sylvan,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling,
            LanguageConstants.Common,
            LanguageConstants.Halfling,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.Derro,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.BaseRaces.Drow,
            LanguageConstants.Common,
            LanguageConstants.Elven,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf,
            LanguageConstants.Common,
            LanguageConstants.Dwarven,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.Gnoll,
            LanguageConstants.Gnoll)]
        [TestCase(RaceConstants.BaseRaces.Goblin,
            LanguageConstants.Common,
            LanguageConstants.Goblin)]
        [TestCase(RaceConstants.BaseRaces.GrayElf,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.Grimlock,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.BaseRaces.FireGiant,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome,
            LanguageConstants.Common,
            LanguageConstants.Elven,
            LanguageConstants.Gnome,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.Metaraces.HalfCelestial,
            LanguageConstants.Celestial)]
        [TestCase(RaceConstants.Metaraces.HalfDragon,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.HalfElf,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.Metaraces.HalfFiend,
            LanguageConstants.Infernal)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc,
            LanguageConstants.Common,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Harpy,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.BaseRaces.HighElf,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.HillGiant,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin,
            LanguageConstants.Common,
            LanguageConstants.Goblin)]
        [TestCase(RaceConstants.BaseRaces.Human,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.BaseRaces.Janni,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.BaseRaces.Kobold,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling,
            LanguageConstants.Common,
            LanguageConstants.Halfling)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk,
            LanguageConstants.Common,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer,
            LanguageConstants.Common,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.Minotaur,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf,
            LanguageConstants.Common,
            LanguageConstants.Dwarven)]
        [TestCase(RaceConstants.BaseRaces.Ogre,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.OgreMage,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.Orc,
            LanguageConstants.Common,
            LanguageConstants.Orc)]
        [TestCase(RaceConstants.BaseRaces.Pixie,
            LanguageConstants.Common,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa,
            LanguageConstants.Common,
            LanguageConstants.Infernal)]
        [TestCase(RaceConstants.BaseRaces.RockGnome,
            LanguageConstants.Common,
            LanguageConstants.Gnome)]
        [TestCase(RaceConstants.BaseRaces.Satyr,
            LanguageConstants.Sylvan)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk,
            LanguageConstants.Common,
            LanguageConstants.Terran)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.StormGiant,
            LanguageConstants.Common,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin,
            LanguageConstants.Common,
            LanguageConstants.Gnome,
            LanguageConstants.Undercommon)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling,
            LanguageConstants.Common,
            LanguageConstants.Halfling)]
        [TestCase(RaceConstants.BaseRaces.Tiefling,
            LanguageConstants.Common,
            LanguageConstants.Infernal)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte,
            LanguageConstants.Draconic)]
        [TestCase(RaceConstants.BaseRaces.Troll,
            LanguageConstants.Giant)]
        [TestCase(RaceConstants.BaseRaces.WildElf,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.BaseRaces.WoodElf,
            LanguageConstants.Common,
            LanguageConstants.Elven)]
        [TestCase(RaceConstants.Metaraces.Werebear)]
        [TestCase(RaceConstants.Metaraces.Wereboar)]
        [TestCase(RaceConstants.Metaraces.Wererat)]
        [TestCase(RaceConstants.Metaraces.Weretiger)]
        [TestCase(RaceConstants.Metaraces.Werewolf)]
        [TestCase(RaceConstants.Metaraces.None)]
        [TestCase(RaceConstants.Metaraces.Ghost)]
        [TestCase(RaceConstants.Metaraces.Lich,
            LanguageConstants.Common)]
        [TestCase(RaceConstants.Metaraces.Vampire)]
        [TestCase(CharacterClassConstants.Barbarian)]
        [TestCase(CharacterClassConstants.Bard)]
        [TestCase(CharacterClassConstants.Cleric)]
        [TestCase(CharacterClassConstants.Druid,
            LanguageConstants.Druidic)]
        [TestCase(CharacterClassConstants.Fighter)]
        [TestCase(CharacterClassConstants.Monk)]
        [TestCase(CharacterClassConstants.Paladin)]
        [TestCase(CharacterClassConstants.Ranger)]
        [TestCase(CharacterClassConstants.Rogue)]
        [TestCase(CharacterClassConstants.Sorcerer)]
        [TestCase(CharacterClassConstants.Wizard)]
        [TestCase(CharacterClassConstants.Adept)]
        [TestCase(CharacterClassConstants.Aristocrat)]
        [TestCase(CharacterClassConstants.Commoner)]
        [TestCase(CharacterClassConstants.Expert)]
        [TestCase(CharacterClassConstants.Warrior)]
        public override void DistinctCollection(string name, params string[] languages)
        {
            base.DistinctCollection(name, languages);
        }
    }
}