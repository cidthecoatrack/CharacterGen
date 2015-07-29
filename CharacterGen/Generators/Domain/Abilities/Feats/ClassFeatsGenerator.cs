﻿using CharacterGen.Common.Abilities.Feats;
using CharacterGen.Common.Abilities.Skills;
using CharacterGen.Common.Abilities.Stats;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Common.Races;
using CharacterGen.Generators.Abilities.Feats;
using CharacterGen.Selectors;
using CharacterGen.Selectors.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterGen.Generators.Domain.Abilities.Feats
{
    public class ClassFeatsGenerator : IClassFeatsGenerator
    {
        private IFeatsSelector featsSelector;
        private IFeatFocusGenerator featFocusGenerator;
        private ICollectionsSelector collectionsSelector;

        public ClassFeatsGenerator(IFeatsSelector featsSelector, IFeatFocusGenerator featFocusGenerator, ICollectionsSelector collectionsSelector)
        {
            this.featsSelector = featsSelector;
            this.featFocusGenerator = featFocusGenerator;
            this.collectionsSelector = collectionsSelector;
        }

        public IEnumerable<Feat> GenerateWith(CharacterClass characterClass, Race race, Dictionary<String, Stat> stats, IEnumerable<Feat> racialFeats, Dictionary<String, Skill> skills)
        {
            var characterClassFeatSelections = featsSelector.SelectClass(characterClass.ClassName).ToList();

            foreach (var specialistField in characterClass.SpecialistFields)
            {
                var specialistFeatSelections = featsSelector.SelectClass(specialistField);
                characterClassFeatSelections.AddRange(specialistFeatSelections);
            }

            var relevantClassFeatSelections = characterClassFeatSelections.Where(f => f.RequirementsMet(characterClass, race));
            var classFeats = GetClassFeats(relevantClassFeatSelections, racialFeats, stats, characterClass, skills);

            if (characterClass.ClassName == CharacterClassConstants.Ranger)
                return ImproveFavoredEnemyStrength(classFeats);

            return classFeats;
        }

        private IEnumerable<Feat> GetClassFeats(IEnumerable<CharacterClassFeatSelection> classFeatSelections, IEnumerable<Feat> earnedFeat, Dictionary<String, Stat> stats, CharacterClass characterClass, Dictionary<String, Skill> skills)
        {
            var classFeats = new List<Feat>();

            foreach (var classFeatSelection in classFeatSelections)
            {
                var classFeat = new Feat();
                classFeat.Name = classFeatSelection.Feat;
                classFeat.Focus = featFocusGenerator.GenerateAllowingFocusOfAllFrom(classFeatSelection.Feat, classFeatSelection.FocusType, skills, classFeatSelection.RequiredFeats, earnedFeat, characterClass);
                classFeat.Frequency = classFeatSelection.Frequency;

                if (classFeatSelection.FrequencyQuantityStat != String.Empty)
                    classFeat.Frequency.Quantity += stats[classFeatSelection.FrequencyQuantityStat].Bonus;

                classFeat.Strength = classFeatSelection.Strength;

                classFeats.Add(classFeat);
                earnedFeat = earnedFeat.Union(classFeats);
            }

            return classFeats;
        }

        private IEnumerable<Feat> ImproveFavoredEnemyStrength(IEnumerable<Feat> classFeats)
        {
            var favoredEnemyFeats = classFeats.Where(f => f.Name == FeatConstants.FavoredEnemy);
            var favoredEnemyQuantity = favoredEnemyFeats.Count();
            var timesToImprove = favoredEnemyQuantity - 1;

            while (timesToImprove-- > 0)
            {
                var feat = collectionsSelector.SelectRandomFrom<Feat>(favoredEnemyFeats);
                feat.Strength += 2;
            }

            return classFeats;
        }
    }
}