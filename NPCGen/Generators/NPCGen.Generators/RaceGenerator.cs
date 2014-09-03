﻿using System;
using System.Linq;
using D20Dice;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Races;
using NPCGen.Generators.Interfaces;
using NPCGen.Generators.Interfaces.Randomizers.Races;
using NPCGen.Selectors.Interfaces;

namespace NPCGen.Generators
{
    public class RaceGenerator : IRaceGenerator
    {
        private IDice dice;
        private ICollectionsSelector collectionsSelector;

        public RaceGenerator(IDice dice, ICollectionsSelector collectionsSelector)
        {
            this.dice = dice;
            this.collectionsSelector = collectionsSelector;
        }

        public Race GenerateWith(String goodnessString, CharacterClass characterClass, IBaseRaceRandomizer baseRaceRandomizer, IMetaraceRandomizer metaraceRandomizer)
        {
            var race = new Race();

            race.BaseRace = baseRaceRandomizer.Randomize(goodnessString, characterClass);
            race.Metarace = metaraceRandomizer.Randomize(goodnessString, characterClass);
            race.Male = DetermineIfMale(race.BaseRace, characterClass.ClassName);
            race.Size = DetermineSize(race.BaseRace);
            race.HasWings = DetermineIfRaceHasWings(race);

            return race;
        }

        private Boolean DetermineIfMale(String baseRace, String className)
        {
            if (baseRace == RaceConstants.BaseRaces.Drow && className == CharacterClassConstants.Wizard)
                return true;

            if (baseRace == RaceConstants.BaseRaces.Drow && className == CharacterClassConstants.Cleric)
                return false;

            return dice.Roll().d2() == 1;
        }

        private String DetermineSize(String baseRace)
        {
            var largeRaces = collectionsSelector.SelectFrom("BaseRaceGroups", RaceConstants.Sizes.Large);
            if (largeRaces.Contains(baseRace))
                return RaceConstants.Sizes.Large;

            var smallRaces = collectionsSelector.SelectFrom("BaseRaceGroups", RaceConstants.Sizes.Small);
            if (smallRaces.Contains(baseRace))
                return RaceConstants.Sizes.Small;

            return RaceConstants.Sizes.Medium;
        }

        private Boolean DetermineIfRaceHasWings(Race race)
        {
            if (race.Metarace == RaceConstants.Metaraces.HalfCelestial || race.Metarace == RaceConstants.Metaraces.HalfFiend)
                return true;
            else if (race.Metarace == RaceConstants.Metaraces.HalfDragon)
                return race.Size == RaceConstants.Sizes.Large;

            return false;
        }
    }
}