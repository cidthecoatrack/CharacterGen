﻿using D20Dice.Dice;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Randomizers.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Alignments
{
    [TestFixture]
    public class NeutralAlignmentTests
    {
        private IAlignmentRandomizer alignmentRandomizer;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            alignmentRandomizer = new NeutralAlignment(mockDice.Object);
        }

        [Test]
        public void ForcedNeutralLawfulness()
        {
            mockDice.SetupSequence(d => d.d3(1, 0)).Returns(1).Returns(2);
            mockDice.Setup(d => d.Percentile(1, 0)).Returns(1);

            var alignment = alignmentRandomizer.Randomize();
            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Neutral));
            mockDice.Verify(d => d.d3(1, 0), Times.Exactly(2));
        }

        [Test]
        public void ForcedNeutralGoodness()
        {
            mockDice.Setup(d => d.d3(1, 0)).Returns(1);
            mockDice.SetupSequence(d => d.Percentile(1, 0)).Returns(1).Returns(50);

            var alignment = alignmentRandomizer.Randomize();
            Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Neutral));
            mockDice.Verify(d => d.Percentile(1, 0), Times.Exactly(2));
        }
    }
}