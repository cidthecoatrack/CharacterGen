﻿using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using Moq;
using NPCGen.Common.Alignments;
using NPCGen.Generators;
using NPCGen.Generators.Interfaces;
using NPCGen.Generators.Interfaces.Randomizers.CharacterClasses;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators
{
    [TestFixture]
    public class CharacterClassGeneratorTests
    {
        private const String ClassName = "class name";

        private Mock<ILevelRandomizer> mockLevelRandomizer;
        private Mock<IClassNameRandomizer> mockClassNameRandomizer;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<IAdjustmentsSelector> mockAdjustmentsSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<IDice> mockDice;
        private ICharacterClassGenerator characterClassGenerator;
        private Alignment alignment;
        private Dictionary<String, Int32> specialistFieldQuantities;
        private Dictionary<String, Int32> prohibitedFieldQuantities;
        private List<String> specialistFields;
        private List<String> prohibitedFields;

        [SetUp]
        public void Setup()
        {
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockAdjustmentsSelector = new Mock<IAdjustmentsSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockDice = new Mock<IDice>();
            characterClassGenerator = new CharacterClassGenerator(mockAdjustmentsSelector.Object, mockCollectionsSelector.Object, mockBooleanPercentileSelector.Object,
                mockDice.Object);

            alignment = new Alignment();
            mockLevelRandomizer = new Mock<ILevelRandomizer>();
            mockClassNameRandomizer = new Mock<IClassNameRandomizer>();
            specialistFieldQuantities = new Dictionary<String, Int32>();
            prohibitedFieldQuantities = new Dictionary<String, Int32>();
            specialistFields = new List<String>();
            prohibitedFields = new List<String>();

            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.SpecialistFieldQuantities)).Returns(specialistFieldQuantities);
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.ProhibitedFieldQuantities)).Returns(prohibitedFieldQuantities);
            mockClassNameRandomizer.Setup(r => r.Randomize(alignment)).Returns(ClassName);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.SpecialistFields, ClassName)).Returns(specialistFields);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ProhibitedFields, ClassName)).Returns(prohibitedFields);
        }

        [Test]
        public void GeneratorReturnsRandomizedLevel()
        {
            mockLevelRandomizer.Setup(r => r.Randomize()).Returns(9266);

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.Level, Is.EqualTo(9266));
        }

        [Test]
        public void GeneratorReturnsRandomizedClass()
        {
            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.ClassName, Is.EqualTo(ClassName));
        }

        [Test]
        public void DoNotGetSpecialistFieldsIfShouldNotHaveAny()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(false);
            specialistFieldQuantities[ClassName] = 1;
            specialistFields.Add("field 1");

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.SpecialistFields, Is.Empty);
        }

        [Test]
        public void DoNotGetSpecialistFieldsIfNone()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 1;

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.SpecialistFields, Is.Empty);
        }

        [Test]
        public void GetSpecialistField()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 1;
            specialistFields.Add("field 1");
            specialistFields.Add("field 2");
            mockDice.Setup(d => d.Roll(1).d(2)).Returns(2);

            prohibitedFieldQuantities["field 1"] = 0;
            prohibitedFieldQuantities["field 2"] = 0;

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.SpecialistFields, Contains.Item("field 2"));
            Assert.That(characterClass.SpecialistFields.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetSpecialistFields()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 2;
            specialistFields.Add("field 1");
            specialistFields.Add("field 2");
            specialistFields.Add("field 3");
            mockDice.SetupSequence(d => d.Roll(1).d(3)).Returns(3).Returns(1);

            prohibitedFieldQuantities["field 1"] = 0;
            prohibitedFieldQuantities["field 2"] = 0;
            prohibitedFieldQuantities["field 3"] = 0;

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.SpecialistFields, Contains.Item("field 3"));
            Assert.That(characterClass.SpecialistFields, Contains.Item("field 1"));
            Assert.That(characterClass.SpecialistFields.Count(), Is.EqualTo(2));
        }

        [Test]
        public void CannotSpecializeInAlignmentFieldThatDoesNotMatchAlignment()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 1;
            specialistFields.Add("alignment field");
            specialistFields.Add("non-alignment field");

            alignment.Goodness = "goodness";
            alignment.Lawfulness = "lawfulness";

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ProhibitedFields, alignment.ToString()))
                .Returns(new[] { "non-alignment field" });

            prohibitedFieldQuantities["alignment field"] = 0;

            mockDice.Setup(d => d.Roll(1).d(1)).Returns(1);

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.SpecialistFields, Contains.Item("alignment field"));
            Assert.That(characterClass.SpecialistFields.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotGetProhibitedFieldsIfThereAreNoSpecialistFields()
        {
            prohibitedFields.Add("field 1");
            mockDice.Setup(d => d.Roll(1).d(2)).Returns(1);

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.SpecialistFields, Is.Empty);
            Assert.That(characterClass.ProhibitedFields, Is.Empty);
        }

        [Test]
        public void DoNotGetProhibitedFieldsIfNone()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 1;
            specialistFields.Add("field 1");
            mockDice.Setup(d => d.Roll(1).d(1)).Returns(1);

            prohibitedFieldQuantities["field 1"] = 1;

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.ProhibitedFields, Is.Empty);
        }

        [Test]
        public void GetProhibitedField()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 1;
            specialistFields.Add("field 1");
            mockDice.Setup(d => d.Roll(1).d(1)).Returns(1);

            prohibitedFieldQuantities["field 1"] = 1;
            prohibitedFields.Add("field 1");
            prohibitedFields.Add("field 2");

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.ProhibitedFields, Contains.Item("field 2"));
            Assert.That(characterClass.ProhibitedFields.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ProhibitedFieldCannotAlreadyBeASpecialistField()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 1;
            specialistFields.Add("field 1");
            mockDice.Setup(d => d.Roll(1).d(1)).Returns(1);

            prohibitedFieldQuantities["field 1"] = 1;
            prohibitedFields.Add("field 1");
            prohibitedFields.Add("field 2");
            mockDice.Setup(d => d.Roll(1).d(2)).Returns(2);

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.ProhibitedFields, Contains.Item("field 2"));
            Assert.That(characterClass.ProhibitedFields.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetProhibitedFields()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 1;
            specialistFields.Add("field 2");
            mockDice.Setup(d => d.Roll(1).d(1)).Returns(1);

            prohibitedFieldQuantities["field 2"] = 2;
            prohibitedFields.Add("field 1");
            prohibitedFields.Add("field 2");
            prohibitedFields.Add("field 3");
            prohibitedFields.Add("field 4");
            mockDice.SetupSequence(d => d.Roll(1).d(3)).Returns(3).Returns(1);

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.ProhibitedFields, Contains.Item("field 4"));
            Assert.That(characterClass.ProhibitedFields, Contains.Item("field 1"));
            Assert.That(characterClass.ProhibitedFields.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetProhibitedFieldsFromMultipleSpecialistFields()
        {
            var tableName = String.Format(TableNameConstants.Formattable.TrueOrFalse.CLASSHasSpecialistFields, ClassName);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);
            specialistFieldQuantities[ClassName] = 2;
            specialistFields.Add("field 1");
            specialistFields.Add("field 2");
            mockDice.SetupSequence(d => d.Roll(1).d(2)).Returns(1).Returns(2);

            prohibitedFieldQuantities["field 1"] = 1;
            prohibitedFieldQuantities["field 2"] = 1;
            prohibitedFields.Add("field 1");
            prohibitedFields.Add("field 2");
            prohibitedFields.Add("field 3");
            prohibitedFields.Add("field 4");
            prohibitedFields.Add("field 5");
            mockDice.SetupSequence(d => d.Roll(1).d(3)).Returns(3).Returns(1);

            var characterClass = characterClassGenerator.GenerateWith(alignment, mockLevelRandomizer.Object, mockClassNameRandomizer.Object);
            Assert.That(characterClass.ProhibitedFields, Contains.Item("field 5"));
            Assert.That(characterClass.ProhibitedFields, Contains.Item("field 3"));
            Assert.That(characterClass.ProhibitedFields.Count(), Is.EqualTo(2));
        }
    }
}