﻿using NPCGen.Core.Data.CharacterClasses;
using NPCGen.Core.Generation.Randomizers.CharacterClasses.ClassNames;
using NPCGen.Core.Generation.Randomizers.CharacterClasses.Interfaces;
using NPCGen.Core.Generation.Randomizers.Races.Interfaces;
using NPCGen.Core.Generation.Verifiers.Interfaces;
using System;

namespace NPCGen.Core.Generation.Verifiers.Alignments
{
    public class NeutralAlignmentVerifier : IAlignmentVerifier
    {
        public Boolean VerifyCompatibility(IClassNameRandomizer classRandomizer)
        {
            if (classRandomizer is SetClassNameRandomizer)
            {
                var setClass = classRandomizer as SetClassNameRandomizer;
                var className = setClass.ClassName;

                return className != CharacterClassConstants.Paladin;
            }

            return true;
        }

        public Boolean VerifyCompatibility(IBaseRaceRandomizer baseRaceRandomizer)
        {
            return true;
        }

        public Boolean VerifyCompatibility(IMetaraceRandomizer metaraceRandomizer)
        {
            return true;
        }
    }
}