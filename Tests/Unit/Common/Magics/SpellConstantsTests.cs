﻿using CharacterGen.Common.Magics;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Unit.Common.Magics
{
    [TestFixture]
    public class SpellConstantsTests
    {
        [TestCase(SpellConstants.Aid, "Aid")]
        [TestCase(SpellConstants.Blasphemy, "Blasphemy")]
        [TestCase(SpellConstants.Bless, "Bless")]
        [TestCase(SpellConstants.BlindnessDeafness, "Blindness/deafness")]
        [TestCase(SpellConstants.Blur, "Blur")]
        [TestCase(SpellConstants.CharmMonster, "Charm monster")]
        [TestCase(SpellConstants.CharmPerson, "Charm person")]
        [TestCase(SpellConstants.ConeOfCold, "Cone of cold")]
        [TestCase(SpellConstants.Contagion, "Contagion")]
        [TestCase(SpellConstants.CureCriticalWounds, "Cure critical wounds")]
        [TestCase(SpellConstants.CureLightWounds, "Cure light wounds")]
        [TestCase(SpellConstants.CureModerateWounds, "Cure moderate wounds")]
        [TestCase(SpellConstants.CureSeriousWounds, "Cure serious wounds")]
        [TestCase(SpellConstants.DancingLights, "Dancing lights")]
        [TestCase(SpellConstants.Darkness, "Darkness")]
        [TestCase(SpellConstants.Daylight, "Daylight")]
        [TestCase(SpellConstants.Daze, "Daze")]
        [TestCase(SpellConstants.Desecrate, "Desecrate")]
        [TestCase(SpellConstants.Destruction, "Destruction")]
        [TestCase(SpellConstants.DetectEvil, "Detect evil")]
        [TestCase(SpellConstants.DetectThoughts, "Detect thoughts")]
        [TestCase(SpellConstants.DisguiseSelf, "Disguise self")]
        [TestCase(SpellConstants.DispelEvil, "Dispel evil")]
        [TestCase(SpellConstants.EnlargePerson, "Enlarge person")]
        [TestCase(SpellConstants.FaerieFire, "Faerie fire")]
        [TestCase(SpellConstants.GaseousForm, "Gaseous form")]
        [TestCase(SpellConstants.GhostSound, "Ghost sound")]
        [TestCase(SpellConstants.Hallow, "Hallow")]
        [TestCase(SpellConstants.Heal, "Heal")]
        [TestCase(SpellConstants.HolyAura, "Holy aura")]
        [TestCase(SpellConstants.HolySmite, "Holy smite")]
        [TestCase(SpellConstants.HolyWord, "Holy word")]
        [TestCase(SpellConstants.HorridWilting, "Horrid wilting")]
        [TestCase(SpellConstants.Invisibility, "Invisibility")]
        [TestCase(SpellConstants.Levitate, "Levitate")]
        [TestCase(SpellConstants.MassCharmMonster, "Mass charm monster")]
        [TestCase(SpellConstants.NeutralizePoison, "Neutralize poison")]
        [TestCase(SpellConstants.Nondetection, "Nondetection")]
        [TestCase(SpellConstants.PassWithoutTrace, "Pass without trace")]
        [TestCase(SpellConstants.PlaneShift, "Plane shift")]
        [TestCase(SpellConstants.Poison, "Poison")]
        [TestCase(SpellConstants.Prestidigitation, "Prestidigitation")]
        [TestCase(SpellConstants.ProtectionFromEvil, "Protection from evil")]
        [TestCase(SpellConstants.RemoveDisease, "Remove disease")]
        [TestCase(SpellConstants.Resurrection, "Resurrection")]
        [TestCase(SpellConstants.Sleep, "Sleep")]
        [TestCase(SpellConstants.SoundBurst, "Sound burst")]
        [TestCase(SpellConstants.SpeakWithAnimals, "Speak with animals")]
        [TestCase(SpellConstants.Suggestion, "Suggestion")]
        [TestCase(SpellConstants.SummonMonsterI, "Summon monster I")]
        [TestCase(SpellConstants.SummonMonsterII, "Summon monster II")]
        [TestCase(SpellConstants.SummonMonsterIII, "Summon monster III")]
        [TestCase(SpellConstants.SummonMonsterIV, "Summon monster IV")]
        [TestCase(SpellConstants.SummonMonsterV, "Summon monster V")]
        [TestCase(SpellConstants.SummonMonsterVI, "Summon monster VI")]
        [TestCase(SpellConstants.SummonMonsterVII, "Summon monster VII")]
        [TestCase(SpellConstants.SummonMonsterVIII, "Summon monster VIII")]
        [TestCase(SpellConstants.SummonMonsterIX, "Summon monster IX")]
        [TestCase(SpellConstants.SummonNaturesAllyI, "Summon nature's ally I")]
        [TestCase(SpellConstants.SummonNaturesAllyII, "Summon nature's ally II")]
        [TestCase(SpellConstants.SummonNaturesAllyIII, "Summon nature's ally III")]
        [TestCase(SpellConstants.SummonNaturesAllyIV, "Summon nature's ally IV")]
        [TestCase(SpellConstants.SummonNaturesAllyV, "Summon nature's ally V")]
        [TestCase(SpellConstants.SummonNaturesAllyVI, "Summon nature's ally VI")]
        [TestCase(SpellConstants.SummonNaturesAllyVII, "Summon nature's ally VII")]
        [TestCase(SpellConstants.SummonNaturesAllyVIII, "Summon nature's ally VIII")]
        [TestCase(SpellConstants.SummonNaturesAllyIX, "Summon nature's ally IX")]
        [TestCase(SpellConstants.Unhallow, "Unhallow")]
        [TestCase(SpellConstants.UnholyAura, "Unholy aura")]
        [TestCase(SpellConstants.UnholyBlight, "Unholy blight")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}