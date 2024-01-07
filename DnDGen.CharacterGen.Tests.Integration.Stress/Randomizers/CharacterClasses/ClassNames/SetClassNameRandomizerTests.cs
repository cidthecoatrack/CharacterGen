﻿using DnDGen.CharacterGen.Randomizers.CharacterClasses;
using Ninject;
using NUnit.Framework;

namespace DnDGen.CharacterGen.Tests.Integration.Stress.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public class SetClassNameRandomizerTests : StressTests
    {
        [Inject]
        public ISetClassNameRandomizer SetClassNameRandomizer { get; set; }
        [Inject, Named(ClassNameRandomizerTypeConstants.AnyNPC)]
        public IClassNameRandomizer AnyNPCClassNameRandomizer { get; set; }

        [TearDown]
        public void TearDown()
        {
            classNameRandomizer = GetNewInstanceOf<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyPlayer);
        }

        [Test]
        public void StressSetClassName()
        {
            stressor.Stress(AssertClassName);
        }

        protected void AssertClassName()
        {
            var prototype = GetCharacterPrototype();
            SetClassNameRandomizer.SetClassName = prototype.CharacterClass.Name;

            var className = SetClassNameRandomizer.Randomize(prototype.Alignment);
            Assert.That(className, Is.EqualTo(SetClassNameRandomizer.SetClassName));
        }

        [Test]
        public void StressSetNPCClassName()
        {
            classNameRandomizer = AnyNPCClassNameRandomizer;
            stressor.Stress(AssertClassName);
        }
    }
}