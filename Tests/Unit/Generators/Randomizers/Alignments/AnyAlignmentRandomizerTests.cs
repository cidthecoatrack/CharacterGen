﻿using CharacterGen.Common.Alignments;
using CharacterGen.Generators.Domain.Randomizers.Alignments;
using CharacterGen.Selectors;
using CharacterGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CharacterGen.Tests.Unit.Generators.Randomizers.Alignments
{
    [TestFixture]
    public class AnyAlignmentRandomizerTests
    {
        private IEnumerable<Alignment> alignments;

        [SetUp]
        public void Setup()
        {
            var mockPercentileResultSelector = new Mock<IPercentileSelector>();
            var randomizer = new AnyAlignmentRandomizer(mockPercentileResultSelector.Object);

            mockPercentileResultSelector.Setup(p => p.SelectAllFrom(TableNameConstants.Set.Percentile.AlignmentGoodness))
                .Returns(new[] { AlignmentConstants.Good, AlignmentConstants.Neutral, AlignmentConstants.Evil });
            mockPercentileResultSelector.Setup(p => p.SelectAllFrom(TableNameConstants.Set.Percentile.AlignmentLawfulness))
                .Returns(new[] { AlignmentConstants.Lawful, AlignmentConstants.Neutral, AlignmentConstants.Chaotic });

            alignments = randomizer.GetAllPossibleResults();
        }

        [TestCase(AlignmentConstants.Lawful, AlignmentConstants.Good)]
        [TestCase(AlignmentConstants.Neutral, AlignmentConstants.Good)]
        [TestCase(AlignmentConstants.Chaotic, AlignmentConstants.Good)]
        [TestCase(AlignmentConstants.Lawful, AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.Neutral, AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.Chaotic, AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.Lawful, AlignmentConstants.Evil)]
        [TestCase(AlignmentConstants.Neutral, AlignmentConstants.Evil)]
        [TestCase(AlignmentConstants.Chaotic, AlignmentConstants.Evil)]
        public void Allowed(String lawfulness, String goodness)
        {
            var expectedAlignment = new Alignment { Lawfulness = lawfulness, Goodness = goodness };
            Assert.That(alignments, Contains.Item(expectedAlignment));
        }
    }
}