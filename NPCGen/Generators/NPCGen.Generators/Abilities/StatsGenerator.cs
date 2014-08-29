﻿using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using NPCGen.Common.Abilities.Stats;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Races;
using NPCGen.Generators.Interfaces.Abilities;
using NPCGen.Generators.Interfaces.Randomizers.Stats;
using NPCGen.Selectors.Interfaces;

namespace NPCGen.Generators.Abilities
{
    public class StatsGenerator : IStatsGenerator
    {
        private IDice dice;
        private IStatPrioritySelector statPrioritySelector;
        private IStatAdjustmentsSelector statAdjustmentsSelector;

        public StatsGenerator(IDice dice, IStatPrioritySelector statPrioritySelector, IStatAdjustmentsSelector statAdjustmentsSelector)
        {
            this.dice = dice;
            this.statPrioritySelector = statPrioritySelector;
            this.statAdjustmentsSelector = statAdjustmentsSelector;
        }

        public Dictionary<String, Stat> GenerateWith(IStatsRandomizer statsRandomizer, CharacterClass characterClass, Race race)
        {
            var stats = statsRandomizer.Randomize();

            var statPriorities = statPrioritySelector.SelectStatPrioritiesFor(characterClass.ClassName);
            var prioritizedStats = PrioritizeStats(stats, statPriorities);

            var statAdjustments = statAdjustmentsSelector.SelectAdjustmentsFor(race);

            foreach (var stat in prioritizedStats.Keys)
            {
                prioritizedStats[stat].Value += statAdjustments[stat];
                prioritizedStats[stat].Value = Math.Max(prioritizedStats[stat].Value, 1);
            }

            var increasedStats = IncreaseStats(prioritizedStats, statPriorities, characterClass.Level);

            return increasedStats;
        }

        private Dictionary<String, Stat> PrioritizeStats(Dictionary<String, Stat> stats, StatPriority priorities)
        {
            var prioritizedStats = new Dictionary<String, Stat>(stats);

            var maxStat = prioritizedStats.Keys.First(k => prioritizedStats[k].Value == prioritizedStats.Values.Max(s => s.Value));

            var temp = prioritizedStats[maxStat];
            prioritizedStats[maxStat] = prioritizedStats[priorities.FirstPriority];
            prioritizedStats[priorities.FirstPriority] = temp;

            var secondMaxStat = prioritizedStats.Keys.First(k => prioritizedStats[k].Value == prioritizedStats.Values
                .Where(s => s != prioritizedStats[priorities.FirstPriority]).Max(s => s.Value));

            temp = prioritizedStats[secondMaxStat];
            prioritizedStats[secondMaxStat] = prioritizedStats[priorities.SecondPriority];
            prioritizedStats[priorities.SecondPriority] = temp;

            return prioritizedStats;
        }

        private Dictionary<String, Stat> IncreaseStats(Dictionary<String, Stat> stats, StatPriority priorities, Int32 level)
        {
            var count = level / 4;
            while (count-- > 0)
            {
                var roll = dice.Roll().d2();

                if (roll == 1)
                    stats[priorities.FirstPriority].Value++;
                else
                    stats[priorities.SecondPriority].Value++;
            }

            return stats;
        }
    }
}