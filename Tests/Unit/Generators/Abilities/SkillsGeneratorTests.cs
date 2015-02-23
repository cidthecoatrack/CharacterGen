﻿using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using Moq;
using NPCGen.Common.Abilities.Skills;
using NPCGen.Common.Abilities.Stats;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Races;
using NPCGen.Generators.Abilities;
using NPCGen.Generators.Interfaces.Abilities;
using NPCGen.Selectors.Interfaces;
using NPCGen.Selectors.Interfaces.Objects;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Abilities
{
    [TestFixture]
    public class SkillsGeneratorTests
    {
        private ISkillsGenerator skillsGenerator;
        private Mock<IAdjustmentsSelector> mockAdjustmentsSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private CharacterClass characterClass;
        private Dictionary<String, Stat> stats;
        private List<String> classSkills;
        private List<String> crossClassSkills;
        private Mock<ISkillSelector> mockSkillSelector;
        private Mock<IDice> mockDice;
        private Stat intelligence;
        private Dictionary<String, Int32> skillPoints;
        private Race race;

        [SetUp]
        public void Setup()
        {
            mockAdjustmentsSelector = new Mock<IAdjustmentsSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSkillSelector = new Mock<ISkillSelector>();
            mockDice = new Mock<IDice>();
            skillsGenerator = new SkillsGenerator(mockSkillSelector.Object, mockDice.Object, mockCollectionsSelector.Object, mockAdjustmentsSelector.Object);
            characterClass = new CharacterClass();
            stats = new Dictionary<String, Stat>();
            classSkills = new List<String>();
            crossClassSkills = new List<String>();
            intelligence = new Stat { Value = 10 };
            race = new Race();

            characterClass.ClassName = "class name";
            characterClass.Level = 5;
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ClassSkills, "class name")).Returns(classSkills);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.CrossClassSkills, "class name")).Returns(crossClassSkills);
            var selection = new SkillSelection { BaseStatName = StatConstants.Intelligence };
            mockSkillSelector.Setup(s => s.SelectFor(It.IsAny<String>())).Returns(selection);
            stats[StatConstants.Intelligence] = intelligence;

            var emptyAdjustments = new Dictionary<String, Int32>();
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(emptyAdjustments);

            skillPoints = new Dictionary<String, Int32>();
            skillPoints[characterClass.ClassName] = 0;
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillPointsForClasses)).Returns(skillPoints);
            mockDice.Setup(d => d.Roll(1).d3()).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(It.IsAny<Int32>())).Returns(1);
        }

        [TestCase(1, 4)]
        [TestCase(2, 5)]
        [TestCase(3, 6)]
        [TestCase(4, 7)]
        [TestCase(5, 8)]
        [TestCase(6, 9)]
        [TestCase(7, 10)]
        [TestCase(8, 11)]
        [TestCase(9, 12)]
        [TestCase(10, 13)]
        [TestCase(11, 14)]
        [TestCase(12, 15)]
        [TestCase(13, 16)]
        [TestCase(14, 17)]
        [TestCase(15, 18)]
        [TestCase(16, 19)]
        [TestCase(17, 20)]
        [TestCase(18, 21)]
        [TestCase(19, 22)]
        [TestCase(20, 23)]
        public void GetSkillPointsPerLevel(Int32 level, Int32 points)
        {
            characterClass.Level = level;
            skillPoints[characterClass.ClassName] = 1;
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(points));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(0));
        }

        [Test]
        public void GetSkillPointsForClass()
        {
            skillPoints[characterClass.ClassName] = 2;
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("skill 3");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(8));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(8));
            Assert.That(skills["skill 3"].Ranks, Is.EqualTo(0));
        }

        [TestCase(1, 4)]
        [TestCase(2, 5)]
        [TestCase(3, 6)]
        [TestCase(4, 7)]
        [TestCase(5, 8)]
        [TestCase(6, 9)]
        [TestCase(7, 10)]
        [TestCase(8, 11)]
        [TestCase(9, 12)]
        [TestCase(10, 13)]
        [TestCase(11, 14)]
        [TestCase(12, 15)]
        [TestCase(13, 16)]
        [TestCase(14, 17)]
        [TestCase(15, 18)]
        [TestCase(16, 19)]
        [TestCase(17, 20)]
        [TestCase(18, 21)]
        [TestCase(19, 22)]
        [TestCase(20, 23)]
        public void AddIntelligenceBonusToSkillPointsPerLevel(Int32 level, Int32 points)
        {
            characterClass.Level = level;
            skillPoints[characterClass.ClassName] = 0;
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            intelligence.Value = 12;

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(points));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(0));
        }

        [Test]
        public void GetClassSkills()
        {
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("skill 3");
            classSkills.Add("skill 4");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            foreach (var skill in classSkills)
                Assert.That(skills.Keys, Contains.Item(skill));
            Assert.That(skills.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetCrossClassSkills()
        {
            crossClassSkills.Add("skill 1");
            crossClassSkills.Add("skill 2");
            crossClassSkills.Add("skill 3");
            crossClassSkills.Add("skill 4");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            foreach (var skill in crossClassSkills)
                Assert.That(skills.Keys, Contains.Item(skill));
            Assert.That(skills.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetBothClassSkillsAndCrossClassSkills()
        {
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            crossClassSkills.Add("skill 3");
            crossClassSkills.Add("skill 4");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            foreach (var skill in crossClassSkills)
                Assert.That(skills.Keys, Contains.Item(skill));

            foreach (var skill in classSkills)
                Assert.That(skills.Keys, Contains.Item(skill));
            Assert.That(skills.Count, Is.EqualTo(4));
        }

        [Test]
        public void AssignStatsToSkills()
        {
            classSkills.Add("class skill");
            crossClassSkills.Add("cross class skill");

            var classSkillSelection = new SkillSelection();
            classSkillSelection.BaseStatName = "stat 1";

            var crossClassSkillSelection = new SkillSelection();
            crossClassSkillSelection.BaseStatName = "stat 2";

            mockSkillSelector.Setup(s => s.SelectFor("class skill")).Returns(classSkillSelection);
            mockSkillSelector.Setup(s => s.SelectFor("cross class skill")).Returns(crossClassSkillSelection);

            stats["stat 1"] = new Stat();
            stats["stat 2"] = new Stat();

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["class skill"].BaseStat, Is.EqualTo(stats["stat 1"]));
            Assert.That(skills["cross class skill"].BaseStat, Is.EqualTo(stats["stat 2"]));
        }

        [Test]
        public void SetArmorCheckPenalty()
        {
            classSkills.Add("penalty");
            crossClassSkills.Add("no penalty");

            var penaltySkillSelection = new SkillSelection { ArmorCheckPenalty = true, BaseStatName = StatConstants.Intelligence };
            var noPenaltySkillSelection = new SkillSelection { ArmorCheckPenalty = false, BaseStatName = StatConstants.Intelligence };

            mockSkillSelector.Setup(s => s.SelectFor("penalty")).Returns(penaltySkillSelection);
            mockSkillSelector.Setup(s => s.SelectFor("no penalty")).Returns(noPenaltySkillSelection);

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["penalty"].ArmorCheckPenalty, Is.True);
            Assert.That(skills["no penalty"].ArmorCheckPenalty, Is.False);
        }

        [Test]
        public void SetClassSkill()
        {
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            crossClassSkills.Add("skill 3");
            crossClassSkills.Add("skill 4");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].ClassSkill, Is.True);
            Assert.That(skills["skill 2"].ClassSkill, Is.True);
            Assert.That(skills["skill 3"].ClassSkill, Is.False);
            Assert.That(skills["skill 4"].ClassSkill, Is.False);
        }

        [Test]
        public void AssignSkillPointsRandomlyAmongClassSkills()
        {
            skillPoints[characterClass.ClassName] = 1;
            characterClass.Level = 2;

            mockDice.Setup(d => d.Roll(1).d3()).Returns(1);
            mockDice.SetupSequence(d => d.Roll(1).d(2)).Returns(2).Returns(1).Returns(1).Returns(2).Returns(2);

            classSkills.Add("skill 1");
            classSkills.Add("skill 2");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(2));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(3));
            Assert.That(skills["skill 1"].EffectiveRanks, Is.EqualTo(2));
            Assert.That(skills["skill 2"].EffectiveRanks, Is.EqualTo(3));
        }

        [Test]
        public void AssignSkillPointsRandomlyAmongCrossClassSkills()
        {
            skillPoints[characterClass.ClassName] = 1;
            characterClass.Level = 2;

            mockDice.Setup(d => d.Roll(1).d3()).Returns(3);
            mockDice.SetupSequence(d => d.Roll(1).d(2)).Returns(2).Returns(1).Returns(1).Returns(2).Returns(2);

            crossClassSkills.Add("skill 1");
            crossClassSkills.Add("skill 2");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(2));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(3));
            Assert.That(skills["skill 1"].EffectiveRanks, Is.EqualTo(1));
            Assert.That(skills["skill 2"].EffectiveRanks, Is.EqualTo(1.5));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void AssignPointsToClassSkills(Int32 roll)
        {
            skillPoints[characterClass.ClassName] = 1;
            mockDice.Setup(d => d.Roll(1).d3()).Returns(roll);
            classSkills.Add("class skill");
            crossClassSkills.Add("cross-class skill");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["class skill"].Ranks, Is.EqualTo(8));
            Assert.That(skills["cross-class skill"].Ranks, Is.EqualTo(0));
        }

        [Test]
        public void AssignPointsToCrossClassSkills()
        {
            skillPoints[characterClass.ClassName] = 1;
            mockDice.Setup(d => d.Roll(1).d3()).Returns(3);
            classSkills.Add("class skill");
            crossClassSkills.Add("cross-class skill");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["class skill"].Ranks, Is.EqualTo(0));
            Assert.That(skills["cross-class skill"].Ranks, Is.EqualTo(8));
        }

        [Test]
        public void AssignPointsRandomlyBetweenClassAndCrossClassSkills()
        {
            skillPoints[characterClass.ClassName] = 1;
            characterClass.Level = 2;
            mockDice.SetupSequence(d => d.Roll(1).d3()).Returns(3).Returns(1).Returns(2).Returns(3).Returns(2);

            classSkills.Add("class skill");
            crossClassSkills.Add("cross-class skill");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["class skill"].Ranks, Is.EqualTo(3));
            Assert.That(skills["cross-class skill"].Ranks, Is.EqualTo(2));
        }

        [Test]
        public void CannotAssignMoreThanLevelPlusThreePointsPerClassSkill()
        {
            skillPoints[characterClass.ClassName] = 2;
            mockDice.SetupSequence(d => d.Roll(1).d3()).Returns(1);

            var sequence = mockDice.SetupSequence(d => d.Roll(1).d(3));
            for (var count = 4; count > 0; count--)
                sequence = sequence.Returns(2).Returns(3).Returns(1).Returns(1);

            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("skill 3");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(8));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(4));
            Assert.That(skills["skill 3"].Ranks, Is.EqualTo(4));
        }

        [Test]
        public void CannotAssignMoreThanLevelPlusThreePointsPerCrossClassSkill()
        {
            skillPoints[characterClass.ClassName] = 2;
            mockDice.SetupSequence(d => d.Roll(1).d3()).Returns(3);

            var sequence = mockDice.SetupSequence(d => d.Roll(1).d(3));
            for (var count = 4; count > 0; count--)
                sequence = sequence.Returns(2).Returns(3).Returns(1).Returns(1);

            crossClassSkills.Add("skill 1");
            crossClassSkills.Add("skill 2");
            crossClassSkills.Add("skill 3");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(8));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(4));
            Assert.That(skills["skill 3"].Ranks, Is.EqualTo(4));
        }

        [Test]
        public void AllSkillsMaxedOut()
        {
            skillPoints[characterClass.ClassName] = 3;
            crossClassSkills.Add("skill 1");
            classSkills.Add("skill 2");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(characterClass.Level + 3));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(characterClass.Level + 3));
        }

        [Test]
        public void ApplySkillSynergyIfSufficientRanks()
        {
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 1")).Returns(new[] { "synergy 1", "synergy 2" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 2")).Returns(new[] { "synergy 3" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 3")).Returns(new[] { "synergy 4" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 4")).Returns(new[] { "synergy 5" });

            skillPoints[characterClass.ClassName] = 2;
            characterClass.Level = 13;

            var sequence = mockDice.SetupSequence(d => d.Roll(1).d3());
            for (var count = 0; count < 11; count++)
                sequence = sequence.Returns(1);
            for (var count = 0; count < 21; count++)
                sequence = sequence.Returns(3);

            sequence = mockDice.SetupSequence(d => d.Roll(1).d(8)).Returns(1);
            for (var roll = 0; roll < 10; roll++)
                sequence = sequence.Returns(roll % 2 + 1);

            sequence = mockDice.SetupSequence(d => d.Roll(1).d(2)).Returns(1);
            for (var roll = 0; roll < 20; roll++)
                sequence = sequence.Returns(roll % 2 + 1);

            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            crossClassSkills.Add("skill 3");
            crossClassSkills.Add("skill 4");
            classSkills.Add("synergy 1");
            classSkills.Add("synergy 2");
            classSkills.Add("synergy 3");
            classSkills.Add("synergy 4");
            classSkills.Add("synergy 5");
            classSkills.Add("synergy 6");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(6));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(5));
            Assert.That(skills["skill 3"].Ranks, Is.EqualTo(11));
            Assert.That(skills["skill 4"].Ranks, Is.EqualTo(10));
            Assert.That(skills["synergy 1"].Ranks, Is.EqualTo(0));
            Assert.That(skills["synergy 2"].Ranks, Is.EqualTo(0));
            Assert.That(skills["synergy 3"].Ranks, Is.EqualTo(0));
            Assert.That(skills["synergy 4"].Ranks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].EffectiveRanks, Is.EqualTo(6));
            Assert.That(skills["skill 2"].EffectiveRanks, Is.EqualTo(5));
            Assert.That(skills["skill 3"].EffectiveRanks, Is.EqualTo(5.5));
            Assert.That(skills["skill 4"].EffectiveRanks, Is.EqualTo(5));
            Assert.That(skills["synergy 1"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["synergy 2"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["synergy 3"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["synergy 4"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 2"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 3"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 4"].Bonus, Is.EqualTo(0));
            Assert.That(skills["synergy 1"].Bonus, Is.EqualTo(2));
            Assert.That(skills["synergy 2"].Bonus, Is.EqualTo(2));
            Assert.That(skills["synergy 3"].Bonus, Is.EqualTo(2));
            Assert.That(skills["synergy 4"].Bonus, Is.EqualTo(2));
            Assert.That(skills["synergy 5"].Bonus, Is.EqualTo(2));
            Assert.That(skills["synergy 6"].Bonus, Is.EqualTo(0));
        }

        [Test]
        public void SkillSynergyStacks()
        {
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 1")).Returns(new[] { "synergy 1", "synergy 2" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 2")).Returns(new[] { "synergy 1" });

            skillPoints[characterClass.ClassName] = 2;
            characterClass.Level = 2;

            mockDice.Setup(d => d.Roll(1).d3()).Returns(1);

            var sequence = mockDice.SetupSequence(d => d.Roll(1).d(4));
            for (var roll = 0; roll < 5; roll++)
                sequence = sequence.Returns(2).Returns(1);

            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("synergy 1");
            classSkills.Add("synergy 2");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(5));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(5));
            Assert.That(skills["synergy 1"].Ranks, Is.EqualTo(0));
            Assert.That(skills["synergy 2"].Ranks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].EffectiveRanks, Is.EqualTo(5));
            Assert.That(skills["skill 2"].EffectiveRanks, Is.EqualTo(5));
            Assert.That(skills["synergy 1"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["synergy 2"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 2"].Bonus, Is.EqualTo(0));
            Assert.That(skills["synergy 1"].Bonus, Is.EqualTo(4));
            Assert.That(skills["synergy 2"].Bonus, Is.EqualTo(2));
        }

        [Test]
        public void DoNotApplySkillSynergyIfThereIsNoSynergisticSkill()
        {
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 1")).Returns(Enumerable.Empty<String>());
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 2")).Returns(new[] { "synergy 1" });

            skillPoints[characterClass.ClassName] = 2;
            characterClass.Level = 2;

            mockDice.Setup(d => d.Roll(1).d3()).Returns(1);
            var sequence = mockDice.SetupSequence(d => d.Roll(1).d(3));
            for (var roll = 0; roll < 10; roll++)
                sequence = sequence.Returns(roll % 2 + 1);

            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("synergy 2");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(5));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(5));
            Assert.That(skills["synergy 2"].Ranks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].EffectiveRanks, Is.EqualTo(5));
            Assert.That(skills["skill 2"].EffectiveRanks, Is.EqualTo(5));
            Assert.That(skills["synergy 2"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 2"].Bonus, Is.EqualTo(0));
            Assert.That(skills["synergy 2"].Bonus, Is.EqualTo(0));
            Assert.That(skills.Keys, Is.Not.Contains("synergy 1"));
        }

        [Test]
        public void DoNotApplySkillSynergyIfInsufficientRanks()
        {
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 1")).Returns(new[] { "synergy 1" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 2")).Returns(new[] { "synergy 2" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SkillSynergy, "skill 3")).Returns(new[] { "synergy 3" });

            skillPoints[characterClass.ClassName] = 3;
            characterClass.Level = 6;

            var sequence = mockDice.SetupSequence(d => d.Roll(1).d3());
            for (var count = 0; count < 10; count++)
                sequence = sequence.Returns(1);
            for (var count = 0; count < 17; count++)
                sequence = sequence.Returns(3);

            sequence = mockDice.SetupSequence(d => d.Roll(1).d(4));
            for (var roll = 0; roll < 4; roll++)
                sequence = sequence.Returns(1);
            for (var roll = 0; roll < 6; roll++)
                sequence = sequence.Returns(2);

            sequence = mockDice.SetupSequence(d => d.Roll(1).d(2)).Returns(1);
            for (var roll = 0; roll < 16; roll++)
                sequence = sequence.Returns(roll % 2 + 1);

            classSkills.Add("skill 1");
            crossClassSkills.Add("skill 2");
            crossClassSkills.Add("skill 3");
            classSkills.Add("synergy 1");
            classSkills.Add("synergy 2");
            classSkills.Add("synergy 3");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);

            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(4));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(9));
            Assert.That(skills["skill 3"].Ranks, Is.EqualTo(8));
            Assert.That(skills["synergy 1"].Ranks, Is.EqualTo(6));
            Assert.That(skills["synergy 2"].Ranks, Is.EqualTo(0));
            Assert.That(skills["synergy 3"].Ranks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].EffectiveRanks, Is.EqualTo(4));
            Assert.That(skills["skill 2"].EffectiveRanks, Is.EqualTo(4.5));
            Assert.That(skills["skill 3"].EffectiveRanks, Is.EqualTo(4));
            Assert.That(skills["synergy 1"].EffectiveRanks, Is.EqualTo(6));
            Assert.That(skills["synergy 2"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["synergy 3"].EffectiveRanks, Is.EqualTo(0));
            Assert.That(skills["skill 1"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 2"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 3"].Bonus, Is.EqualTo(0));
            Assert.That(skills["synergy 1"].Bonus, Is.EqualTo(0));
            Assert.That(skills["synergy 2"].Bonus, Is.EqualTo(0));
            Assert.That(skills["synergy 3"].Bonus, Is.EqualTo(0));
        }

        [TestCase(1, 4)]
        [TestCase(2, 5)]
        [TestCase(3, 6)]
        [TestCase(4, 7)]
        [TestCase(5, 8)]
        [TestCase(6, 9)]
        [TestCase(7, 10)]
        [TestCase(8, 11)]
        [TestCase(9, 12)]
        [TestCase(10, 13)]
        [TestCase(11, 14)]
        [TestCase(12, 15)]
        [TestCase(13, 16)]
        [TestCase(14, 17)]
        [TestCase(15, 18)]
        [TestCase(16, 19)]
        [TestCase(17, 20)]
        [TestCase(18, 21)]
        [TestCase(19, 22)]
        [TestCase(20, 23)]
        public void HumansGetExtraSkillPointsPerLevel(Int32 level, Int32 points)
        {
            characterClass.Level = level;
            skillPoints[characterClass.ClassName] = 0;
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            race.BaseRace.Id = RaceConstants.BaseRaces.Human;

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(points));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(0));
        }

        [TestCase(1, 16)]
        [TestCase(2, 20)]
        [TestCase(3, 24)]
        [TestCase(4, 28)]
        [TestCase(5, 32)]
        [TestCase(6, 36)]
        [TestCase(7, 40)]
        [TestCase(8, 44)]
        [TestCase(9, 48)]
        [TestCase(10, 52)]
        [TestCase(11, 56)]
        [TestCase(12, 60)]
        [TestCase(13, 64)]
        [TestCase(14, 68)]
        [TestCase(15, 72)]
        [TestCase(16, 76)]
        [TestCase(17, 80)]
        [TestCase(18, 84)]
        [TestCase(19, 88)]
        [TestCase(20, 92)]
        public void AllPerLevelBonusesStack(Int32 level, Int32 points)
        {
            var cap = level + 3;
            characterClass.Level = level;
            skillPoints[characterClass.ClassName] = 2;
            intelligence.Value = 12;
            race.BaseRace.Id = RaceConstants.BaseRaces.Human;
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("skill 3");
            classSkills.Add("skill 4");
            classSkills.Add("skill 5");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            var sum = skills.Values.Sum(s => s.Ranks);

            Assert.That(sum, Is.EqualTo(points));
            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(cap));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(cap));
            Assert.That(skills["skill 3"].Ranks, Is.EqualTo(cap));
            Assert.That(skills["skill 4"].Ranks, Is.EqualTo(cap));
            Assert.That(skills["skill 5"].Ranks, Is.EqualTo(0));
        }

        [Test]
        public void GetRacialSkillAdjustments()
        {
            race.BaseRace.Id = "base race id";
            race.Metarace.Id = "metarace id";
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("skill 3");
            crossClassSkills.Add("skill 4");
            crossClassSkills.Add("skill 5");

            var baseBonuses = new Dictionary<String, Int32>();
            baseBonuses["skill 1"] = 2;
            baseBonuses["skill 3"] = 3;
            baseBonuses["skill 5"] = 1;
            baseBonuses["skill 6"] = 8;
            var tableName = String.Format(TableNameConstants.Formattable.Collection.BASERACESkillAdjustments, "baseracetoformat");
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(tableName)).Returns(baseBonuses);

            var metaBonuses = new Dictionary<String, Int32>();
            metaBonuses["skill 1"] = 2;
            metaBonuses["skill 2"] = 1;
            metaBonuses["skill 6"] = 1;
            tableName = String.Format(TableNameConstants.Formattable.Collection.BASERACESkillAdjustments, "metaracetoformat");
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(tableName)).Returns(metaBonuses);

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill 1"].Bonus, Is.EqualTo(4));
            Assert.That(skills["skill 2"].Bonus, Is.EqualTo(1));
            Assert.That(skills["skill 3"].Bonus, Is.EqualTo(3));
            Assert.That(skills["skill 4"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 5"].Bonus, Is.EqualTo(1));
            Assert.That(skills.Count, Is.EqualTo(5));
        }

        [Test]
        public void HandleNoRacialAdjustments()
        {
            race.BaseRace = "base race";
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");
            classSkills.Add("skill 3");
            crossClassSkills.Add("skill 4");
            crossClassSkills.Add("skill 5");

            var bonuses = new Dictionary<String, Int32>();
            var tableName = String.Format(TableNameConstants.Formattable.Collection.BASERACESkillAdjustments, "baserace");
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(tableName)).Returns(bonuses);

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill 1"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 2"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 3"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 4"].Bonus, Is.EqualTo(0));
            Assert.That(skills["skill 5"].Bonus, Is.EqualTo(0));
        }

        [Test]
        public void RacialSkillAdjustmentsAreNotPerLevel()
        {
            characterClass.Level = 9266;
            race.BaseRace = "base race";
            classSkills.Add("skill");

            var bonuses = new Dictionary<String, Int32>();
            bonuses["skill"] = 2;
            var tableName = String.Format(TableNameConstants.Formattable.Collection.BASERACESkillAdjustments, "baserace");
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(tableName)).Returns(bonuses);

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill"].Bonus, Is.EqualTo(2));
        }

        [Test]
        public void MindFlayerKnowledgeBonusIsRandom()
        {
            race.BaseRace = RaceConstants.BaseRaces.MindFlayer;
            classSkills.Add(SkillConstants.KnowledgeArcana);
            classSkills.Add(SkillConstants.KnowledgeDungeoneering);
            classSkills.Add(SkillConstants.KnowledgeGeography);
            classSkills.Add(SkillConstants.KnowledgeNature);
            classSkills.Add("other skill");
            crossClassSkills.Add("other other skill");

            mockDice.Setup(d => d.Roll(1).d(4)).Returns(3);

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills[SkillConstants.KnowledgeArcana].Bonus, Is.EqualTo(0));
            Assert.That(skills[SkillConstants.KnowledgeDungeoneering].Bonus, Is.EqualTo(0));
            Assert.That(skills[SkillConstants.KnowledgeGeography].Bonus, Is.EqualTo(8));
            Assert.That(skills[SkillConstants.KnowledgeNature].Bonus, Is.EqualTo(0));
            Assert.That(skills["other skill"].Bonus, Is.EqualTo(0));
            Assert.That(skills["other other skill"].Bonus, Is.EqualTo(0));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        public void MonstersDoNotGetMoreSkillPointsAtFirstLevel(Int32 level)
        {
            race.BaseRace = "base race";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.BaseRaceGroups, TableNameConstants.Set.Collection.Groups.Monsters))
                .Returns(new[] { "base race", "other base race" });

            characterClass.Level = level;
            skillPoints[characterClass.ClassName] = 1;
            classSkills.Add("skill 1");
            classSkills.Add("skill 2");

            var skills = skillsGenerator.GenerateWith(characterClass, race, stats);
            Assert.That(skills["skill 1"].Ranks, Is.EqualTo(level));
            Assert.That(skills["skill 2"].Ranks, Is.EqualTo(0));
        }
    }
}