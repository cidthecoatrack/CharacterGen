﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NPCGen.Common.Races
{
    public class RaceConstants
    {
        public static class BaseRaces
        {
            public const String Aasimar = "Aasimar";
            public const String Bugbear = "Bugbear";
            public const String DeepDwarf = "Deep Dwarf";
            public const String DeepHalfling = "Deep Halfling";
            public const String Derro = "Derro";
            public const String Doppelganger = "Doppelganger";
            public const String Drow = "Drow";
            public const String DuergarDwarf = "Duergar Dwarf";
            public const String ForestGnome = "Forest Gnome";
            public const String Goblin = "Goblin";
            public const String Gnoll = "Gnoll";
            public const String GrayElf = "Gray Elf";
            public const String HalfElf = "Half-Elf";
            public const String HalfOrc = "Half-Orc";
            public const String HighElf = "High Elf";
            public const String HillDwarf = "Hill Dwarf";
            public const String Hobgoblin = "Hobgoblin";
            public const String Human = "Human";
            public const String Kobold = "Kobold";
            public const String LightfootHalfling = "Lightfoot Halfling";
            public const String Lizardfolk = "Lizardfolk";
            public const String MindFlayer = "Mind Flayer";
            public const String Minotaur = "Minotaur";
            public const String MountainDwarf = "Mountain Dwarf";
            public const String Ogre = "Ogre";
            public const String OgreMage = "Ogre Mage";
            public const String Orc = "Orc";
            public const String RockGnome = "Rock Gnome";
            public const String Svirfneblin = "Svirfneblin";
            public const String TallfellowHalfling = "Tallfellow Halfling";
            public const String Tiefling = "Tiefling";
            public const String Troglodyte = "Troglodyte";
            public const String WildElf = "Wild Elf";
            public const String WoodElf = "Wood Elf";

            public static IEnumerable<String> GetBaseRaces()
            {
                return new[]
                {
                    Aasimar,
                    Bugbear,
                    DeepDwarf,
                    DeepHalfling,
                    Derro,
                    Doppelganger,
                    Drow,
                    DuergarDwarf,
                    ForestGnome,
                    Gnoll,
                    Goblin,
                    GrayElf,
                    HalfElf,
                    HalfOrc,
                    HighElf,
                    HillDwarf,
                    Hobgoblin,
                    Human,
                    Kobold,
                    LightfootHalfling,
                    Lizardfolk,
                    MindFlayer,
                    Minotaur,
                    MountainDwarf,
                    Ogre,
                    OgreMage,
                    Orc,
                    RockGnome,
                    Svirfneblin,
                    TallfellowHalfling,
                    Tiefling,
                    Troglodyte,
                    WildElf,
                    WoodElf
                };
            }
        }

        public class Metaraces
        {
            public const String HalfCelestial = "Half-Celestial";
            public const String HalfDragon = "Half-Dragon";
            public const String HalfFiend = "Half-Fiend";
            public const String Werebear = "Werebear";
            public const String Wereboar = "Wereboar";
            public const String Weretiger = "Weretiger";
            public const String Wererat = "Wererat";
            public const String Werewolf = "Werewolf";
            public const String None = "";

            public static IEnumerable<String> GetMetaraces()
            {
                return new[]
                {
                    HalfCelestial,
                    HalfDragon,
                    HalfFiend,
                    Werebear,
                    Wereboar,
                    Wererat,
                    Weretiger,
                    Werewolf
                };
            }

            public static IEnumerable<String> GetAllMetaraces()
            {
                return GetMetaraces().Union(new[] { None });
            }
        }
    }
}