﻿using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces.Ages.Rolls
{
    [TestFixture]
    public class TrainedAgeRollsTests : CollectionTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Collection.CLASSTYPEAgeRolls, CharacterClassConstants.TrainingTypes.Trained); }
        }

        [Test]
        public override void CollectionNames()
        {
            var baseRaceGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.BaseRaceGroups);
            var allBaseRaces = baseRaceGroups[GroupConstants.All];

            AssertCollectionNames(allBaseRaces);
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar, "8d6")]
        [TestCase(RaceConstants.BaseRaces.Bugbear, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Centaur, "3d6")]
        [TestCase(RaceConstants.BaseRaces.CloudGiant, "6d20")]
        [TestCase(RaceConstants.BaseRaces.DeepDwarf, "7d6")]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling, "4d6")]
        [TestCase(RaceConstants.BaseRaces.Derro, "7d6")]
        [TestCase(RaceConstants.BaseRaces.Doppelganger, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Drow, "10d6")]
        [TestCase(RaceConstants.BaseRaces.DuergarDwarf, "7d6")]
        [TestCase(RaceConstants.BaseRaces.FireGiant, "9d12")]
        [TestCase(RaceConstants.BaseRaces.ForestGnome, "9d6")]
        [TestCase(RaceConstants.BaseRaces.FrostGiant, "6d12")]
        [TestCase(RaceConstants.BaseRaces.Gnoll, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Goblin, "2d6")]
        [TestCase(RaceConstants.BaseRaces.GrayElf, "10d6")]
        [TestCase(RaceConstants.BaseRaces.Grimlock, "2d6")]
        [TestCase(RaceConstants.BaseRaces.HalfElf, "3d6")]
        [TestCase(RaceConstants.BaseRaces.HalfOrc, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Harpy, "2d4")]
        [TestCase(RaceConstants.BaseRaces.HighElf, "10d6")]
        [TestCase(RaceConstants.BaseRaces.HillDwarf, "7d6")]
        [TestCase(RaceConstants.BaseRaces.HillGiant, "5d12")]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Human, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Janni, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Kobold, "2d6")]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling, "3d6")]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk, "1d10")]
        [TestCase(RaceConstants.BaseRaces.MindFlayer, "5d8")]
        [TestCase(RaceConstants.BaseRaces.Minotaur, "2d6")]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf, "7d6")]
        [TestCase(RaceConstants.BaseRaces.Ogre, "4d6")]
        [TestCase(RaceConstants.BaseRaces.OgreMage, "4d6")]
        [TestCase(RaceConstants.BaseRaces.Orc, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Pixie, "2d4")]
        [TestCase(RaceConstants.BaseRaces.Rakshasa, "2d6")]
        [TestCase(RaceConstants.BaseRaces.RockGnome, "9d6")]
        [TestCase(RaceConstants.BaseRaces.Satyr, "2d12")]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk, "2d6")]
        [TestCase(RaceConstants.BaseRaces.StoneGiant, "12d20")]
        [TestCase(RaceConstants.BaseRaces.StormGiant, "9d20")]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin, "9d6")]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling, "3d6")]
        [TestCase(RaceConstants.BaseRaces.Tiefling, "8d6")]
        [TestCase(RaceConstants.BaseRaces.Troglodyte, "2d6")]
        [TestCase(RaceConstants.BaseRaces.Troll, "2d6")]
        [TestCase(RaceConstants.BaseRaces.WildElf, "10d6")]
        [TestCase(RaceConstants.BaseRaces.WoodElf, "10d6")]
        public void TrainedAgeRoll(string name, string ageRoll)
        {
            DistinctCollection(name, ageRoll);
        }
    }
}
