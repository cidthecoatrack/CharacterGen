﻿using System;
using System.Collections.Generic;
using System.Linq;
using NPCGen.Common.Abilities.Feats;
using NPCGen.Common.Abilities.Skills;
using NPCGen.Common.Abilities.Stats;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Combats;
using NPCGen.Common.Races;
using NPCGen.Generators.Interfaces.Abilities.Feats;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Generators.Abilities.Feats
{
    public class FeatsGenerator : IFeatsGenerator
    {
        private IRacialFeatsGenerator racialFeatsGenerator;
        private IClassFeatsGenerator classFeatsGenerator;
        private IAdditionalFeatsGenerator additionalFeatsGenerator;
        private ICollectionsSelector collectionsSelector;
        private INameSelector nameSelector;

        public FeatsGenerator(IRacialFeatsGenerator racialFeatsGenerator, IClassFeatsGenerator classFeatsGenerator,
            IAdditionalFeatsGenerator additionalFeatsGenerator, ICollectionsSelector collectionsSelector,
            INameSelector nameSelector)
        {
            this.racialFeatsGenerator = racialFeatsGenerator;
            this.classFeatsGenerator = classFeatsGenerator;
            this.additionalFeatsGenerator = additionalFeatsGenerator;
            this.collectionsSelector = collectionsSelector;
            this.nameSelector = nameSelector;
        }

        public IEnumerable<Feat> GenerateWith(CharacterClass characterClass, Race race, Dictionary<String, Stat> stats,
            Dictionary<String, Skill> skills, BaseAttack baseAttack)
        {
            var racialFeats = racialFeatsGenerator.GenerateWith(race);
            var classFeats = classFeatsGenerator.GenerateWith(characterClass, stats);
            var automaticFeats = racialFeats.Union(classFeats);
            var additionalFeats = additionalFeatsGenerator.GenerateWith(characterClass, race, stats, skills, baseAttack, automaticFeats);
            var skillSynergyFeats = GetSkillSynergyFeats(skills);

            var allFeats = racialFeats.Union(classFeats)
                                      .Union(additionalFeats)
                                      .Union(skillSynergyFeats);

            var featsToCombine = allFeats.Where(f => CanCombine(f, allFeats));

            foreach (var featToCombine in featsToCombine)
            {
                var otherFeats = featsToCombine.Where(f => CanCombine(f, featsToCombine) && f != featsToCombine);

                foreach (var otherFeat in otherFeats)
                    featToCombine.Frequency.Quantity += otherFeat.Frequency.Quantity;

                allFeats = allFeats.Except(otherFeats);
            }

            foreach (var feat in allFeats)
                feat.Name.Name = nameSelector.Select(feat.Name.Id);

            return allFeats;
        }

        private Boolean CanCombine(Feat feat, IEnumerable<Feat> allFeats)
        {
            var count = allFeats.Count(f => f.Name.Id == feat.Name.Id
                                        && f.Focus == feat.Focus
                                        && f.Strength == feat.Strength
                                        && f.Frequency.TimePeriod == feat.Frequency.TimePeriod);

            return count > 1;
        }

        private IEnumerable<Feat> GetSkillSynergyFeats(Dictionary<String, Skill> skills)
        {
            var synergyFeatIds = new List<String>();
            var synergyQualifyingSkills = skills.Where(kvp => kvp.Value.EffectiveRanks >= 5).Select(kvp => kvp.Key);

            foreach (var skill in synergyQualifyingSkills)
            {
                var synergy = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.SkillSynergyFeats, skill);
                synergyFeatIds.AddRange(synergy);
            }

            var synergyFeats = new List<Feat>();
            foreach (var synergyFeatId in synergyFeatIds)
            {
                var synergyFeat = new Feat();
                synergyFeat.Name.Id = synergyFeatId;

                synergyFeats.Add(synergyFeat);
            }

            return synergyFeats;
        }
    }
}