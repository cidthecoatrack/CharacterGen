﻿using D20Dice.Dice;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Randomizers.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Alignments
{
    [TestFixture]
    public class GoodAlignmentTests
    {
        private IAlignmentRandomizer alignmentRandomizer;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            alignmentRandomizer = new GoodAlignment(mockDice.Object);
        }

        [Test]
        public void ForcedGood()
        {
            var alignment = alignmentRandomizer.Randomize();
            Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Good));
        }
    }
}