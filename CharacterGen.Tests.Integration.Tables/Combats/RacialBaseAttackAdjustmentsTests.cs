﻿using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Combats
{
    [TestFixture]
    public class RacialBaseAttackAdjustmentsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Adjustments.RacialBaseAttackAdjustments; }
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
                RaceConstants.Metaraces.Vampire
            };

            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var allBaseRaces = baseRaceGroups[GroupConstants.All];
            names = names.Union(allBaseRaces).ToArray();

            AssertCollectionNames(names);
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar, 0)]
        [TestCase(RaceConstants.BaseRaces.Bugbear, 2)]
        [TestCase(RaceConstants.BaseRaces.Centaur, 4)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant, 12)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf, 0)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling, 0)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger, 4)]
        [TestCase(RaceConstants.BaseRaces.Derro, 3)]
        [TestCase(RaceConstants.BaseRaces.Drow, 0)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf, 0)]
        [TestCase(RaceConstants.BaseRaces.FireGiant, 11)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome, 0)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant, 10)]
        [TestCase(RaceConstants.BaseRaces.GrayElf, 0)]
        [TestCase(RaceConstants.BaseRaces.Gnoll, 1)]
        [TestCase(RaceConstants.BaseRaces.Goblin, 0)]
        [TestCase(RaceConstants.BaseRaces.Grimlock, 2)]
        [TestCase(RaceConstants.BaseRaces.HalfElf, 0)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc, 0)]
        [TestCase(RaceConstants.BaseRaces.Harpy, 7)]
        [TestCase(RaceConstants.BaseRaces.HighElf, 0)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf, 0)]
        [TestCase(RaceConstants.BaseRaces.HillGiant, 9)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin, 0)]
        [TestCase(RaceConstants.BaseRaces.Human, 0)]
        [TestCase(RaceConstants.BaseRaces.Janni, 6)]
        [TestCase(RaceConstants.BaseRaces.Kobold, 0)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling, 0)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk, 1)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer, 6)]
        [TestCase(RaceConstants.BaseRaces.Minotaur, 6)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf, 0)]
        [TestCase(RaceConstants.BaseRaces.Ogre, 3)]
        [TestCase(RaceConstants.BaseRaces.OgreMage, 3)]
        [TestCase(RaceConstants.BaseRaces.Orc, 0)]
        [TestCase(RaceConstants.BaseRaces.Pixie, 0)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa, 7)]
        [TestCase(RaceConstants.BaseRaces.RockGnome, 0)]
        [TestCase(RaceConstants.BaseRaces.Satyr, 2)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk, 12)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant, 10)]
        [TestCase(RaceConstants.BaseRaces.StormGiant, 14)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin, 0)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling, 0)]
        [TestCase(RaceConstants.BaseRaces.Tiefling, 0)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte, 1)]
        [TestCase(RaceConstants.BaseRaces.Troll, 4)]
        [TestCase(RaceConstants.BaseRaces.WildElf, 0)]
        [TestCase(RaceConstants.BaseRaces.WoodElf, 0)]
        [TestCase(RaceConstants.Metaraces.HalfCelestial, 0)]
        [TestCase(RaceConstants.Metaraces.HalfDragon, 0)]
        [TestCase(RaceConstants.Metaraces.HalfFiend, 0)]
        [TestCase(RaceConstants.Metaraces.Ghost, 0)]
        [TestCase(RaceConstants.Metaraces.Lich, 0)]
        [TestCase(RaceConstants.Metaraces.None, 0)]
        [TestCase(RaceConstants.Metaraces.Vampire, 0)]
        [TestCase(RaceConstants.Metaraces.Werebear, 4)]
        [TestCase(RaceConstants.Metaraces.Wereboar, 2)]
        [TestCase(RaceConstants.Metaraces.Wererat, 0)]
        [TestCase(RaceConstants.Metaraces.Weretiger, 4)]
        [TestCase(RaceConstants.Metaraces.Werewolf, 1)]
        public override void Adjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}