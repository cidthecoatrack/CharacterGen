﻿using System;
using System.Collections.Generic;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Xml.Parsers.Interfaces;

namespace NPCGen.Core.Generation.Providers
{
    public class LevelAdjustmentsProvider : ILevelAdjustmentsProvider
    {
        private ILevelAdjustmentXmlParser adjustmentXmlParser;

        public LevelAdjustmentsProvider(ILevelAdjustmentXmlParser adjustmentXmlParser)
        {
            this.adjustmentXmlParser = adjustmentXmlParser;
        }

        public Dictionary<String, Int32> GetLevelAdjustments()
        {
            throw new NotImplementedException();
        }
    }
}