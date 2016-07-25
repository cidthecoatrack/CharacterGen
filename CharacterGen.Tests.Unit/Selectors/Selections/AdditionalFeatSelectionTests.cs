﻿using CharacterGen.Abilities.Feats;
using CharacterGen.Abilities.Skills;
using CharacterGen.Abilities.Stats;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Selectors.Selections;
using CharacterGen.Domain.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;

namespace CharacterGen.Tests.Unit.Selectors.Selections
{
    [TestFixture]
    public class AdditionalFeatSelectionTests
    {
        private AdditionalFeatSelection selection;
        private List<Feat> feats;
        private Dictionary<string, Stat> stats;
        private Dictionary<string, Skill> skills;
        private CharacterClass characterClass;

        [SetUp]
        public void Setup()
        {
            selection = new AdditionalFeatSelection();
            feats = new List<Feat>();
            stats = new Dictionary<string, Stat>();
            stats["stat"] = new Stat("stat");
            skills = new Dictionary<string, Skill>();
            characterClass = new CharacterClass();
        }

        [Test]
        public void FeatSelectionInitialized()
        {
            Assert.That(selection.Feat, Is.Empty);
            Assert.That(selection.RequiredBaseAttack, Is.EqualTo(0));
            Assert.That(selection.RequiredFeats, Is.Empty);
            Assert.That(selection.RequiredSkillRanks, Is.Empty);
            Assert.That(selection.RequiredStats, Is.Empty);
            Assert.That(selection.RequiredCharacterClasses, Is.Empty);
            Assert.That(selection.FocusType, Is.Empty);
            Assert.That(selection.Power, Is.EqualTo(0));
            Assert.That(selection.Frequency, Is.Not.Null);
        }

        [Test]
        public void ImmutableRequirementsMetIfNoRequirements()
        {
            var met = selection.ImmutableRequirementsMet(0, stats, skills, characterClass);
            Assert.That(met, Is.True);
        }

        [Test]
        public void MutableRequirementsMetIfNoRequirements()
        {
            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.True);
        }

