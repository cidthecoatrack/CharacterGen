﻿using CharacterGen.Domain.Tables;
using NUnit.Framework;
using TreasureGen.Items;

namespace CharacterGen.Tests.Integration.Tables.Items.Powers
{
    [TestFixture]
    public class Level24PowerTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Percentile.LevelXPower, 24); }
        }

        [TestCase(1, 23, PowerConstants.Medium)]
        [TestCase(24, 100, PowerConstants.Major)]
        public override void Percentile(int lower, int upper, string content)
        {
            base.Percentile(lower, upper, content);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}
