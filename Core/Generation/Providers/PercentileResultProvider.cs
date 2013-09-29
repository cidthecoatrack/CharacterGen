﻿using D20Dice.Dice;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Xml.Parsers.Interfaces;
using NPCGen.Core.Generation.Xml.Parsers.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPCGen.Core.Generation.Providers
{
    public class PercentileResultProvider : IPercentileResultProvider
    {
        private IPercentileXmlParser percentileXmlParser;
        private IDice dice;
        private Dictionary<String, IEnumerable<PercentileObject>> cachedTables;

        public PercentileResultProvider(IPercentileXmlParser percentileXmlParser, IDice dice)
        {
            this.percentileXmlParser = percentileXmlParser;
            this.dice = dice;
            cachedTables = new Dictionary<String, IEnumerable<PercentileObject>>();
        }

        public String GetPercentileResult(String tableName)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            var percentileObject = GetPercentileObject(tableName);

            if (percentileObject == null)
                return String.Empty;

            return percentileObject.Content;
        }

        private void CacheTable(String tableName)
        {
            var filename = tableName + ".xml";
            var table = percentileXmlParser.Parse(filename);
            cachedTables.Add(tableName, table);
        }

        private PercentileObject GetPercentileObject(String tableName)
        {
            var roll = dice.Percentile();
            return cachedTables[tableName].FirstOrDefault(o => RollIsInRange(roll, o));
        }

        private Boolean RollIsInRange(Int32 roll, PercentileObject percentileObject)
        {
            return percentileObject.LowerLimit <= roll && roll <= percentileObject.UpperLimit;
        }
    }
}