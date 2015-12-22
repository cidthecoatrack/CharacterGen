﻿using CharacterGen.Common.Alignments;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Common.Races;
using CharacterGen.Tables;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces.Neutral
{
    [TestFixture]
    public class NeutralCommonerBaseRacesTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Percentile.GOODNESSCLASSBaseRaces, AlignmentConstants.Neutral, CharacterClassConstants.Commoner); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(RaceConstants.BaseRaces.HalfElf, 1, 10)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc, 11, 15)]
        [TestCase(RaceConstants.BaseRaces.HighElf, 16, 25)]
        [TestCase(RaceConstants.BaseRaces.HillDwarf, 26, 35)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling, 36, 45)]
        [TestCase(RaceConstants.BaseRaces.MountainDwarf, 46, 50)]
        [TestCase(RaceConstants.BaseRaces.Human, 51, 95)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(RaceConstants.BaseRaces.GrayElf, 96)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk, 97)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling, 98)]
        [TestCase(RaceConstants.BaseRaces.WoodElf, 99)]
        [TestCase(RaceConstants.BaseRaces.WildElf, 100)]
        public override void Percentile(string content, int roll)
        {
            base.Percentile(content, roll);
        }
    }
}
