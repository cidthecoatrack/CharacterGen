﻿using System;
using System.Collections.Generic;
using Moq;
using NPCGen.Common.Alignments;
using NPCGen.Generators.Interfaces.Randomizers.CharacterClasses;
using NPCGen.Selectors.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Randomizers.CharacterClasses.ClassNames
{
    [TestFixture]
    public abstract class ClassNameRandomizerTests
    {
        protected const String ClassName = "class name";
        protected const String AlignmentClassName = "alignment class name";
        protected const String GroupClassName = "group class name";

        protected abstract String classNameGroup { get; }

        protected Mock<ICollectionsSelector> mockCollectionsSelector;
        protected Mock<IPercentileSelector> mockPercentileResultSelector;
        protected IClassNameRandomizer randomizer;
        protected Alignment alignment;
        protected List<String> alignmentClasses;
        protected List<String> groupClasses;

        [SetUp]
        public void ClassNameRandomizerTestsSetup()
        {
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockPercentileResultSelector = new Mock<IPercentileSelector>();
            alignment = new Alignment();
            alignmentClasses = new List<String>();
            groupClasses = new List<String>();

            alignment.Goodness = "goodness";
            alignment.Lawfulness = "lawfulness";
            mockCollectionsSelector.Setup(s => s.SelectFrom("ClassNameGroups", classNameGroup)).Returns(groupClasses);
            mockPercentileResultSelector.Setup(s => s.SelectAllFrom(It.IsAny<String>())).Returns(new[] { ClassName, AlignmentClassName, GroupClassName });
            mockCollectionsSelector.Setup(s => s.SelectFrom("ClassNameGroups", alignment.ToString())).Returns(alignmentClasses);
            alignmentClasses.Add(AlignmentClassName);
            groupClasses.Add(GroupClassName);
        }
    }
}