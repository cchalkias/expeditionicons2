using System.Collections.Generic;
using System.Linq;
using ExileCore.Shared.Enums;

namespace ExpeditionIcons;

public static class Icons
{
    public static IExpeditionRelic GetRelicType(string relicMod, PlannerSettings plannerSettings)
    {
        var relicDescription = ExpeditionRelicIcons.FirstOrDefault(x => x.BaseEntityMetadataSubstrings.Contains(relicMod));
        return (relicMod, relicDescription) switch
        {
            ("ExpeditionRelicModifierElitesDuplicated", _) => new DoubledMonstersRelic(),
            (_, { IsWeightCustomizable: true, IconPickerIndex: var index }) when
                (plannerSettings.RelicSettingsMap.GetValueOrDefault(index) ?? RelicSettings.Default) is var setting =>
                new ConfigurableRelic(setting.Multiplier, setting.Increase,
                    relicMod.Contains("Monster") || relicMod.Contains("Elite") || relicMod.Contains("PackSize")),
            _ when relicMod.Contains("Monster") => new ConfigurableRelic(plannerSettings.DefaultRelicSettings.Multiplier, plannerSettings.DefaultRelicSettings.Increase, true),
            _ when relicMod.Contains("Chest") => new ConfigurableRelic(plannerSettings.DefaultRelicSettings.Multiplier, plannerSettings.DefaultRelicSettings.Increase, false),
            _ => null,
        };
    }

