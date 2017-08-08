﻿using CharacterGen.Alignments;
using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Generators.Verifiers;
using CharacterGen.Domain.Selectors.Collections;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using CharacterGen.Verifiers;
using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterGen.Tests.Unit.Generators.Verifiers
{
    [TestFixture]
    public class RandomizerVerifierTests
    {
        private IRandomizerVerifier verifier;
        private Mock<IAlignmentRandomizer> mockAlignmentRandomizer;
        private Mock<IClassNameRandomizer> mockClassNameRandomizer;
        private Mock<ILevelRandomizer> mockLevelRandomizer;
        private Mock<RaceRandomizer> mockBaseRaceRandomizer;
        private Mock<RaceRandomizer> mockMetaraceRandomizer;
        private Mock<IAdjustmentsSelector> mockAdjustmentsSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<ISetLevelRandomizer> mockSetLevelRandomizer;
        private Mock<ISetClassNameRandomizer> mockSetClassNameRandomizer;

        private CharacterClass characterClass;
        private List<Alignment> alignments;
        private List<string> classNames;
        private List<int> levels;
        private List<string> baseRaces;
        private List<string> metaraces;
        private Dictionary<string, int> adjustments;
        private Alignment alignment;
        private Race race;
        private List<string> npcs;

        [SetUp]
        public void Setup()
        {
            mockAdjustmentsSelector = new Mock<IAdjustmentsSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            verifier = new RandomizerVerifier(mockAdjustmentsSelector.Object, mockCollectionsSelector.Object);
            mockAlignmentRandomizer = new Mock<IAlignmentRandomizer>();
            mockClassNameRandomizer = new Mock<IClassNameRandomizer>();
            mockSetClassNameRandomizer = new Mock<ISetClassNameRandomizer>();
            mockLevelRandomizer = new Mock<ILevelRandomizer>();
            mockSetLevelRandomizer = new Mock<ISetLevelRandomizer>();
            mockBaseRaceRandomizer = new Mock<RaceRandomizer>();
            mockMetaraceRandomizer = new Mock<RaceRandomizer>();

            alignments = new List<Alignment>();
            characterClass = new CharacterClass();
            classNames = new List<string>();
            levels = new List<int>();
            baseRaces = new List<string>();
            metaraces = new List<string>();
            adjustments = new Dictionary<string, int>();
            alignment = new Alignment();
            race = new Race();
            npcs = new List<string>();

            alignment.Goodness = Guid.NewGuid().ToString();
            alignment.Lawfulness = Guid.NewGuid().ToString();

            mockAlignmentRandomizer.Setup(r => r.GetAllPossibleResults()).Returns(alignments);
            mockClassNameRandomizer.Setup(r => r.GetAllPossibleResults(It.IsAny<Alignment>())).Returns(classNames);
            mockLevelRandomizer.Setup(r => r.GetAllPossibleResults()).Returns(levels);
            mockBaseRaceRandomizer.Setup(r => r.GetAllPossible(It.IsAny<Alignment>(), It.IsAny<CharacterClass>())).Returns(baseRaces);
            mockMetaraceRandomizer.Setup(r => r.GetAllPossible(It.IsAny<Alignment>(), It.IsAny<CharacterClass>())).Returns(metaraces);

            mockSetLevelRandomizer.SetupAllProperties();
            mockSetLevelRandomizer.Setup(r => r.GetAllPossibleResults()).Returns(() => new[] { mockSetLevelRandomizer.Object.SetLevel });

            mockSetClassNameRandomizer.SetupAllProperties();
            mockSetClassNameRandomizer.Setup(r => r.GetAllPossibleResults(It.IsAny<Alignment>())).Returns(() => new[] { mockSetClassNameRandomizer.Object.SetClassName });

            alignments.Add(alignment);

            characterClass.Level = 1;
            characterClass.Name = "class name";
            classNames.Add(characterClass.Name);
            levels.Add(characterClass.Level);
            npcs.Add("npc class name");

            race.BaseRace = "base race";
            race.Metarace = "metarace";
            baseRaces.Add(race.BaseRace);
            metaraces.Add(race.Metarace);

            adjustments[race.BaseRace] = 0;
            adjustments[race.Metarace] = 0;

            mockAdjustmentsSelector.Setup(p => p.SelectFrom(TableNameConstants.Set.Adjustments.LevelAdjustments, It.IsAny<string>())).Returns((string table, string name) => adjustments[name]);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ClassNameGroups, GroupConstants.NPCs)).Returns(npcs);
        }

        [Test]
        public void RandomizersVerifiedIfAllRandomizersAreCompatible()
        {
            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RandomizersNotVerifiedIfNoAlignments()
        {
            alignments.Clear();
            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RandomizersNotVerifiedIfNoClassNamesForAnyAlignment()
        {
            classNames.Clear();
            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RandomizersVerifiedIfAtLeastOneClassNameForAnAlignment()
        {
            alignments.Add(new Alignment());
            alignments.Add(new Alignment());

            mockClassNameRandomizer.SetupSequence(r => r.GetAllPossibleResults(It.IsAny<Alignment>())).Returns(Enumerable.Empty<string>())
                .Returns(Enumerable.Empty<string>()).Returns(classNames);

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RandomizersNotVerifiedIfNoLevels()
        {
            levels.Clear();
            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RandomizersNotVerifiedIfNoBaseRacesForAnyCharacterClass()
        {
            baseRaces.Clear();

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RandomizersVerifiedIfAtLeastOneBaseRaceForACharacterClass()
        {
            classNames.Add("second class name");
            classNames.Add("third class name");

            mockBaseRaceRandomizer.SetupSequence(r => r.GetAllPossible(It.IsAny<Alignment>(), It.IsAny<CharacterClass>()))
                .Returns(Enumerable.Empty<string>()).Returns(Enumerable.Empty<string>()).Returns(baseRaces);

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RandomizersNotVerifiedIfNoMetaracesForAnyCharacterClass()
        {
            metaraces.Clear();

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RandomizersVerifiedIfAtLeastOneMetaraceForACharacterClass()
        {
            classNames.Add("second class name");
            classNames.Add("third class name");

            mockMetaraceRandomizer.SetupSequence(r => r.GetAllPossible(It.IsAny<Alignment>(), It.IsAny<CharacterClass>()))
                .Returns(Enumerable.Empty<string>()).Returns(Enumerable.Empty<string>()).Returns(metaraces);

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RandomizersNotVerifiedIfLevelAdjustmentsCauseLevelToBeLessThan1()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;
            levels.Clear();
            levels.Add(2);

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RandomizersVerifiedIfOneLevelAdjustmentIsAllowed()
        {
            baseRaces.Add("other base race");
            metaraces.Add("other metarace");

            adjustments[baseRaces[0]] = 0;
            adjustments[metaraces[0]] = 8;
            adjustments[baseRaces[1]] = 3;
            adjustments[metaraces[1]] = 0;

            levels.Clear();
            levels.Add(2);

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RandomizersVerifiedIfSetLevelAdjustmentIsNotAllowed()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;

            mockSetLevelRandomizer.Object.SetLevel = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = false;

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RandomizersNotVerifiedIfSetLevelAdjustmentIsAllowed()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;

            mockSetLevelRandomizer.Object.SetLevel = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RandomizersNotVerifiedIfSetLevelAndSetMetarace()
        {
            metaraces.Clear();
            metaraces.Add("metarace");

            adjustments[metaraces[0]] = 2;
            levels.Clear();
            levels.Add(1);

            var verified = verifier.VerifyCompatibility(mockAlignmentRandomizer.Object, mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void AlignmentNotVerifiedIfNoClassNamesForAnyAlignment()
        {
            classNames.Clear();

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void AlignmentVerifiedIfAtLeastOneClassNameForAnAlignment()
        {
            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void AlignmentNotVerifiedIfNoLevels()
        {
            levels.Clear();

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void AlignmentNotVerifiedIfNoBaseRacesForAnyCharacterClass()
        {
            baseRaces.Clear();

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void AlignmentVerifiedIfAtLeastOneBaseRaceForACharacterClass()
        {
            classNames.Add("second class name");
            classNames.Add("third class name");

            mockBaseRaceRandomizer.SetupSequence(r => r.GetAllPossible(It.IsAny<Alignment>(), It.IsAny<CharacterClass>()))
                .Returns(Enumerable.Empty<string>()).Returns(Enumerable.Empty<string>()).Returns(baseRaces);

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void AlignmentNotVerifiedIfNoMetaracesForAnyCharacterClass()
        {
            metaraces.Clear();

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void AlignmentVerifiedIfAtLeastOneMetaraceForACharacterClass()
        {
            classNames.Add("second class name");
            classNames.Add("third class name");

            mockMetaraceRandomizer.SetupSequence(r => r.GetAllPossible(It.IsAny<Alignment>(), It.IsAny<CharacterClass>()))
                .Returns(Enumerable.Empty<string>()).Returns(Enumerable.Empty<string>()).Returns(metaraces);

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void AlignmentNotVerifiedIfLevelAdjustmentsCaseLevelToBeLessThan1()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;
            levels.Clear();
            levels.Add(2);

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void AlignmentVerifiedIfOneLevelAdjustmentIsAllowed()
        {
            baseRaces.Add("other base race");
            metaraces.Add("other metarace");

            adjustments[baseRaces[0]] = 0;
            adjustments[metaraces[0]] = 8;
            adjustments[baseRaces[1]] = 3;
            adjustments[metaraces[1]] = 0;

            levels.Clear();
            levels.Add(2);

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void AlignmentVerifiedIfSetLevelAdjustmentIsNotAllowed()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;

            mockSetLevelRandomizer.Object.SetLevel = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = false;

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void AlignmentNotVerifiedIfSetLevelAdjustmentIsAllowed()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;

            mockSetLevelRandomizer.Object.SetLevel = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            var verified = verifier.VerifyAlignmentCompatibility(alignments[0], mockClassNameRandomizer.Object, mockSetLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void CharacterClassNotVerifiedIfNoBaseRacesForAnyCharacterClass()
        {
            baseRaces.Clear();

            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void CharacterClassVerifiedIfAtLeastOneBaseRaceForACharacterClass()
        {
            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void CharacterClassNotVerifiedIfNoMetaracesForAnyCharacterClass()
        {
            metaraces.Clear();
            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void CharacterClassVerifiedIfAtLeastOneMetaraceForACharacterClass()
        {
            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void CharacterClassNotVerifiedIfLevelAdjustmentsMakeLevelLessThan1()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;

            characterClass.Level = 2;

            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void CharacterClassVerifiedIfOneLevelAdjustmentIsAllowed()
        {
            baseRaces.Add("other base race");
            metaraces.Add("other metarace");

            adjustments[baseRaces[0]] = 0;
            adjustments[metaraces[0]] = 8;
            adjustments[baseRaces[1]] = 3;
            adjustments[metaraces[1]] = 1;

            characterClass.Level = 2;

            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void CharacterClassVerifiedIfSetLevelAdjustmentIsNotAllowed()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;

            characterClass.Level = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = false;

            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockSetLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void CharacterClassNotVerifiedIfSetLevelAdjustmentIsAllowed()
        {
            adjustments[baseRaces[0]] = 1;
            adjustments[metaraces[0]] = 1;

            characterClass.Level = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            var verified = verifier.VerifyCharacterClassCompatibility(alignment, characterClass, mockSetLevelRandomizer.Object, mockBaseRaceRandomizer.Object, mockMetaraceRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RaceNotVerifiedIfLevelAdjustmentsMakeLevelLessThan1()
        {
            adjustments[race.BaseRace] = 1;
            adjustments[race.Metarace] = 1;

            characterClass.Level = 2;

            var verified = verifier.VerifyRaceCompatibility(race, characterClass, mockLevelRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RaceVerifiedIfLevelAdjustmentIsAllowed()
        {
            adjustments[race.BaseRace] = 0;
            adjustments[race.Metarace] = 1;

            characterClass.Level = 2;

            var verified = verifier.VerifyRaceCompatibility(race, characterClass, mockLevelRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RaceVerifiedIfSetLevelAdjustmentIsNotAllowed()
        {
            adjustments[race.BaseRace] = 1;
            adjustments[race.Metarace] = 1;

            characterClass.Level = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = false;

            var verified = verifier.VerifyRaceCompatibility(race, characterClass, mockSetLevelRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RaceNotVerifiedIfSetLevelAdjustmentIsAllowed()
        {
            adjustments[race.BaseRace] = 1;
            adjustments[race.Metarace] = 1;

            characterClass.Level = 2;
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            var verified = verifier.VerifyRaceCompatibility(race, characterClass, mockSetLevelRandomizer.Object);
            Assert.That(verified, Is.False);
        }

        [Test]
        public void RaceVerifiedForAnyNPC()
        {
            adjustments[race.BaseRace] = 9;
            adjustments[race.Metarace] = 2;
            npcs.Add(characterClass.Name);

            characterClass.Level = 20;
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            var verified = verifier.VerifyRaceCompatibility(race, characterClass, mockSetLevelRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RaceVerifiedForSetNPC()
        {
            adjustments[race.BaseRace] = 9;
            adjustments[race.Metarace] = 2;
            mockSetClassNameRandomizer.Object.SetClassName = npcs[0];

            characterClass.Level = 20;
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            var verified = verifier.VerifyRaceCompatibility(race, characterClass, mockSetLevelRandomizer.Object);
            Assert.That(verified, Is.True);
        }

        [Test]
        public void RaceNotVerifiedIfEffectiveLevelTooHigh()
        {
            adjustments[race.BaseRace] = 9;
            adjustments[race.Metarace] = 2;

            characterClass.Level = 20;
            mockSetLevelRandomizer.Object.AllowAdjustments = false;

            var verified = verifier.VerifyRaceCompatibility(race, characterClass, mockSetLevelRandomizer.Object);
            Assert.That(verified, Is.False);
        }
    }
}