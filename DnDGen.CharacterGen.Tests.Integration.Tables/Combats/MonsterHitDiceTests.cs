﻿using DnDGen.CharacterGen.Races;
using DnDGen.CharacterGen.Tables;
using NUnit.Framework;

namespace DnDGen.CharacterGen.Tests.Integration.Tables.Combats
{
    [TestFixture]
    public class MonsterHitDiceTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Adjustments.MonsterHitDice; }
        }

        [Test]
        public override void CollectionNames()
        {
            var baseRaceGroups = GetTable(TableNameConstants.Set.Collection.BaseRaceGroups);
            var monsters = baseRaceGroups[GroupConstants.Monsters];

            AssertCollectionNames(monsters);
        }

        [TestCase(RaceConstants.BaseRaces.AquaticElf, 0)]
        [TestCase(RaceConstants.BaseRaces.Azer, 2)]
        [TestCase(RaceConstants.BaseRaces.BlueSlaad, 8)]
        [TestCase(RaceConstants.BaseRaces.Bugbear, 3)]
        [TestCase(RaceConstants.BaseRaces.Centaur, 4)]
        [TestCase(RaceConstants.BaseRaces.CloudGiant, 17)]
        [TestCase(RaceConstants.BaseRaces.DeathSlaad, 15)]
        [TestCase(RaceConstants.BaseRaces.Derro, 3)]
        [TestCase(RaceConstants.BaseRaces.Doppelganger, 4)]
        [TestCase(RaceConstants.BaseRaces.FireGiant, 15)]
        [TestCase(RaceConstants.BaseRaces.FrostGiant, 14)]
        [TestCase(RaceConstants.BaseRaces.Gargoyle, 4)]
        [TestCase(RaceConstants.BaseRaces.Githyanki, 0)]
        [TestCase(RaceConstants.BaseRaces.Githzerai, 0)]
        [TestCase(RaceConstants.BaseRaces.Gnoll, 2)]
        [TestCase(RaceConstants.BaseRaces.Goblin, 0)]
        [TestCase(RaceConstants.BaseRaces.GraySlaad, 10)]
        [TestCase(RaceConstants.BaseRaces.GreenSlaad, 9)]
        [TestCase(RaceConstants.BaseRaces.Grimlock, 2)]
        [TestCase(RaceConstants.BaseRaces.Harpy, 7)]
        [TestCase(RaceConstants.BaseRaces.HillGiant, 12)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin, 0)]
        [TestCase(RaceConstants.BaseRaces.HoundArchon, 6)]
        [TestCase(RaceConstants.BaseRaces.Janni, 6)]
        [TestCase(RaceConstants.BaseRaces.Kapoacinth, 4)]
        [TestCase(RaceConstants.BaseRaces.Kobold, 0)]
        [TestCase(RaceConstants.BaseRaces.KuoToa, 2)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk, 2)]
        [TestCase(RaceConstants.BaseRaces.Locathah, 0)]
        [TestCase(RaceConstants.BaseRaces.Merfolk, 0)]
        [TestCase(RaceConstants.BaseRaces.Merrow, 4)]
        [TestCase(RaceConstants.BaseRaces.MindFlayer, 8)]
        [TestCase(RaceConstants.BaseRaces.Minotaur, 6)]
        [TestCase(RaceConstants.BaseRaces.Mummy, 8)]
        [TestCase(RaceConstants.BaseRaces.Ogre, 4)]
        [TestCase(RaceConstants.BaseRaces.OgreMage, 5)]
        [TestCase(RaceConstants.BaseRaces.Orc, 0)]
        [TestCase(RaceConstants.BaseRaces.Pixie, 0)]
        [TestCase(RaceConstants.BaseRaces.Rakshasa, 7)]
        [TestCase(RaceConstants.BaseRaces.RedSlaad, 7)]
        [TestCase(RaceConstants.BaseRaces.Sahuagin, 2)]
        [TestCase(RaceConstants.BaseRaces.Satyr, 5)]
        [TestCase(RaceConstants.BaseRaces.Scorpionfolk, 12)]
        [TestCase(RaceConstants.BaseRaces.Scrag, 6)]
        [TestCase(RaceConstants.BaseRaces.StoneGiant, 14)]
        [TestCase(RaceConstants.BaseRaces.StormGiant, 19)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte, 2)]
        [TestCase(RaceConstants.BaseRaces.Troll, 6)]
        [TestCase(RaceConstants.BaseRaces.YuanTiAbomination, 9)]
        [TestCase(RaceConstants.BaseRaces.YuanTiHalfblood, 7)]
        [TestCase(RaceConstants.BaseRaces.YuanTiPureblood, 4)]
        public void MonsterHitDice(string monster, int hitDice)
        {
            base.Adjustment(monster, hitDice);
        }
    }
}