﻿using CharacterGen.CharacterClasses;
using CharacterGen.Randomizers.CharacterClasses;
using NUnit.Framework;
using System.Collections.Generic;

namespace CharacterGen.Tests.Integration.Stress.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class HealerClassNameRandomizerTests : ClassNameRandomizerTests
    {
        protected override IEnumerable<string> allowedClassNames
        {
            get
            {
                return new[]
                {
                    CharacterClassConstants.Bard,
                    CharacterClassConstants.Druid,
                    CharacterClassConstants.Paladin,
                    CharacterClassConstants.Ranger,
                    CharacterClassConstants.Cleric
                };
            }
        }

        [SetUp]
        public void Setup()
        {
            ClassNameRandomizer = GetNewInstanceOf<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.Healer);
        }

        [Test]
        public void StressClassName()
        {
            Stress(AssertClassName);
        }
    }
}