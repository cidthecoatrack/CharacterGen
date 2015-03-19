﻿using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using NPCGen.Common.Alignments;
using NPCGen.Common.CharacterClasses;
using NPCGen.Generators.Interfaces;
using NPCGen.Generators.Interfaces.Randomizers.CharacterClasses;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Generators
{
    public class CharacterClassGenerator : ICharacterClassGenerator
    {
        private IAdjustmentsSelector adjustmentsSelector;
        private ICollectionsSelector collectionsSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private IDice dice;

        public CharacterClassGenerator(IAdjustmentsSelector adjustmentsSelector, ICollectionsSelector collectionsSelector, IBooleanPercentileSelector booleanPercentileSelector,
            IDice dice)
        {
            this.adjustmentsSelector = adjustmentsSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.dice = dice;
        }

        public CharacterClass GenerateWith(Alignment alignment, ILevelRandomizer levelRandomizer,
            IClassNameRandomizer classNameRandomizer)
        {
            var characterClass = new CharacterClass();

            characterClass.Level = levelRandomizer.Randomize();
            characterClass.ClassName = classNameRandomizer.Randomize(alignment);

            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, characterClass.ClassName);
            var isSpecialist = booleanPercentileSelector.SelectFrom(tableName);

            if (!isSpecialist)
                return characterClass;

            characterClass.SpecialistFields = GenerateSpecialistFields(characterClass, alignment);
            characterClass.ProhibitedFields = GenerateProhibitedFields(characterClass);

            return characterClass;
        }

        private IEnumerable<String> GenerateSpecialistFields(CharacterClass characterClass, Alignment alignment)
        {
            var allSpecialistFields = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.SpecialistFields, characterClass.ClassName);
            var specialistFieldQuantities = adjustmentsSelector.SelectFrom(TableNameConstants.Set.Adjustments.SpecialistFieldQuantities);
            var nonAlignmentFields = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ProhibitedFields, alignment.ToString());
            var possibleSpecialistFields = allSpecialistFields.Except(nonAlignmentFields);

            return PopulateFields(specialistFieldQuantities[characterClass.ClassName], possibleSpecialistFields);
        }

        private IEnumerable<String> PopulateFields(Int32 quantity, IEnumerable<String> possibleFields)
        {
            var fields = new HashSet<String>();

            if (!possibleFields.Any())
                return fields;

            while (fields.Count < quantity)
            {
                var index = dice.Roll(1).d(possibleFields.Count()) - 1;
                var field = possibleFields.ElementAt(index);
                fields.Add(field);
            }

            return fields;
        }

        private IEnumerable<String> GenerateProhibitedFields(CharacterClass characterClass)
        {
            if (!characterClass.SpecialistFields.Any())
                return Enumerable.Empty<String>();

            var allProhibitedFields = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ProhibitedFields, characterClass.ClassName);
            var possibleProhibitedFields = allProhibitedFields.Except(characterClass.SpecialistFields);
            var prohibitedFieldQuantities = adjustmentsSelector.SelectFrom(TableNameConstants.Set.Adjustments.ProhibitedFieldQuantities);

            var prohibitedfieldQuantity = 0;
            foreach (var specialistField in characterClass.SpecialistFields)
                prohibitedfieldQuantity += prohibitedFieldQuantities[specialistField];

            return PopulateFields(prohibitedfieldQuantity, possibleProhibitedFields);
        }
    }
}