    public static readonly List<ExpeditionMarkerIconDescription> ExpeditionRelicIcons = new()
    {
        new()
        {
            IconPickerIndex = IconPickerIndex.CorruptedItems,
            DefaultIcon = MapIconsIndex.QuestObject,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionCorruptedItemsElite",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.FullyLinked,
            DefaultIcon = MapIconsIndex.QuestObject,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionFullyLinkedElite__",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Experience,
            DefaultIcon = MapIconsIndex.QuestObject,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExperience_",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Rarity,
            DefaultIcon = MapIconsIndex.RewardUniques,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierItemRarityMonster____",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Legion,
            DefaultIcon = MapIconsIndex.LegionGeneric,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierLegionSplintersElite",
                "ExpeditionRelicModifierEternalEmpireLegionElite",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Uniques,
            DefaultIcon = MapIconsIndex.RewardUniques,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionUniqueElite",
                "ExpeditionRelicModifierLostMenUniqueElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Essences,
            DefaultIcon = MapIconsIndex.RewardEssences,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierEssencesElite",
                "ExpeditionRelicModifierLostMenEssenceElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.VaalGems,
            DefaultIcon = MapIconsIndex.RewardGems,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierVaalGemsElite",
                "ExpeditionRelicModifierExpeditionGemsElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Logbooks,
            DefaultIcon = MapIconsIndex.QuestItem,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionLogbookQuantityMonster",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Jewellery,
            DefaultIcon = MapIconsIndex.RewardJewellery,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionRareTrinketElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Enchants,
            DefaultIcon = MapIconsIndex.LabyrinthEnchant,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierEternalEmpireEnchantElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Scarabs,
            DefaultIcon = MapIconsIndex.RewardScarabs,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierSirensScarabElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Breach,
            DefaultIcon = MapIconsIndex.RewardBreach,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierBreachSplintersElite",
                "ExpeditionRelicModifierSirensBreachElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Influenced,
            DefaultIcon = MapIconsIndex.LootFilterLargeYellowCross,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionInfluencedItemsElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Maps,
            DefaultIcon = MapIconsIndex.RewardMaps,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionMapsElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Fractured,
            DefaultIcon = MapIconsIndex.LootFilterLargeBlueDiamond,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionFracturedItemsElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Harbinger,
            DefaultIcon = MapIconsIndex.RewardHarbinger,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierHarbingerCurrencyElite",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Weapon,
            DefaultIcon = MapIconsIndex.RewardWeapons,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionRareWeaponElite",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Armour,
            DefaultIcon = MapIconsIndex.RewardArmour,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionRareArmourElite_",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.PackSize,
            DefaultIcon = MapIconsIndex.LootFilterLargeGreenTriangle,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierPackSize",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.MonsterMods,
            DefaultIcon = MapIconsIndex.LootFilterLargeGreenTriangle,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierRareMonsterChance",
                "ExpeditionRelicModifierMagicMonsterChance",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.RunicMonsterDuplication,
            DefaultIcon = MapIconsIndex.IncursionArchitectReplace,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierElitesDuplicated",
            },
            IsWeightCustomizable = false,
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Artifacts,
            DefaultIcon = MapIconsIndex.LootFilterLargePurpleSquare,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionCurrencyQuantityMonster",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Rerolls,
            DefaultIcon = MapIconsIndex.LootFilterLargePurpleCircle,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionVendorCurrency",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.Quantity,
            DefaultIcon = MapIconsIndex.RewardGenericItems,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierItemQuantityMonster",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.Currency,
            DefaultIcon = MapIconsIndex.RewardCurrency,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionBasicCurrencyElite",
            },
        },

        new()
        {
            IconPickerIndex = IconPickerIndex.StackedDecks,
            DefaultIcon = MapIconsIndex.RewardDivinationCards,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierStackedDeckElite",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.RarityExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardUniques,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierItemRarityChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.LegionExcavatedChest,
            DefaultIcon = MapIconsIndex.LegionGeneric,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierLegionSplintersChest",
                "ExpeditionRelicModifierEternalEmpireLegionChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.UniquesExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardUniques,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionUniqueChest",
                "ExpeditionRelicModifierLostMenUniqueChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.EssencesExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardEssences,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierLostMenEssenceChest",
                "ExpeditionRelicModifierEssencesChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.VaalGemsExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardGems,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierVaalGemsChest",
                "ExpeditionRelicModifierExpeditionGemsChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.LogbooksExcavatedChest,
            DefaultIcon = MapIconsIndex.QuestItem,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionLogbookQuantityChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.JewelleryExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardJewellery,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionRareTrinketChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.EnchantsExcavatedChest,
            DefaultIcon = MapIconsIndex.LabyrinthEnchant,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierEternalEmpireEnchantChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.ScarabsExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardScarabs,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierSirensScarabChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.BreachExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardBreach,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierBreachSplintersChest",
                "ExpeditionRelicModifierSirensBreachChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.InfluencedExcavatedChest,
            DefaultIcon = MapIconsIndex.LootFilterLargeYellowCross,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionInfluencedItemsChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.MapsExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardMaps,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionMapsChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.FracturedExcavatedChest,
            DefaultIcon = MapIconsIndex.LootFilterLargeBlueDiamond,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionFracturedItemsChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.HarbingerExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardHarbinger,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierHarbingerCurrencyChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.ArtifactsExcavatedChest,
            DefaultIcon = MapIconsIndex.LootFilterLargePurpleSquare,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionCurrencyQuantityChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.QuantityExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardGenericItems,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierItemQuantityChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.CurrencyExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardCurrency,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionBasicCurrencyChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.StackedDecksExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardDivinationCards,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierStackedDeckChest",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.WeaponExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardWeapons,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionRareWeaponChest__",
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.ArmourExcavatedChest,
            DefaultIcon = MapIconsIndex.RewardArmour,
            BaseEntityMetadataSubstrings =
            {
                "ExpeditionRelicModifierExpeditionRareArmourChest_",
            },
        },
    };

    public static readonly List<ExpeditionMarkerIconDescription> LogbookChestIcons = new()
    {
        new()
        {
            IconPickerIndex = IconPickerIndex.BlightChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestBlight.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.FragmentChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestFragments.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.LeagueChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestLeague.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.JewelleryChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestTrinkets.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.WeaponChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestWeapon.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.CurrencyChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestCurrency.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.HeistChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestHeist.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.BreachChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestBreach.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.RitualChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestRitual.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.MetamorphChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestMetamorph.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.MapsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestMaps.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.GemsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestGems.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.FossilsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestFossils.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.DivinationCardsChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestDivinationCards.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.EssenceChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestEssence.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.ArmourChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestArmour.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.LegionChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestLegion.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.DeliriumChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestDelirium.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.UniquesChest,
            DefaultIcon = ExpeditionIconsSettings.DefaultChestIcon,
            BaseEntityMetadataSubstrings =
            {
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers/ChestUniques.ao"
            },
        },
        new()
        {
            IconPickerIndex = IconPickerIndex.OtherChests,
            DefaultIcon = MapIconsIndex.MissionAlly,
            BaseEntityMetadataSubstrings =
            {
                "chestmarker1",
                "chestmarker2",
                "chestmarker3",
                "chestmarker_signpost",
                "Metadata/Terrain/Doodads/Leagues/Expedition/ChestMarkers"
            },
        },
    };
}