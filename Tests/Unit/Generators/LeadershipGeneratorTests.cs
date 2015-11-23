﻿using CharacterGen.Common;
using CharacterGen.Common.Alignments;
using CharacterGen.Generators;
using CharacterGen.Generators.Domain;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using CharacterGen.Selectors;
using CharacterGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CharacterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class LeadershipGeneratorTests
    {
        private ILeadershipGenerator leadershipGenerator;
        private Mock<ICharacterGenerator> mockCharacterGenerator;
        private Mock<ILeadershipSelector> mockLeadershipSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAdjustmentsSelector> mockAdjustmentsSelector;
        private Mock<ISetLevelRandomizer> mockSetLevelRandomizer;
        private Mock<ISetAlignmentRandomizer> mockSetAlignmentRandomizer;
        private Mock<IAlignmentRandomizer> mockAnyAlignmentRandomizer;
        private Mock<IClassNameRandomizer> mockAnyClassNameRandomizer;
        private Mock<RaceRandomizer> mockAnyBaseRaceRandomizer;
        private Mock<RaceRandomizer> mockAnyMetaraceRandomizer;
        private Mock<IStatsRandomizer> mockRawStatRandomizer;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<IAlignmentGenerator> mockAlignmentGenerator;
        private Generator generator;
        private List<String> allowedAlignments;
        private String leaderAlignment;
        private FollowerQuantities followerQuantities;

        [SetUp]
        public void Setup()
        {
            mockCharacterGenerator = new Mock<ICharacterGenerator>();
            mockLeadershipSelector = new Mock<ILeadershipSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAdjustmentsSelector = new Mock<IAdjustmentsSelector>();
            mockSetLevelRandomizer = new Mock<ISetLevelRandomizer>();
            mockSetAlignmentRandomizer = new Mock<ISetAlignmentRandomizer>();
            mockAnyAlignmentRandomizer = new Mock<IAlignmentRandomizer>();
            mockAnyClassNameRandomizer = new Mock<IClassNameRandomizer>();
            mockAnyBaseRaceRandomizer = new Mock<RaceRandomizer>();
            mockAnyMetaraceRandomizer = new Mock<RaceRandomizer>();
            mockRawStatRandomizer = new Mock<IStatsRandomizer>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockAlignmentGenerator = new Mock<IAlignmentGenerator>();
            generator = new ConfigurableIterationGenerator(2);
            leadershipGenerator = new LeadershipGenerator(mockCharacterGenerator.Object, mockLeadershipSelector.Object, mockPercentileSelector.Object,
                mockAdjustmentsSelector.Object, mockSetLevelRandomizer.Object, mockSetAlignmentRandomizer.Object, mockAnyAlignmentRandomizer.Object,
                mockAnyClassNameRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object,
                mockBooleanPercentileSelector.Object, mockCollectionsSelector.Object, mockAlignmentGenerator.Object, generator);
            allowedAlignments = new List<String>();
            followerQuantities = new FollowerQuantities();

            mockLeadershipSelector.Setup(s => s.SelectFollowerQuantitiesFor(It.IsAny<Int32>())).Returns(new FollowerQuantities());
            mockSetLevelRandomizer.SetupAllProperties();
            mockSetAlignmentRandomizer.SetupAllProperties();
            leaderAlignment = "leader alignment";
            allowedAlignments.Add(leaderAlignment);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.AlignmentGroups, leaderAlignment))
                .Returns(allowedAlignments);

            mockAlignmentGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object)).Returns((IAlignmentRandomizer r) => (r as ISetAlignmentRandomizer).SetAlignment);
            mockAlignmentGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object)).Returns(new Alignment("any alignment"));
        }

        [Test]
        public void LeadershipScoreIsLevelPlusCharismaModifier()
        {
            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.Score, Is.EqualTo(99476));
            Assert.That(leadership.CohortScore, Is.EqualTo(99476));
        }

        [Test]
        public void CharacterReputationGenerated()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Percentile.Reputation)).Returns("reputable");

            var reputationAjustments = new Dictionary<String, Int32>();
            reputationAjustments["reputable"] = 0;
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.LeadershipModifiers)).Returns(reputationAjustments);

            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.LeadershipModifiers, Contains.Item("reputable"));
        }

        [Test]
        public void CharacterReputationAdjustmentIsApplied()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Percentile.Reputation)).Returns("reputable");

            var reputationAjustments = new Dictionary<String, Int32>();
            reputationAjustments["reputable"] = 42;
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.LeadershipModifiers)).Returns(reputationAjustments);

            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.LeadershipModifiers, Contains.Item("reputable"));
            Assert.That(leadership.Score, Is.EqualTo(99518));
            Assert.That(leadership.CohortScore, Is.EqualTo(99518));
        }

        [Test]
        public void NegativeCharacterReputationAdjustmentIsApplied()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Percentile.Reputation)).Returns("reputable");

            var reputationAjustments = new Dictionary<String, Int32>();
            reputationAjustments["reputable"] = -42;
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.LeadershipModifiers)).Returns(reputationAjustments);

            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.LeadershipModifiers, Contains.Item("reputable"));
            Assert.That(leadership.Score, Is.EqualTo(99434));
            Assert.That(leadership.CohortScore, Is.EqualTo(99434));
        }

        [Test]
        public void AnimalsDecreaseCohortScoreBy2()
        {
            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, "animal");
            Assert.That(leadership.Score, Is.EqualTo(99476));
            Assert.That(leadership.CohortScore, Is.EqualTo(99474));
        }

        [Test]
        public void KillingCohortsDecreasesScoreOfAttractingCohorts()
        {
            mockBooleanPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Set.TrueOrFalse.KilledCohort)).Returns(true).Returns(false);

            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.Score, Is.EqualTo(99476));
            Assert.That(leadership.CohortScore, Is.EqualTo(99474));
            Assert.That(leadership.LeadershipModifiers, Contains.Item("Caused the death of 1 cohort(s)"));
        }

        [Test]
        public void KillingMultipleCohortsDecreasesScoreOfAttractingCohorts()
        {
            mockBooleanPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Set.TrueOrFalse.KilledCohort)).Returns(true).Returns(true).Returns(false);

            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.Score, Is.EqualTo(99476));
            Assert.That(leadership.CohortScore, Is.EqualTo(99472));
            Assert.That(leadership.LeadershipModifiers, Contains.Item("Caused the death of 2 cohort(s)"));
        }

        [Test]
        public void GetFollowerQuantities()
        {
            mockLeadershipSelector.Setup(s => s.SelectFollowerQuantitiesFor(99476)).Returns(followerQuantities);
            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.FollowerQuantities, Is.EqualTo(followerQuantities));
        }

        [Test]
        public void GenerateLeadershipMovementFactorsAndApplyThem()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Percentile.LeadershipMovement)).Returns("moves");

            var leadershipAdjustments = new Dictionary<String, Int32>();
            leadershipAdjustments["moves"] = 42;
            leadershipAdjustments["murders"] = -5;

            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.LeadershipModifiers)).Returns(leadershipAdjustments);
            mockLeadershipSelector.Setup(s => s.SelectFollowerQuantitiesFor(99518)).Returns(followerQuantities);

            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.Score, Is.EqualTo(99476));
            Assert.That(leadership.CohortScore, Is.EqualTo(99476));
            Assert.That(leadership.FollowerQuantities, Is.EqualTo(followerQuantities));
        }

        [Test]
        public void CharacterDoesNotHaveEmptyLeadershipModifiers()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Percentile.LeadershipMovement)).Returns(String.Empty);
            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.LeadershipModifiers, Is.Empty);
        }

        [Test]
        public void GenerateWhetherCharacterHasCausedFollowerDeathsAndApply()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.TrueOrFalse.KilledFollowers)).Returns(true);
            mockLeadershipSelector.Setup(s => s.SelectFollowerQuantitiesFor(99475)).Returns(followerQuantities);

            var leadership = leadershipGenerator.GenerateLeadership(9266, 90210, String.Empty);
            Assert.That(leadership.Score, Is.EqualTo(99476));
            Assert.That(leadership.CohortScore, Is.EqualTo(99476));
            Assert.That(leadership.FollowerQuantities, Is.EqualTo(followerQuantities));
        }

        [Test]
        public void GenerateCohort()
        {
            mockLeadershipSelector.Setup(s => s.SelectCohortLevelFor(9266)).Returns(42);

            var cohort = new Character();
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object))
                .Returns(cohort);

            var generatedCohort = leadershipGenerator.GenerateCohort(9266, 90210, leaderAlignment);
            Assert.That(generatedCohort, Is.EqualTo(cohort));
            mockSetLevelRandomizer.VerifySet(r => r.SetLevel = 42);
        }

        [Test]
        public void CohortLevelIs2LessThanLeaderLevel()
        {
            mockLeadershipSelector.Setup(s => s.SelectCohortLevelFor(9266)).Returns(90210);

            var cohort = new Character();
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object))
                .Returns(cohort);

            var generatedCohort = leadershipGenerator.GenerateCohort(9266, 42, leaderAlignment);
            Assert.That(generatedCohort, Is.EqualTo(cohort));
            mockSetLevelRandomizer.VerifySet(r => r.SetLevel = 40);
        }

        [Test]
        public void AttractCohortOfSameAlignment()
        {
            mockLeadershipSelector.Setup(s => s.SelectCohortLevelFor(9266)).Returns(42);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.TrueOrFalse.AttractCohortOfDifferentAlignment)).Returns(false);

            var cohort = new Character();
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object))
                .Returns(cohort);

            var generatedCohort = leadershipGenerator.GenerateCohort(9266, 90210, leaderAlignment);
            Assert.That(generatedCohort, Is.EqualTo(cohort));
            mockSetAlignmentRandomizer.VerifySet(r => r.SetAlignment = new Alignment(leaderAlignment));
        }

        [Test]
        public void AttractCohortOfDifferingAlignment()
        {
            mockLeadershipSelector.Setup(s => s.SelectCohortLevelFor(9265)).Returns(42);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.TrueOrFalse.AttractCohortOfDifferentAlignment)).Returns(true);

            var incompatibleAlignment = new Alignment("incompatible alignment");
            var cohortAlignment = new Alignment("cohort alignment");

            allowedAlignments.Add(cohortAlignment.ToString());

            mockAlignmentGenerator.SetupSequence(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object))
                .Returns(incompatibleAlignment).Returns(cohortAlignment);

            var cohort = new Character();
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object))
                .Returns(cohort);

            var generatedCohort = leadershipGenerator.GenerateCohort(9266, 90210, leaderAlignment);
            Assert.That(generatedCohort, Is.EqualTo(cohort));
            mockSetAlignmentRandomizer.VerifySet(r => r.SetAlignment = cohortAlignment);
        }

        [Test]
        public void IfSelectedCohortLevelIs0_DoNotGenerateCohort()
        {
            mockLeadershipSelector.Setup(s => s.SelectCohortLevelFor(9266)).Returns(0);

            var cohort = new Character();
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object))
                .Returns(cohort);

            var generatedCohort = leadershipGenerator.GenerateCohort(9266, 90210, leaderAlignment);
            Assert.That(generatedCohort, Is.Null);
        }

        [Test]
        public void FollowerGenerated()
        {
            var follower = new Character();
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object))
                .Returns(follower);

            var generatedFollower = leadershipGenerator.GenerateFollower(9266, leaderAlignment);
            Assert.That(generatedFollower, Is.EqualTo(follower));
            mockSetLevelRandomizer.VerifySet(r => r.SetLevel = 9266);
        }

        [Test]
        public void FollowerCannotOpposeAlignment()
        {
            var incompatibleAlignment = new Alignment("incompatible alignment");
            var followerAlignment = new Alignment("cohort alignment");

            allowedAlignments.Add(followerAlignment.ToString());

            mockAlignmentGenerator.SetupSequence(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object))
                .Returns(incompatibleAlignment).Returns(followerAlignment);

            var follower = new Character();
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockSetAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatRandomizer.Object))
                .Returns(follower);

            var generatedFollower = leadershipGenerator.GenerateFollower(9266, leaderAlignment);
            Assert.That(generatedFollower, Is.EqualTo(follower));
            mockSetLevelRandomizer.VerifySet(r => r.SetLevel = 9266);
            mockSetAlignmentRandomizer.VerifySet(r => r.SetAlignment = followerAlignment);
        }
    }
}
