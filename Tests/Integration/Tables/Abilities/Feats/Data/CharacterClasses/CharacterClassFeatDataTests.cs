﻿using CharacterGen.Tables;
using System;
using System.Collections.Generic;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Data.CharacterClasses
{
    public abstract class CharacterClassFeatDataTests : DataTests
    {
        protected override void PopulateIndices(IEnumerable<String> collection)
        {
            indices[DataIndexConstants.CharacterClassFeatData.FeatNameIndex] = "FeatId";
            indices[DataIndexConstants.CharacterClassFeatData.FocusTypeIndex] = "FocusType";
            indices[DataIndexConstants.CharacterClassFeatData.FrequencyQuantityIndex] = "FrequencyQuantity";
            indices[DataIndexConstants.CharacterClassFeatData.FrequencyQuantityStatIndex] = "FrequencyQuantityStat";
            indices[DataIndexConstants.CharacterClassFeatData.FrequencyTimePeriodIndex] = "FrequencyTimePeriod";
            indices[DataIndexConstants.CharacterClassFeatData.MaximumLevelRequirementIndex] = "MaxLevel";
            indices[DataIndexConstants.CharacterClassFeatData.MinimumLevelRequirementIndex] = "MinLevel";
            indices[DataIndexConstants.CharacterClassFeatData.StrengthIndex] = "Strength";
            indices[DataIndexConstants.CharacterClassFeatData.SizeRequirementIndex] = "SizeRequirement";
        }

        public virtual void Data(String name, String feat, String focusType, Int32 frequencyQuantity, String frequencyQuantityStat, String frequencyTimePeriod, Int32 minimumLevel, Int32 maximumLevel, Int32 strength, String sizeRequirement)
        {
            var data = new List<String>();
            for (var i = 0; i < 8; i++)
                data.Add(String.Empty);

            data[DataIndexConstants.CharacterClassFeatData.FeatNameIndex] = feat;
            data[DataIndexConstants.CharacterClassFeatData.FocusTypeIndex] = focusType;
            data[DataIndexConstants.CharacterClassFeatData.FrequencyQuantityIndex] = Convert.ToString(frequencyQuantity);
            data[DataIndexConstants.CharacterClassFeatData.FrequencyQuantityStatIndex] = frequencyQuantityStat;
            data[DataIndexConstants.CharacterClassFeatData.FrequencyTimePeriodIndex] = frequencyTimePeriod;
            data[DataIndexConstants.CharacterClassFeatData.MaximumLevelRequirementIndex] = Convert.ToString(maximumLevel);
            data[DataIndexConstants.CharacterClassFeatData.MinimumLevelRequirementIndex] = Convert.ToString(minimumLevel);
            data[DataIndexConstants.CharacterClassFeatData.StrengthIndex] = Convert.ToString(strength);
            data[DataIndexConstants.CharacterClassFeatData.SizeRequirementIndex] = sizeRequirement;

            Data(name, data);
        }
    }
}
