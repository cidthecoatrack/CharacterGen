﻿using CharacterGen.Alignments;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces.Neutral
{
    [TestFixture]
    public class NeutralFighterBaseRacesTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Percentile.GOODNESSCLASSBaseRaces, AlignmentConstants.Neutral, CharacterClassConstants.Fighter); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, RaceConstants.BaseRaces.DeepDwarf)]
        [TestCase(11, 29, RaceConstants.BaseRaces.HillDwarf)]
        [TestCase(30, 34, RaceConstants.BaseRaces.MountainDwarf)]
        [TestCase(35, 35, RaceConstants.BaseRaces.HighElf)]
        [TestCase(36, 41, RaceConstants.BaseRaces.WoodElf)]
        [TestCase(42, 46, RaceConstants.BaseRaces.HalfElf)]
        [TestCase(47, 47, RaceConstants.BaseRaces.LightfootHalfling)]
        [TestCase(48, 48, RaceConstants.BaseRaces.DeepHalfling)]
        [TestCase(49, 58, RaceConstants.BaseRaces.HalfOrc)]
        [TestCase(59, 97, RaceConstants.BaseRaces.Human)]
        [TestCase(98, 98, RaceConstants.BaseRaces.Lizardfolk)]
        [TestCase(99, 99, RaceConstants.BaseRaces.Doppelganger)]
        [TestCase(100, 100, RaceConstants.BaseRaces.Janni)]
        public override void Percentile(int lower, int upper, string content)
        {
            base.Percentile(lower, upper, content);
        }
    }
}