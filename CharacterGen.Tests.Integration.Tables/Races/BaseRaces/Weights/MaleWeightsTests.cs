﻿using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces.Weights
{
    [TestFixture]
    public class MaleWeightsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Adjustments.GENDERWeights, "Male"); }
        }

        [Test]
        public override void CollectionNames()
        {
            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var allBaseRaces = baseRaceGroups[GroupConstants.All];

            AssertCollectionNames(allBaseRaces);
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar, 110)]
        [TestCase(RaceConstants.BaseRaces.Bugbear, 250)]
        [TestCase(RaceConstants.BaseRaces.Centaur, 400)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant, 4300)]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf, 130)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling, 30)]
        [TestCase(RaceConstants.BaseRaces.Derro, 130)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger, 120)]
        [TestCase(RaceConstants.BaseRaces.Drow, 85)]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf, 130)]
        [TestCase(RaceConstants.BaseRaces.FireGiant, 6300)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome, 40)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant, 2100)]
        [TestCase(RaceConstants.BaseRaces.Gnoll, 170)]
        [TestCase(RaceConstants.BaseRaces.Goblin, 30)]
        [TestCase(RaceConstants.BaseRaces.GrayElf, 85)]
        [TestCase(RaceConstants.BaseRaces.Grimlock, 120)]
        [TestCase(RaceConstants.BaseRaces.HalfElf, 100)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc, 150)]
        [TestCase(RaceConstants.BaseRaces.Harpy, 65)]
        [TestCase(RaceConstants.BaseRaces.HighElf, 85)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf, 130)]
        [TestCase(RaceConstants.BaseRaces.HillGiant, 400)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin, 165)]
        [TestCase(RaceConstants.BaseRaces.Human, 120)]
        [TestCase(RaceConstants.BaseRaces.Janni, 120)]
        [TestCase(RaceConstants.BaseRaces.Kobold, 25)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling, 30)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk, 150)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer, 110)]
        [TestCase(RaceConstants.BaseRaces.Minotaur, 500)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf, 130)]
        [TestCase(RaceConstants.BaseRaces.Ogre, 620)]
        [TestCase(RaceConstants.BaseRaces.OgreMage, 620)]
        [TestCase(RaceConstants.BaseRaces.Orc, 160)]
        [TestCase(RaceConstants.BaseRaces.Pixie, 6)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa, 120)]
        [TestCase(RaceConstants.BaseRaces.RockGnome, 40)]
        [TestCase(RaceConstants.BaseRaces.Satyr, 170)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk, 240)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant, 800)]
        [TestCase(RaceConstants.BaseRaces.StormGiant, 11300)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin, 40)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling, 30)]
        [TestCase(RaceConstants.BaseRaces.Tiefling, 110)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte, 120)]
        [TestCase(RaceConstants.BaseRaces.Troll, 440)]
        [TestCase(RaceConstants.BaseRaces.WildElf, 85)]
        [TestCase(RaceConstants.BaseRaces.WoodElf, 85)]
        public void MaleWeight(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}
