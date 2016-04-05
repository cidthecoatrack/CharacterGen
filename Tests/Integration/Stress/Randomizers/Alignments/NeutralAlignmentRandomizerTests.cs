﻿using CharacterGen.Common.Alignments;
using CharacterGen.Generators.Randomizers.Alignments;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Stress.Randomizers.Alignments
{
    [TestFixture]
    public class NeutralAlignmentRandomizerTests : StressTests
    {
        [SetUp]
        public void Setup()
        {
            AlignmentRandomizer = GetNewInstanceOf<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Neutral);
        }

        [TestCase("Neutral Alignment Randomizer")]
        public override void Stress(string stressSubject)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var alignment = AlignmentRandomizer.Randomize();
            Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Good)
                .Or.EqualTo(AlignmentConstants.Neutral)
                .Or.EqualTo(AlignmentConstants.Evil));
            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Lawful)
                .Or.EqualTo(AlignmentConstants.Neutral)
                .Or.EqualTo(AlignmentConstants.Chaotic));
            Assert.That(AlignmentConstants.Neutral, Is.EqualTo(alignment.Goodness)
                .Or.EqualTo(alignment.Lawfulness));
        }

        [Test]
        public void NeutralGoodnessHappens()
        {
            var alignment = GenerateOrFail(AlignmentRandomizer.Randomize,
                a => a.Goodness == AlignmentConstants.Neutral && a.Lawfulness != AlignmentConstants.Neutral);

            Assert.That(alignment.Lawfulness, Is.Not.EqualTo(AlignmentConstants.Neutral));
            Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Neutral));
        }

        [Test]
        public void NeutralLawfulnessHappens()
        {
            var alignment = GenerateOrFail(AlignmentRandomizer.Randomize,
                a => a.Lawfulness == AlignmentConstants.Neutral && a.Goodness != AlignmentConstants.Neutral);

            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Neutral));
            Assert.That(alignment.Goodness, Is.Not.EqualTo(AlignmentConstants.Neutral));
        }

        [Test]
        public void TrueNeutralHappens()
        {
            var alignment = GenerateOrFail(AlignmentRandomizer.Randomize,
                a => a.Goodness == AlignmentConstants.Neutral && a.Lawfulness == AlignmentConstants.Neutral);

            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Neutral));
            Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Neutral));
        }
    }
}