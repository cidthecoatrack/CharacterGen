﻿using System;
using System.Linq;
using NPCGen.Selectors.Interfaces;
using NPCGen.Selectors.Interfaces.Objects;

namespace NPCGen.Selectors
{
    public class StatPrioritySelector : IStatPrioritySelector
    {
        private ICollectionsSelector innerSelector;

        public StatPrioritySelector(ICollectionsSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public StatPrioritySelection SelectFor(String className)
        {
            var priorities = innerSelector.SelectFrom(INVALID"StatPriorities", className);

            var statPriority = new StatPrioritySelection();
            statPriority.First = priorities.First();
            statPriority.Second = priorities.Last();

            return statPriority;
        }
    }
}