        [Test]
        public void BaseAttackRequirementNotMet()
        {
            selection.RequiredBaseAttack = 2;
            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.False);
        }

        [Test]
        public void StatRequirementsNotMet()
        {
            selection.RequiredStats["stat"] = 16;
            stats["stat"].Value = 15;
            stats["other stat"] = new Stat("other stat");
            stats["other stat"].Value = 157;

            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.False);
        }

        [Test]
        public void SkillRequirementsWithCrossClassSkillNotMet()
        {
            selection.RequiredSkillRanks["skill"] = 5;
            skills["skill"] = new Skill("skill", stats["stat"], 10);
            skills["skill"].Ranks = 9;
            skills["skill"].ClassSkill = false;
            skills["other skill"] = new Skill("other skill", stats["stat"], 10);
            skills["other skill"].Ranks = 10;
            skills["other skill"].ClassSkill = false;

            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.False);
        }

        [Test]
        public void SkillRequirementsWithClassSkillNotMet()
        {
            selection.RequiredSkillRanks["skill"] = 5;
            skills["skill"] = new Skill("skill", stats["stat"], 10);
            skills["skill"].Ranks = 4;
            skills["skill"].ClassSkill = true;
            skills["other skill"] = new Skill("other skill", stats["stat"], 10);
            skills["other skill"].Ranks = 5;
            skills["other skill"].ClassSkill = true;

            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.False);
        }

        [Test]
        public void AnyRequiredSkillWithSufficientRanksMeetRequirement()
        {
            selection.RequiredSkillRanks["skill"] = 5;
            selection.RequiredSkillRanks["other skill"] = 1;
            skills["skill"] = new Skill("skill", stats["stat"], 10);
            skills["skill"].Ranks = 4;
            skills["skill"].ClassSkill = true;
            skills["other skill"] = new Skill("other skill", stats["stat"], 10);
            skills["other skill"].Ranks = 1;
            skills["other skill"].ClassSkill = true;

            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.True);
        }

        [Test]
        public void MeetSkillRequirementOf0Ranks()
        {
            selection.RequiredSkillRanks["skill"] = 0;
            skills["skill"] = new Skill("skill", stats["stat"], 10);
            skills["skill"].ClassSkill = false;

            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.True);
        }

        [Test]
        public void ClassNameRequirementsNotMet()
        {
            selection.RequiredCharacterClasses["class name"] = 1;
            selection.RequiredCharacterClasses["other class name"] = 2;
            characterClass.Name = "different class name";
            characterClass.Level = 3;

            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.False);
        }

        [Test]
        public void ClassLevelRequirementsNotMet()
        {
            selection.RequiredCharacterClasses["class name"] = 1;
            selection.RequiredCharacterClasses["other class name"] = 2;
            characterClass.Name = "other class name";
            characterClass.Level = 1;

            var met = selection.ImmutableRequirementsMet(1, stats, skills, characterClass);
            Assert.That(met, Is.False);
        }

        [Test]
        public void AllImmutableRequirementsMet()
        {
            selection.RequiredBaseAttack = 2;

            selection.RequiredStats["stat"] = 16;
            stats["stat"] = new Stat("stat");
            stats["stat"].Value = 16;
            stats["other stat"] = new Stat("other stat");
            stats["other stat"].Value = 15;

            selection.RequiredSkillRanks["class skill"] = 5;
            selection.RequiredSkillRanks["cross-class skill"] = 5;
            skills["class skill"] = new Skill("class skill", stats["stat"], 10);
            skills["class skill"].Ranks = 10;
            skills["class skill"].ClassSkill = false;
            skills["other class skill"] = new Skill("other class skill", stats["stat"], 10);
            skills["other class skill"].Ranks = 9;
            skills["other class skill"].ClassSkill = false;
            skills["cross-class skill"] = new Skill("cross-class skill", stats["stat"], 10);
            skills["cross-class skill"].Ranks = 5;
            skills["cross-class skill"].ClassSkill = true;
            skills["other cross-class skill"] = new Skill("other cross-class skill", stats["stat"], 10);
            skills["other cross-class skill"].Ranks = 4;
            skills["other cross-class skill"].ClassSkill = true;

            selection.RequiredCharacterClasses["class name"] = 1;
            characterClass.Name = "class name";
            characterClass.Level = 1;

            var met = selection.ImmutableRequirementsMet(2, stats, skills, characterClass);
            Assert.That(met, Is.True);
        }

        [Test]
        public void FeatRequirementsNotMet()
        {
            feats.Add(new Feat());
            feats[0].Name = "feat";
            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = "feat" },
                new RequiredFeatSelection { Feat = "other required feat" }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.False);
        }

        [Test]
        public void AllMutableRequirementsMet()
        {
            feats.Add(new Feat());
            feats.Add(new Feat());
            feats[0].Name = "feat";
            feats[1].Name = "other required feat";
            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = "feat" },
                new RequiredFeatSelection { Feat = "other required feat" }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.True);
        }

        [Test]
        public void ExtraFeatDoNotMatter()
        {
            feats.Add(new Feat());
            feats.Add(new Feat());
            feats.Add(new Feat());
            feats[0].Name = "feat";
            feats[1].Name = "other required feat";
            feats[2].Name = "yet another feat";

            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = "feat" },
                new RequiredFeatSelection { Feat = "other required feat" }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.True);
        }

        [Test]
        public void WeaponProficiencyRequirementDoesNotAffectMutableRequirements()
        {
            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = ItemTypeConstants.Weapon + GroupConstants.Proficiency }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.True);
        }

        [Test]
        public void WithWeaponProficiencyRequirement_OtherRequirementsNotIgnored()
        {
            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = ItemTypeConstants.Weapon + GroupConstants.Proficiency },
                new RequiredFeatSelection { Feat = "feat" }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.False);
        }

        [Test]
        public void WithWeaponProficiencyRequirement_OtherRequirementsAreHonored()
        {
            feats.Add(new Feat());
            feats[0].Name = "feat";
            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = ItemTypeConstants.Weapon + GroupConstants.Proficiency },
                new RequiredFeatSelection { Feat = "feat" }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.True);
        }

        [Test]
        public void ShieldProficiencyIsNotIngoredForMutableRequirements()
        {
            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = FeatConstants.ShieldProficiency }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.False);
        }

        [Test]
        public void ShieldProficiencyIsHonoredForMutableRequirements()
        {
            feats.Add(new Feat());
            feats[0].Name = FeatConstants.ShieldProficiency;
            selection.RequiredFeats = new[]
            {
                new RequiredFeatSelection { Feat = FeatConstants.ShieldProficiency }
            };

            var met = selection.MutableRequirementsMet(feats);
            Assert.That(met, Is.True);
        }
    }
}