﻿using System;
using System.Collections.Generic;
using System.Linq;
using NPCGen.Common.Alignments;
using NPCGen.Common.CharacterClasses;
using NPCGen.Generators.Interfaces.Randomizers.Alignments;
using NPCGen.Generators.Interfaces.Randomizers.CharacterClasses;
using NPCGen.Generators.Interfaces.Randomizers.Races;
using NPCGen.Generators.Interfaces.Verifiers;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Generators.Verifiers
{
    public class RandomizerVerifier : IRandomizerVerifier
    {
        private IAdjustmentsSelector adjustmentsSelector;

        public RandomizerVerifier(IAdjustmentsSelector adjustmentsSelector)
        {
            this.adjustmentsSelector = adjustmentsSelector;
        }

        public Boolean VerifyCompatibility(IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer, ILevelRandomizer levelRandomizer,
            IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer)
        {
            var alignments = alignmentRandomizer.GetAllPossibleResults();
            return alignments.Any() && alignments.Any(a => VerifyAlignmentCompatibility(a, classNameRandomizer, levelRandomizer,
                baseRaceRandomizer, metaraceRandomizer));
        }

        public Boolean VerifyAlignmentCompatibility(Alignment alignment, IClassNameRandomizer classNameRandomizer, ILevelRandomizer levelRandomizer,
            IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer)
        {
            var classNames = classNameRandomizer.GetAllPossibleResults(alignment);
            var levels = levelRandomizer.GetAllPossibleResults();

            var characterClasses = GetAllCharacterClassPrototypes(classNames, levels);
            return characterClasses.Any() && characterClasses.Any(c => VerifyCharacterClassCompatibility(alignment.Goodness, c,
                baseRaceRandomizer, metaraceRandomizer));
        }

        private IEnumerable<CharacterClass> GetAllCharacterClassPrototypes(IEnumerable<String> classNames, IEnumerable<Int32> levels)
        {
            var characterClasses = new List<CharacterClass>();

            foreach (var className in classNames)
                foreach (var level in levels)
                    characterClasses.Add(new CharacterClass { ClassName = className, Level = level });

            return characterClasses;
        }

        public Boolean VerifyCharacterClassCompatibility(String goodness, CharacterClass characterClass, IBaseRaceRandomizer baseRaceRandomizer,
            IMetaraceRandomizer metaraceRandomizer)
        {
            var baseRaceIds = baseRaceRandomizer.GetAllPossibleIds(goodness, characterClass);
            var metaraceIds = metaraceRandomizer.GetAllPossibleIds(goodness, characterClass);

            return baseRaceIds.Any() && metaraceIds.Any() && LevelAdjustmentsAreAllowed(baseRaceIds, metaraceIds, characterClass.Level);
        }

        private Boolean LevelAdjustmentsAreAllowed(IEnumerable<String> baseRaceIds, IEnumerable<String> metaraceIds, Int32 level)
        {
            var levelAdjustments = adjustmentsSelector.SelectFrom(TableNameConstants.Set.Adjustments.LevelAdjustments);
            var minBaseRaceLevelAdjustment = levelAdjustments.Where(kvp => baseRaceIds.Contains(kvp.Key)).Min(kvp => kvp.Value);
            var minMetaraceLevelAdjustment = levelAdjustments.Where(kvp => metaraceIds.Contains(kvp.Key)).Min(kvp => kvp.Value);

            return minBaseRaceLevelAdjustment + minMetaraceLevelAdjustment < level;
        }
    }
}