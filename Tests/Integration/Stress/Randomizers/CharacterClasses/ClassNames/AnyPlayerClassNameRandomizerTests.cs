﻿using CharacterGen.Common.CharacterClasses;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using NUnit.Framework;
using System.Collections.Generic;

namespace CharacterGen.Tests.Integration.Stress.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class AnyPlayerClassNameRandomizerTests : ClassNameRandomizerTests
    {
        protected override IEnumerable<string> allowedClassNames
        {
            get
            {
                return new[] {
                    CharacterClassConstants.Barbarian,
                    CharacterClassConstants.Bard,
                    CharacterClassConstants.Cleric,
                    CharacterClassConstants.Druid,
                    CharacterClassConstants.Fighter,
                    CharacterClassConstants.Monk,
                    CharacterClassConstants.Paladin,
                    CharacterClassConstants.Ranger,
                    CharacterClassConstants.Rogue,
                    CharacterClassConstants.Sorcerer,
                    CharacterClassConstants.Wizard
                };
            }
        }

        [SetUp]
        public void Setup()
        {
            ClassNameRandomizer = GetNewInstanceOf<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyPlayer);
        }

        [TestCase("Any Player Class Name Randomizer")]
        public override void Stress(string stressSubject)
        {
            Stress();
        }
    }
}