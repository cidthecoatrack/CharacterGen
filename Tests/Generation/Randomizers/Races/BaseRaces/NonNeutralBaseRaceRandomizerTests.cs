﻿using NPCGen.Core.Data.Races;
using NPCGen.Core.Generation.Randomizers.Races.BaseRaces;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Races.BaseRaces
{
    [TestFixture]
    public class NonNeutralBaseRaceRandomizerTests : BaseRaceRandomizerTests
    {
        [SetUp]
        public void Setup()
        {
            randomizer = new NonNeutralBaseRaceRandomizer(mockPercentileResultProvider.Object, mockLevelAdjustmentsProvider.Object);
        }

        [Test]
        public void AasimarIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Aasimar);
        }

        [Test]
        public void BugbearIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Bugbear);
        }

        [Test]
        public void DeepDwarfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.DeepDwarf);
        }

        [Test]
        public void DeepHalflingIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.DeepHalfling);
        }

        [Test]
        public void DerroDwarfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Derro);
        }

        [Test]
        public void DoppelgangerIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.BaseRaces.Doppelganger);
        }

        [Test]
        public void DrowIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Drow);
        }

        [Test]
        public void DuergarIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.DuergarDwarf);
        }

        [Test]
        public void ForestGnomeIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.ForestGnome);
        }

        [Test]
        public void GnollIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Gnoll);
        }

        [Test]
        public void GoblinIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Goblin);
        }

        [Test]
        public void GrayElfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.GrayElf);
        }

        [Test]
        public void HalfElfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.HalfElf);
        }

        [Test]
        public void HalfOrcIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.HalfOrc);
        }

        [Test]
        public void HighElfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.HighElf);
        }

        [Test]
        public void HillDwarfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.HillDwarf);
        }

        [Test]
        public void HobgoblinIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Hobgoblin);
        }

        [Test]
        public void HumanIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Human);
        }

        [Test]
        public void KoboldIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Kobold);
        }

        [Test]
        public void LightfootHalflingIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.LightfootHalfling);
        }

        [Test]
        public void LizardfolkIsNotAllowed()
        {
            AssertRaceIsNotAllowed(RaceConstants.BaseRaces.Lizardfolk);
        }

        [Test]
        public void MindFlayerIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.MindFlayer);
        }

        [Test]
        public void MinotaurIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Minotaur);
        }

        [Test]
        public void MountainDwarfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.MountainDwarf);
        }

        [Test]
        public void OgreIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Ogre);
        }

        [Test]
        public void OgreMageIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.OgreMage);
        }

        [Test]
        public void OrcIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Orc);
        }

        [Test]
        public void RockGnomeIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.RockGnome);
        }

        [Test]
        public void SvirfneblinIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Svirfneblin);
        }

        [Test]
        public void TallfellowHalflingIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.TallfellowHalfling);
        }

        [Test]
        public void TieflingIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Tiefling);
        }

        [Test]
        public void TroglodyteIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.Troglodyte);
        }

        [Test]
        public void WildElfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.WildElf);
        }

        [Test]
        public void WoodElfIsAllowed()
        {
            AssertRaceIsAllowed(RaceConstants.BaseRaces.WoodElf);
        }
    }
}