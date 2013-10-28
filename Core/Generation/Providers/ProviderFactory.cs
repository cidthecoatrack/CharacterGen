﻿using D20Dice.Dice;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Xml.Parsers;

namespace NPCGen.Core.Generation.Providers
{
    public static class ProviderFactory
    {
        public static IPercentileResultProvider CreatePercentileResultProviderUsing(IDice dice)
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var xmlParser = new PercentileXmlParser(streamLoader);
            return new PercentileResultProvider(xmlParser, dice);
        }

        public static IStatAdjustmentsProvider CreateStatAdjustmentsProvider()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var xmlParser = new StatAdjustmentXmlParser(streamLoader);
            return new StatAdjustmentsProvider(xmlParser);
        }
    }
}