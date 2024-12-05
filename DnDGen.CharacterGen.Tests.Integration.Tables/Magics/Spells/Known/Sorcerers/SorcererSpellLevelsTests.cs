﻿using DnDGen.CharacterGen.CharacterClasses;
using DnDGen.CharacterGen.Magics;
using DnDGen.CharacterGen.Tables;
using NUnit.Framework;

namespace DnDGen.CharacterGen.Tests.Integration.Tables.Magics.Spells.Known.Sorcerers
{
    [TestFixture]
    public class SorcererSpellLevelsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.Formattable.Adjustments.CLASSSpellLevels, CharacterClassConstants.Sorcerer);
            }
        }

        [Test]
        public override void CollectionNames()
        {
            var spellGroups = GetTable(TableNameConstants.Set.Collection.SpellGroups);
            AssertCollectionNames(spellGroups[CharacterClassConstants.Sorcerer]);
        }

        [TestCase(SpellConstants.AcidSplash, 0)]
        [TestCase(SpellConstants.Resistance, 0)]
        [TestCase(SpellConstants.DetectPoison, 0)]
        [TestCase(SpellConstants.DetectMagic, 0)]
        [TestCase(SpellConstants.ReadMagic, 0)]
        [TestCase(SpellConstants.Daze, 0)]
        [TestCase(SpellConstants.DancingLights, 0)]
        [TestCase(SpellConstants.Flare, 0)]
        [TestCase(SpellConstants.Light, 0)]
        [TestCase(SpellConstants.RayOfFrost, 0)]
        [TestCase(SpellConstants.GhostSound, 0)]
        [TestCase(SpellConstants.DisruptUndead, 0)]
        [TestCase(SpellConstants.TouchOfFatigue, 0)]
        [TestCase(SpellConstants.MageHand, 0)]
        [TestCase(SpellConstants.Mending, 0)]
        [TestCase(SpellConstants.Message, 0)]
        [TestCase(SpellConstants.OpenClose, 0)]
        [TestCase(SpellConstants.ArcaneMark, 0)]
        [TestCase(SpellConstants.Prestidigitation, 0)]
        [TestCase(SpellConstants.Alarm, 1)]
        [TestCase(SpellConstants.EndureElements, 1)]
        [TestCase(SpellConstants.HoldPortal, 1)]
        [TestCase(SpellConstants.ProtectionFromChaos, 1)]
        [TestCase(SpellConstants.ProtectionFromEvil, 1)]
        [TestCase(SpellConstants.ProtectionFromGood, 1)]
        [TestCase(SpellConstants.ProtectionFromLaw, 1)]
        [TestCase(SpellConstants.Shield, 1)]
        [TestCase(SpellConstants.Grease, 1)]
        [TestCase(SpellConstants.MageArmor, 1)]
        [TestCase(SpellConstants.Mount, 1)]
        [TestCase(SpellConstants.ObscuringMist, 1)]
        [TestCase(SpellConstants.SummonMonsterI, 1)]
        [TestCase(SpellConstants.UnseenServant, 1)]
        [TestCase(SpellConstants.ComprehendLanguages, 1)]
        [TestCase(SpellConstants.DetectSecretDoors, 1)]
        [TestCase(SpellConstants.DetectUndead, 1)]
        [TestCase(SpellConstants.Identify, 1)]
        [TestCase(SpellConstants.TrueStrike, 1)]
        [TestCase(SpellConstants.CharmPerson, 1)]
        [TestCase(SpellConstants.Hypnotism, 1)]
        [TestCase(SpellConstants.Sleep, 1)]
        [TestCase(SpellConstants.BurningHands, 1)]
        [TestCase(SpellConstants.TensersFloatingDisk, 1)]
        [TestCase(SpellConstants.MagicMissile, 1)]
        [TestCase(SpellConstants.ShockingGrasp, 1)]
        [TestCase(SpellConstants.ColorSpray, 1)]
        [TestCase(SpellConstants.DisguiseSelf, 1)]
        [TestCase(SpellConstants.NystulsMagicAura, 1)]
        [TestCase(SpellConstants.SilentImage, 1)]
        [TestCase(SpellConstants.Ventriloquism, 1)]
        [TestCase(SpellConstants.CauseFear, 1)]
        [TestCase(SpellConstants.ChillTouch, 1)]
        [TestCase(SpellConstants.RayOfEnfeeblement, 1)]
        [TestCase(SpellConstants.AnimateRope, 1)]
        [TestCase(SpellConstants.EnlargePerson, 1)]
        [TestCase(SpellConstants.Erase, 1)]
        [TestCase(SpellConstants.ExpeditiousRetreat, 1)]
        [TestCase(SpellConstants.FeatherFall, 1)]
        [TestCase(SpellConstants.Jump, 1)]
        [TestCase(SpellConstants.MagicWeapon, 1)]
        [TestCase(SpellConstants.ReducePerson, 1)]
        [TestCase(SpellConstants.ArcaneLock, 2)]
        [TestCase(SpellConstants.ObscureObject, 2)]
        [TestCase(SpellConstants.ProtectionFromArrows, 2)]
        [TestCase(SpellConstants.ResistEnergy, 2)]
        [TestCase(SpellConstants.MelfsAcidArrow, 2)]
        [TestCase(SpellConstants.FogCloud, 2)]
        [TestCase(SpellConstants.Glitterdust, 2)]
        [TestCase(SpellConstants.SummonMonsterII, 2)]
        [TestCase(SpellConstants.SummonSwarm, 2)]
        [TestCase(SpellConstants.Web, 2)]
        [TestCase(SpellConstants.DetectThoughts, 2)]
        [TestCase(SpellConstants.LocateObject, 2)]
        [TestCase(SpellConstants.SeeInvisibility, 2)]
        [TestCase(SpellConstants.DazeMonster, 2)]
        [TestCase(SpellConstants.TashasHideousLaughter, 2)]
        [TestCase(SpellConstants.TouchOfIdiocy, 2)]
        [TestCase(SpellConstants.ContinualFlame, 2)]
        [TestCase(SpellConstants.Darkness, 2)]
        [TestCase(SpellConstants.FlamingSphere, 2)]
        [TestCase(SpellConstants.GustOfWind, 2)]
        [TestCase(SpellConstants.ScorchingRay, 2)]
        [TestCase(SpellConstants.Shatter, 2)]
        [TestCase(SpellConstants.Blur, 2)]
        [TestCase(SpellConstants.HypnoticPattern, 2)]
        [TestCase(SpellConstants.Invisibility, 2)]
        [TestCase(SpellConstants.MagicMouth, 2)]
        [TestCase(SpellConstants.MinorImage, 2)]
        [TestCase(SpellConstants.MirrorImage, 2)]
        [TestCase(SpellConstants.Misdirection, 2)]
        [TestCase(SpellConstants.LeomundsTrap, 2)]
        [TestCase(SpellConstants.BlindnessDeafness, 2)]
        [TestCase(SpellConstants.CommandUndead, 2)]
        [TestCase(SpellConstants.FalseLife, 2)]
        [TestCase(SpellConstants.GhoulTouch, 2)]
        [TestCase(SpellConstants.Scare, 2)]
        [TestCase(SpellConstants.SpectralHand, 2)]
        [TestCase(SpellConstants.AlterSelf, 2)]
        [TestCase(SpellConstants.BearsEndurance, 2)]
        [TestCase(SpellConstants.BullsStrength, 2)]
        [TestCase(SpellConstants.CatsGrace, 2)]
        [TestCase(SpellConstants.Darkvision, 2)]
        [TestCase(SpellConstants.EaglesSplendor, 2)]
        [TestCase(SpellConstants.FoxsCunning, 2)]
        [TestCase(SpellConstants.Knock, 2)]
        [TestCase(SpellConstants.Levitate, 2)]
        [TestCase(SpellConstants.OwlsWisdom, 2)]
        [TestCase(SpellConstants.Pyrotechnics, 2)]
        [TestCase(SpellConstants.RopeTrick, 2)]
        [TestCase(SpellConstants.SpiderClimb, 2)]
        [TestCase(SpellConstants.WhisperingWind, 2)]
        [TestCase(SpellConstants.DispelMagic, 3)]
        [TestCase(SpellConstants.ExplosiveRunes, 3)]
        [TestCase(SpellConstants.MagicCircleAgainstChaos, 3)]
        [TestCase(SpellConstants.MagicCircleAgainstEvil, 3)]
        [TestCase(SpellConstants.MagicCircleAgainstGood, 3)]
        [TestCase(SpellConstants.MagicCircleAgainstLaw, 3)]
        [TestCase(SpellConstants.Nondetection, 3)]
        [TestCase(SpellConstants.ProtectionFromEnergy, 3)]
        [TestCase(SpellConstants.PhantomSteed, 3)]
        [TestCase(SpellConstants.SepiaSnakeSigil, 3)]
        [TestCase(SpellConstants.SleetStorm, 3)]
        [TestCase(SpellConstants.StinkingCloud, 3)]
        [TestCase(SpellConstants.SummonMonsterIII, 3)]
        [TestCase(SpellConstants.ArcaneSight, 3)]
        [TestCase(SpellConstants.ClairaudienceClairvoyance, 3)]
        [TestCase(SpellConstants.Tongues, 3)]
        [TestCase(SpellConstants.DeepSlumber, 3)]
        [TestCase(SpellConstants.Heroism, 3)]
        [TestCase(SpellConstants.HoldPerson, 3)]
        [TestCase(SpellConstants.Rage, 3)]
        [TestCase(SpellConstants.Suggestion, 3)]
        [TestCase(SpellConstants.Daylight, 3)]
        [TestCase(SpellConstants.Fireball, 3)]
        [TestCase(SpellConstants.LightningBolt, 3)]
        [TestCase(SpellConstants.LeomundsTinyHut, 3)]
        [TestCase(SpellConstants.WindWall, 3)]
        [TestCase(SpellConstants.Displacement, 3)]
        [TestCase(SpellConstants.IllusoryScript, 3)]
        [TestCase(SpellConstants.InvisibilitySphere, 3)]
        [TestCase(SpellConstants.MajorImage, 3)]
        [TestCase(SpellConstants.GentleRepose, 3)]
        [TestCase(SpellConstants.HaltUndead, 3)]
        [TestCase(SpellConstants.RayOfExhaustion, 3)]
        [TestCase(SpellConstants.VampiricTouch, 3)]
        [TestCase(SpellConstants.Blink, 3)]
        [TestCase(SpellConstants.FlameArrow, 3)]
        [TestCase(SpellConstants.Fly, 3)]
        [TestCase(SpellConstants.GaseousForm, 3)]
        [TestCase(SpellConstants.Haste, 3)]
        [TestCase(SpellConstants.KeenEdge, 3)]
        [TestCase(SpellConstants.MagicWeapon_Greater, 3)]
        [TestCase(SpellConstants.SecretPage, 3)]
        [TestCase(SpellConstants.ShrinkItem, 3)]
        [TestCase(SpellConstants.Slow, 3)]
        [TestCase(SpellConstants.WaterBreathing, 3)]
        [TestCase(SpellConstants.DimensionalAnchor, 4)]
        [TestCase(SpellConstants.FireTrap, 4)]
        [TestCase(SpellConstants.GlobeOfInvulnerability_Lesser, 4)]
        [TestCase(SpellConstants.RemoveCurse, 4)]
        [TestCase(SpellConstants.Stoneskin, 4)]
        [TestCase(SpellConstants.EvardsBlackTentacles, 4)]
        [TestCase(SpellConstants.DimensionDoor, 4)]
        [TestCase(SpellConstants.MinorCreation, 4)]
        [TestCase(SpellConstants.LeomundsSecureShelter, 4)]
        [TestCase(SpellConstants.SolidFog, 4)]
        [TestCase(SpellConstants.SummonMonsterIV, 4)]
        [TestCase(SpellConstants.ArcaneEye, 4)]
        [TestCase(SpellConstants.DetectScrying, 4)]
        [TestCase(SpellConstants.LocateCreature, 4)]
        [TestCase(SpellConstants.Scrying, 4)]
        [TestCase(SpellConstants.CharmMonster, 4)]
        [TestCase(SpellConstants.Confusion, 4)]
        [TestCase(SpellConstants.CrushingDespair, 4)]
        [TestCase(SpellConstants.Geas_Lesser, 4)]
        [TestCase(SpellConstants.FireShield, 4)]
        [TestCase(SpellConstants.IceStorm, 4)]
        [TestCase(SpellConstants.OtilukesResilientSphere, 4)]
        [TestCase(SpellConstants.Shout, 4)]
        [TestCase(SpellConstants.WallOfFire, 4)]
        [TestCase(SpellConstants.WallOfIce, 4)]
        [TestCase(SpellConstants.HallucinatoryTerrain, 4)]
        [TestCase(SpellConstants.IllusoryWall, 4)]
        [TestCase(SpellConstants.Invisibility_Greater, 4)]
        [TestCase(SpellConstants.PhantasmalKiller, 4)]
        [TestCase(SpellConstants.RainbowPattern, 4)]
        [TestCase(SpellConstants.ShadowConjuration, 4)]
        [TestCase(SpellConstants.AnimateDead, 4)]
        [TestCase(SpellConstants.BestowCurse, 4)]
        [TestCase(SpellConstants.Contagion, 4)]
        [TestCase(SpellConstants.Enervation, 4)]
        [TestCase(SpellConstants.Fear, 4)]
        [TestCase(SpellConstants.EnlargePerson_Mass, 4)]
        [TestCase(SpellConstants.Polymorph, 4)]
        [TestCase(SpellConstants.ReducePerson_Mass, 4)]
        [TestCase(SpellConstants.StoneShape, 4)]
        [TestCase(SpellConstants.BreakEnchantment, 5)]
        [TestCase(SpellConstants.Dismissal, 5)]
        [TestCase(SpellConstants.MordenkainensPrivateSanctum, 5)]
        [TestCase(SpellConstants.Cloudkill, 5)]
        [TestCase(SpellConstants.MordenkainensFaithfulHound, 5)]
        [TestCase(SpellConstants.MajorCreation, 5)]
        [TestCase(SpellConstants.PlanarBinding_Lesser, 5)]
        [TestCase(SpellConstants.LeomundsSecretChest, 5)]
        [TestCase(SpellConstants.SummonMonsterV, 5)]
        [TestCase(SpellConstants.Teleport, 5)]
        [TestCase(SpellConstants.WallOfStone, 5)]
        [TestCase(SpellConstants.ContactOtherPlane, 5)]
        [TestCase(SpellConstants.PryingEyes, 5)]
        [TestCase(SpellConstants.RarysTelepathicBond, 5)]
        [TestCase(SpellConstants.DominatePerson, 5)]
        [TestCase(SpellConstants.Feeblemind, 5)]
        [TestCase(SpellConstants.HoldMonster, 5)]
        [TestCase(SpellConstants.MindFog, 5)]
        [TestCase(SpellConstants.SymbolOfSleep, 5)]
        [TestCase(SpellConstants.ConeOfCold, 5)]
        [TestCase(SpellConstants.BigbysInterposingHand, 5)]
        [TestCase(SpellConstants.Sending, 5)]
        [TestCase(SpellConstants.WallOfForce, 5)]
        [TestCase(SpellConstants.Dream, 5)]
        [TestCase(SpellConstants.FalseVision, 5)]
        [TestCase(SpellConstants.MirageArcana, 5)]
        [TestCase(SpellConstants.Nightmare, 5)]
        [TestCase(SpellConstants.PersistentImage, 5)]
        [TestCase(SpellConstants.Seeming, 5)]
        [TestCase(SpellConstants.ShadowEvocation, 5)]
        [TestCase(SpellConstants.Blight, 5)]
        [TestCase(SpellConstants.MagicJar, 5)]
        [TestCase(SpellConstants.SymbolOfPain, 5)]
        [TestCase(SpellConstants.WavesOfFatigue, 5)]
        [TestCase(SpellConstants.AnimalGrowth, 5)]
        [TestCase(SpellConstants.Fabricate, 5)]
        [TestCase(SpellConstants.OverlandFlight, 5)]
        [TestCase(SpellConstants.Passwall, 5)]
        [TestCase(SpellConstants.Telekinesis, 5)]
        [TestCase(SpellConstants.TransmuteMudToRock, 5)]
        [TestCase(SpellConstants.TransmuteRockToMud, 5)]
        [TestCase(SpellConstants.Permanency, 5)]
        [TestCase(SpellConstants.AntimagicField, 6)]
        [TestCase(SpellConstants.DispelMagic_Greater, 6)]
        [TestCase(SpellConstants.GlobeOfInvulnerability, 6)]
        [TestCase(SpellConstants.GuardsAndWards, 6)]
        [TestCase(SpellConstants.Repulsion, 6)]
        [TestCase(SpellConstants.AcidFog, 6)]
        [TestCase(SpellConstants.PlanarBinding, 6)]
        [TestCase(SpellConstants.SummonMonsterVI, 6)]
        [TestCase(SpellConstants.WallOfIron, 6)]
        [TestCase(SpellConstants.AnalyzeDweomer, 6)]
        [TestCase(SpellConstants.LegendLore, 6)]
        [TestCase(SpellConstants.TrueSeeing, 6)]
        [TestCase(SpellConstants.GeasQuest, 6)]
        [TestCase(SpellConstants.Heroism_Greater, 6)]
        [TestCase(SpellConstants.Suggestion_Mass, 6)]
        [TestCase(SpellConstants.SymbolOfPersuasion, 6)]
        [TestCase(SpellConstants.ChainLightning, 6)]
        [TestCase(SpellConstants.Contingency, 6)]
        [TestCase(SpellConstants.BigbysForcefulHand, 6)]
        [TestCase(SpellConstants.OtilukesFreezingSphere, 6)]
        [TestCase(SpellConstants.Mislead, 6)]
        [TestCase(SpellConstants.PermanentImage, 6)]
        [TestCase(SpellConstants.ProgrammedImage, 6)]
        [TestCase(SpellConstants.ShadowWalk, 6)]
        [TestCase(SpellConstants.Veil, 6)]
        [TestCase(SpellConstants.CircleOfDeath, 6)]
        [TestCase(SpellConstants.CreateUndead, 6)]
        [TestCase(SpellConstants.Eyebite, 6)]
        [TestCase(SpellConstants.SymbolOfFear, 6)]
        [TestCase(SpellConstants.UndeathToDeath, 6)]
        [TestCase(SpellConstants.BearsEndurance_Mass, 6)]
        [TestCase(SpellConstants.BullsStrength_Mass, 6)]
        [TestCase(SpellConstants.CatsGrace_Mass, 6)]
        [TestCase(SpellConstants.ControlWater, 6)]
        [TestCase(SpellConstants.Disintegrate, 6)]
        [TestCase(SpellConstants.EaglesSplendor_Mass, 6)]
        [TestCase(SpellConstants.FleshToStone, 6)]
        [TestCase(SpellConstants.FoxsCunning_Mass, 6)]
        [TestCase(SpellConstants.MoveEarth, 6)]
        [TestCase(SpellConstants.OwlsWisdom_Mass, 6)]
        [TestCase(SpellConstants.StoneToFlesh, 6)]
        [TestCase(SpellConstants.TensersTransformation, 6)]
        [TestCase(SpellConstants.Banishment, 7)]
        [TestCase(SpellConstants.Sequester, 7)]
        [TestCase(SpellConstants.SpellTurning, 7)]
        [TestCase(SpellConstants.DrawmijsInstantSummons, 7)]
        [TestCase(SpellConstants.MordenkainensMagnificentMansion, 7)]
        [TestCase(SpellConstants.PhaseDoor, 7)]
        [TestCase(SpellConstants.PlaneShift, 7)]
        [TestCase(SpellConstants.SummonMonsterVII, 7)]
        [TestCase(SpellConstants.Teleport_Greater, 7)]
        [TestCase(SpellConstants.TeleportObject, 7)]
        [TestCase(SpellConstants.ArcaneSight_Greater, 7)]
        [TestCase(SpellConstants.Scrying_Greater, 7)]
        [TestCase(SpellConstants.Vision, 7)]
        [TestCase(SpellConstants.HoldPerson_Mass, 7)]
        [TestCase(SpellConstants.Insanity, 7)]
        [TestCase(SpellConstants.PowerWordBlind, 7)]
        [TestCase(SpellConstants.SymbolOfStunning, 7)]
        [TestCase(SpellConstants.DelayedBlastFireball, 7)]
        [TestCase(SpellConstants.Forcecage, 7)]
        [TestCase(SpellConstants.BigbysGraspingHand, 7)]
        [TestCase(SpellConstants.MordenkainensSword, 7)]
        [TestCase(SpellConstants.PrismaticSpray, 7)]
        [TestCase(SpellConstants.Invisibility_Mass, 7)]
        [TestCase(SpellConstants.ProjectImage, 7)]
        [TestCase(SpellConstants.ShadowConjuration_Greater, 7)]
        [TestCase(SpellConstants.Simulacrum, 7)]
        [TestCase(SpellConstants.ControlUndead, 7)]
        [TestCase(SpellConstants.FingerOfDeath, 7)]
        [TestCase(SpellConstants.SymbolOfWeakness, 7)]
        [TestCase(SpellConstants.WavesOfExhaustion, 7)]
        [TestCase(SpellConstants.ControlWeather, 7)]
        [TestCase(SpellConstants.EtherealJaunt, 7)]
        [TestCase(SpellConstants.ReverseGravity, 7)]
        [TestCase(SpellConstants.Statue, 7)]
        [TestCase(SpellConstants.LimitedWish, 7)]
        [TestCase(SpellConstants.DimensionalLock, 8)]
        [TestCase(SpellConstants.MindBlank, 8)]
        [TestCase(SpellConstants.PrismaticWall, 8)]
        [TestCase(SpellConstants.ProtectionFromSpells, 8)]
        [TestCase(SpellConstants.IncendiaryCloud, 8)]
        [TestCase(SpellConstants.Maze, 8)]
        [TestCase(SpellConstants.PlanarBinding_Greater, 8)]
        [TestCase(SpellConstants.SummonMonsterVIII, 8)]
        [TestCase(SpellConstants.TrapTheSoul, 8)]
        [TestCase(SpellConstants.DiscernLocation, 8)]
        [TestCase(SpellConstants.MomentOfPrescience, 8)]
        [TestCase(SpellConstants.PryingEyes_Greater, 8)]
        [TestCase(SpellConstants.Antipathy, 8)]
        [TestCase(SpellConstants.Binding, 8)]
        [TestCase(SpellConstants.CharmMonster_Mass, 8)]
        [TestCase(SpellConstants.Demand, 8)]
        [TestCase(SpellConstants.OttosIrresistibleDance, 8)]
        [TestCase(SpellConstants.PowerWordStun, 8)]
        [TestCase(SpellConstants.SymbolOfInsanity, 8)]
        [TestCase(SpellConstants.Sympathy, 8)]
        [TestCase(SpellConstants.BigbysClenchedFist, 8)]
        [TestCase(SpellConstants.PolarRay, 8)]
        [TestCase(SpellConstants.Shout_Greater, 8)]
        [TestCase(SpellConstants.Sunburst, 8)]
        [TestCase(SpellConstants.OtilukesTelekineticSphere, 8)]
        [TestCase(SpellConstants.ScintillatingPattern, 8)]
        [TestCase(SpellConstants.Screen, 8)]
        [TestCase(SpellConstants.ShadowEvocation_Greater, 8)]
        [TestCase(SpellConstants.Clone, 8)]
        [TestCase(SpellConstants.CreateGreaterUndead, 8)]
        [TestCase(SpellConstants.HorridWilting, 8)]
        [TestCase(SpellConstants.SymbolOfDeath, 8)]
        [TestCase(SpellConstants.IronBody, 8)]
        [TestCase(SpellConstants.PolymorphAnyObject, 8)]
        [TestCase(SpellConstants.TemporalStasis, 8)]
        [TestCase(SpellConstants.Freedom, 9)]
        [TestCase(SpellConstants.Imprisonment, 9)]
        [TestCase(SpellConstants.MordenkainensDisjunction, 9)]
        [TestCase(SpellConstants.PrismaticSphere, 9)]
        [TestCase(SpellConstants.Gate, 9)]
        [TestCase(SpellConstants.Refuge, 9)]
        [TestCase(SpellConstants.SummonMonsterIX, 9)]
        [TestCase(SpellConstants.TeleportationCircle, 9)]
        [TestCase(SpellConstants.Foresight, 9)]
        [TestCase(SpellConstants.DominateMonster, 9)]
        [TestCase(SpellConstants.HoldMonster_Mass, 9)]
        [TestCase(SpellConstants.PowerWordKill, 9)]
        [TestCase(SpellConstants.BigbysCrushingHand, 9)]
        [TestCase(SpellConstants.MeteorSwarm, 9)]
        [TestCase(SpellConstants.Shades, 9)]
        [TestCase(SpellConstants.Weird, 9)]
        [TestCase(SpellConstants.AstralProjection, 9)]
        [TestCase(SpellConstants.EnergyDrain, 9)]
        [TestCase(SpellConstants.SoulBind, 9)]
        [TestCase(SpellConstants.WailOfTheBanshee, 9)]
        [TestCase(SpellConstants.Etherealness, 9)]
        [TestCase(SpellConstants.Shapechange, 9)]
        [TestCase(SpellConstants.TimeStop, 9)]
        [TestCase(SpellConstants.Wish, 9)]
        public void SorcererSpellLevel(string spell, int level)
        {
            base.Adjustment(spell, level);
        }
    }
}
