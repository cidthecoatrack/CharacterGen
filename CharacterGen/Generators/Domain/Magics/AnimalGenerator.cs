﻿using CharacterGen.Common.Abilities.Feats;
using CharacterGen.Common.Alignments;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Common.Items;
using CharacterGen.Common.Magics;
using CharacterGen.Common.Races;
using CharacterGen.Generators.Abilities;
using CharacterGen.Generators.Combats;
using CharacterGen.Generators.Magics;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using CharacterGen.Selectors;
using CharacterGen.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterGen.Generators.Domain.Magics
{
    public class AnimalGenerator : Generator, IAnimalGenerator
    {
        private ICollectionsSelector collectionsSelector;
        private IRaceGenerator raceGenerator;
        private IBaseRaceRandomizer animalBaseRaceRandomizer;
        private IMetaraceRandomizer noMetaraceRandomizer;
        private IAdjustmentsSelector adjustmentsSelector;
        private IAbilitiesGenerator animalAbilitiesGenerator;
        private ISetStatsRandomizer setStatsRandomizer;
        private ICombatGenerator animalCombatGenerator;

        public AnimalGenerator(ICollectionsSelector collectionsSelector, IRaceGenerator raceGenerator, IBaseRaceRandomizer animalBaseRaceRandomizer, IMetaraceRandomizer noMetaraceRandomizer,
            IAdjustmentsSelector adjustmentsSelector, IAbilitiesGenerator animalAbilitiesGenerator, ISetStatsRandomizer setStatsRandomizer, ICombatGenerator animalCombatGenerator)
        {
            this.collectionsSelector = collectionsSelector;
            this.raceGenerator = raceGenerator;
            this.animalBaseRaceRandomizer = animalBaseRaceRandomizer;
            this.noMetaraceRandomizer = noMetaraceRandomizer;
            this.adjustmentsSelector = adjustmentsSelector;
            this.animalAbilitiesGenerator = animalAbilitiesGenerator;
            this.setStatsRandomizer = setStatsRandomizer;
            this.animalCombatGenerator = animalCombatGenerator;
        }

        public Animal GenerateFrom(Alignment alignment, CharacterClass characterClass, Race race, IEnumerable<Feat> feats)
        {
            var levelAdjustments = adjustmentsSelector.SelectFrom(TableNameConstants.Set.Adjustments.LevelAdjustments);
            var effectiveCharacterClass = GetEffectiveCharacterClass(characterClass);

            if (CharacterCanHaveAnimal(effectiveCharacterClass, race, levelAdjustments) == false)
                return null;

            var animal = new Animal();
            var improvedFamiliars = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.Animals, FeatConstants.ImprovedFamiliar);
            var characterHasImprovedFamiliarFeat = feats.Any(f => f.Name == FeatConstants.ImprovedFamiliar);

            animal.Race = Generate<Race>(() => raceGenerator.GenerateWith(alignment, effectiveCharacterClass, animalBaseRaceRandomizer, noMetaraceRandomizer),
                a => effectiveCharacterClass.Level + levelAdjustments[a.BaseRace] > 0 && (characterHasImprovedFamiliarFeat || improvedFamiliars.Contains(a.BaseRace) == false));

            var baseAttack = animalCombatGenerator.GenerateBaseAttackWith(effectiveCharacterClass, animal.Race);
            animal.Ability = animalAbilitiesGenerator.GenerateWith(effectiveCharacterClass, animal.Race, setStatsRandomizer, baseAttack);

            var emptyEquipment = new Equipment();
            animal.Combat = animalCombatGenerator.GenerateWith(baseAttack, effectiveCharacterClass, animal.Race, animal.Ability.Feats, animal.Ability.Stats, emptyEquipment);

            var tableName = String.Format(TableNameConstants.Formattable.Adjustments.LevelXAnimalTricks, effectiveCharacterClass.Level);
            var tricks = adjustmentsSelector.SelectFrom(tableName);
            animal.Tricks = tricks[effectiveCharacterClass.ClassName];

            return animal;
        }

        private CharacterClass GetEffectiveCharacterClass(CharacterClass characterClass)
        {
            if (characterClass.ClassName != CharacterClassConstants.Ranger)
                return characterClass;

            var effectiveCharacterClass = new CharacterClass();
            effectiveCharacterClass.ClassName = CharacterClassConstants.Druid;
            effectiveCharacterClass.Level = characterClass.Level / 2;

            return effectiveCharacterClass;
        }

        private Boolean CharacterCanHaveAnimal(CharacterClass characterClass, Race race, Dictionary<String, Int32> levelAdjustments)
        {
            var animals = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.Animals, characterClass.ClassName);
            var animalsForSize = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.Animals, race.Size);
            var animalsWithinLevel = animals.Where(a => characterClass.Level + levelAdjustments[a] > 0);

            animals = animals.Intersect(animalsForSize).Intersect(animalsWithinLevel);

            return animals.Any();
        }
    }
}
