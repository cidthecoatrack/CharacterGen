﻿using CharacterGen.Mappers;
using CharacterGen.Selectors;
using CharacterGen.Selectors.Domain;
using CharacterGen.Selectors.Objects;
using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using System.Linq;

namespace CharacterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class CollectionsSelectorTests
    {
        private const string TableName = "table name";

        private ICollectionsSelector selector;
        private Mock<CollectionsMapper> mockMapper;
        private Mock<Dice> mockDice;
        private Dictionary<string, IEnumerable<string>> allCollections;

        [SetUp]
        public void Setup()
        {
            mockMapper = new Mock<CollectionsMapper>();
            mockDice = new Mock<Dice>();
            selector = new CollectionsSelector(mockMapper.Object, mockDice.Object);
            allCollections = new Dictionary<string, IEnumerable<string>>();

            mockMapper.Setup(m => m.Map(TableName)).Returns(allCollections);
        }

        [Test]
        public void SelectCollection()
        {
            allCollections["entry"] = Enumerable.Empty<string>();
            var collection = selector.SelectFrom(TableName, "entry");
            Assert.That(collection, Is.EqualTo(allCollections["entry"]));
        }

        [Test]
        public void SelectAllCollections()
        {
            var collections = selector.SelectAllFrom(TableName);
            Assert.That(collections, Is.EqualTo(allCollections));
        }

        [Test]
        public void IfEntryNotPresentInTable_ThrowException()
        {
            Assert.That(() => selector.SelectFrom(TableName, "entry"), Throws.Exception.With.Message.EqualTo("entry is not a valid entry in the table table name"));
        }

        [Test]
        public void SelectRandomItemFromCollection()
        {
            var collection = new[] { "item 1", "item 2", "item 3" };
            mockDice.Setup(d => d.Roll(1).IndividualRolls(3)).Returns(new[] { 2 });

            var item = selector.SelectRandomFrom(collection);
            Assert.That(item, Is.EqualTo("item 2"));
        }

        [Test]
        public void SelectRandomItemFromTable()
        {
            allCollections["entry"] = new[] { "item 1", "item 2", "item 3" };
            mockDice.Setup(d => d.Roll(1).IndividualRolls(3)).Returns(new[] { 2 });

            var item = selector.SelectRandomFrom(TableName, "entry");
            Assert.That(item, Is.EqualTo("item 2"));
        }

        [Test]
        public void CannotSelectRandomFromEmptyCollection()
        {
            var collection = Enumerable.Empty<string>();
            Assert.That(() => selector.SelectRandomFrom(collection), Throws.ArgumentException.With.Message.EqualTo("Cannot select random from an empty collection"));
        }

        [Test]
        public void CannotSelectRandomFromEmptyTable()
        {
            allCollections["entry"] = Enumerable.Empty<string>();
            Assert.That(() => selector.SelectRandomFrom(TableName, "entry"), Throws.ArgumentException.With.Message.EqualTo("Cannot select random from an empty collection"));
        }

        [Test]
        public void CannotSelectRandomFromInvalidEntry()
        {
            Assert.That(() => selector.SelectRandomFrom(TableName, "entry"), Throws.Exception.With.Message.EqualTo("entry is not a valid entry in the table table name"));
        }

        [Test]
        public void SelectRandomFromNonStringCollection()
        {
            var collection = new[]
            {
                new AdditionalFeatSelection { Feat = "feat 1" },
                new AdditionalFeatSelection { Feat = "feat 2" }
            };

            mockDice.Setup(d => d.Roll(1).IndividualRolls(2)).Returns(new[] { 2 });

            var item = selector.SelectRandomFrom(collection);
            Assert.That(item, Is.InstanceOf<AdditionalFeatSelection>());
            Assert.That(item.Feat, Is.EqualTo("feat 2"));
        }
    }
}