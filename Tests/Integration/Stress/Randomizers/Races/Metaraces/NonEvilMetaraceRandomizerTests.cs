﻿using System;
using System.Collections.Generic;
using Ninject;
using NPCGen.Common.Races;
using NPCGen.Generators.Interfaces.Randomizers.Races;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class NonEvilMetaraceRandomizerTests : MetaraceRandomizerTests
    {
        [Inject, Named(MetaraceRandomizerTypeConstants.NonEvil)]
        public override IMetaraceRandomizer MetaraceRandomizer { get; set; }

        protected override IEnumerable<String> particularMetaraces
        {
            get
            {
                return new[]
                {
                    RaceConstants.Metaraces.HalfDragon,
                    RaceConstants.Metaraces.HalfCelestial,
                    RaceConstants.Metaraces.Werebear,
                    RaceConstants.Metaraces.Wereboar,
                    RaceConstants.Metaraces.Weretiger,
                    String.Empty
                };
            }
        }
    }
}