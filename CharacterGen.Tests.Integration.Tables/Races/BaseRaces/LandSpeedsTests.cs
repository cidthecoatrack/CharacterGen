﻿using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces
{
    [TestFixture]
    public class LandSpeedsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Adjustments.LandSpeeds; }
        }

        [Test]
        public override void CollectionNames()
        {
            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            AssertCollectionNames(baseRaceGroups[GroupConstants.All]);
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar, 30)]
        [TestCase(RaceConstants.BaseRaces.Bugbear, 30)]
        [TestCase(RaceConstants.BaseRaces.Centaur, 50)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant, 50)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf, 20)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling, 20)]
        [TestCase(RaceConstants.BaseRaces.Derro, 20)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger, 30)]
        [TestCase(RaceConstants.BaseRaces.Drow, 30)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf, 20)]
        [TestCase(RaceConstants.BaseRaces.FireGiant, 40)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome, 20)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant, 40)]
        [TestCase(RaceConstants.BaseRaces.Gnoll, 30)]
        [TestCase(RaceConstants.BaseRaces.Goblin, 30)]
        [TestCase(RaceConstants.BaseRaces.GrayElf, 30)]
        [TestCase(RaceConstants.BaseRaces.Grimlock, 30)]
        [TestCase(RaceConstants.BaseRaces.HalfElf, 30)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc, 30)]
        [TestCase(RaceConstants.BaseRaces.Harpy, 20)]
        [TestCase(RaceConstants.BaseRaces.HighElf, 30)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf, 20)]
        [TestCase(RaceConstants.BaseRaces.HillGiant, 40)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin, 30)]
        [TestCase(RaceConstants.BaseRaces.Human, 30)]
        [TestCase(RaceConstants.BaseRaces.Janni, 30)]
        [TestCase(RaceConstants.BaseRaces.Kobold, 30)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling, 20)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk, 30)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer, 30)]
        [TestCase(RaceConstants.BaseRaces.Minotaur, 30)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf, 20)]
        [TestCase(RaceConstants.BaseRaces.Ogre, 40)]
        [TestCase(RaceConstants.BaseRaces.OgreMage, 50)]
        [TestCase(RaceConstants.BaseRaces.Orc, 30)]
        [TestCase(RaceConstants.BaseRaces.Pixie, 20)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa, 40)]
        [TestCase(RaceConstants.BaseRaces.RockGnome, 20)]
        [TestCase(RaceConstants.BaseRaces.Satyr, 40)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk, 40)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant, 40)]
        [TestCase(RaceConstants.BaseRaces.StormGiant, 50)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin, 20)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling, 20)]
        [TestCase(RaceConstants.BaseRaces.Tiefling, 30)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte, 30)]
        [TestCase(RaceConstants.BaseRaces.Troll, 30)]
        [TestCase(RaceConstants.BaseRaces.WildElf, 30)]
        [TestCase(RaceConstants.BaseRaces.WoodElf, 30)]
        public override void Adjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}