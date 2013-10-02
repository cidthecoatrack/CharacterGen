﻿using D20Dice.Dice;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Randomizers.Alignments;
using NPCGen.Core.Generation.Randomizers.Alignments.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Alignments
{
    [TestFixture]
    public class AnyAlignmentRandomizerTests
    {
        private IAlignmentRandomizer alignmentRandomizer;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            alignmentRandomizer = new AnyAlignmentRandomizer(mockDice.Object);
        }

        [Test]
        public void LawfulIs3OnD3()
        {
            mockDice.Setup(d => d.d3(1, 0)).Returns(3);
            var alignment = alignmentRandomizer.Randomize();
            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Lawful));
        }

        [Test]
        public void NeutralLawfulnessIs2OnD3()
        {
            mockDice.Setup(d => d.d3(1, 0)).Returns(2);
            var alignment = alignmentRandomizer.Randomize();
            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Neutral));
        }

        [Test]
        public void ChaoticIs1OnD3()
        {
            mockDice.Setup(d => d.d3(1, 0)).Returns(1);
            var alignment = alignmentRandomizer.Randomize();
            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Chaotic));
        }

        [Test]
        public void GoodPercentile()
        {
            for (var roll = 1; roll <= 20; roll++)
            {
                mockDice.Setup(d => d.Percentile(1, 0)).Returns(roll);
                var alignment = alignmentRandomizer.Randomize();
                Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Good));
            }
        }

        [Test]
        public void NeutralGoodnessPercentile()
        {
            for (var roll = 21; roll <= 50; roll++)
            {
                mockDice.Setup(d => d.Percentile(1, 0)).Returns(roll);
                var alignment = alignmentRandomizer.Randomize();
                Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Neutral));
            }
        }

        [Test]
        public void EvilPercentile()
        {
            for (var roll = 51; roll <= 100; roll++)
            {
                mockDice.Setup(d => d.Percentile(1, 0)).Returns(roll);
                var alignment = alignmentRandomizer.Randomize();
                Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Evil));
            }
        }
    }
}