using System.Collections.Generic;

namespace Wondertools
{
    internal static class StaticData
    {
        public static readonly Dictionary<string, string> BgmTypes = new()
        {
            ["Silent"] = "Silent",
            ["None"] = "None",
            ["Course14"] = "Overworld",
            ["Course06"] = "Shining Falls Overworld",
            ["Course05"] = "Poisonous Swamp / Ghost House",
            ["Course21"] = "Fungi Mines Overworld",
            ["Course18"] = "Castle Bowser Overworld",
            ["Course02"] = "Underground",
            ["Course03"] = "Underwater",
            ["Course01"] = "Savanna",
            ["Course04"] = "Athletic",
            ["Course12"] = "Forest",
            ["Course08"] = "Beach",
            ["Course09"] = "Palace",
            ["Course15"] = "Lava",
            ["Course16"] = "Desert",
            ["Course20"] = "Snow",
            ["Course19"] = "Airship",
            ["Course40"] = "Poplin House",
            ["Course11"] = "Search Party",
            ["Course13"] = "Break Time!",
            ["Course17"] = "Ninji Jump Party",
            ["Course46"] = "Trottin' Piranha Plants (SMB3 Hammer Bros.)",
            ["Course41"] = "Wonder Token Tunes (SMW Bonus Game)",
            ["Course43"] = "Coins Galore (SM64 Slider)",
            ["Course42"] = "Bouncy Tunes (SMS Delfino Plaza)",
            ["Course48"] = "Raise the Stage (SMS Secret Course)",
            ["Course44"] = "Wiggler Race",
            ["Course45"] = "Badge Challenge",
            ["Course47"] = "KO Arena",
            ["Demo01"] = "Prologue 1",
            ["Demo02"] = "Prologue 2",
            ["Demo03"] = "Prologue 3",
            ["Demo04"] = "Demo04",
            ["Demo05"] = "Demo05",
            ["Demo06"] = "Demo06",
            ["Demo07"] = "Demo07",
            ["MusicTest_MarioTheme"] = "MusicTest_MarioTheme",
            ["Wonder01"] = "Wonder01",
            ["Wonder02"] = "Wonder02",
            ["Wonder04"] = "Wonder04",
            ["Wonder05"] = "Wonder05",
            ["Wonder06"] = "Wonder06",
            ["Wonder07"] = "Wonder07",
            ["Wonder08"] = "Wonder08",
            ["Wonder09"] = "Wonder09",
            ["Wonder10"] = "Wonder10",
            ["Wonder11"] = "Wonder11",
            ["Wonder12"] = "Wonder12",
            ["Wonder14"] = "Wonder14",
            ["Wonder15"] = "Wonder15",
            ["Wonder16"] = "Wonder16",
            ["Wonder17"] = "Wonder17",
            ["Wonder18"] = "Wonder18",
            ["Wonder20"] = "Wonder20",
            ["Wonder21"] = "Wonder21",
            ["Wonder22"] = "Wonder22",
            ["Wonder23"] = "Wonder23",
            ["Wonder24"] = "Wonder24",
            ["Wonder25"] = "Wonder25",
            ["Wonder26"] = "Wonder26",
            ["World01"] = "Pipe-Rock Plateau",
            ["World02"] = "Petal Isles",
            ["World03"] = "Fluff-Puff Peaks",
            ["World04"] = "Shining Falls",
            ["World05"] = "Sunbaked Desert",
            ["World06"] = "Fungi Mines",
            ["World07"] = "Deep Magma Bog",
            ["World08"] = "Castle Bowser",
            ["World09"] = "Special World"
        };

        public static readonly Dictionary<string, string> BgmStrings = new()
        {
            [""] = "",
            ["Enter"] = "Enter",
            ["Treasure"] = "Treasure",
            ["Outside"] = "Outside",
            ["NotFactory"] = "NotFactory",
            ["Mokumoku"] = "Mokumoku",
            ["Hideri"] = "Hideri",
            ["Magma"] = "Magma",
            ["Dokan"] = "Dokan",
            ["Boss_Dokan"] = "Boss_Dokan",
            ["Battle_01"] = "Battle_01",
            ["Battle_02"] = "Battle_02",
            ["Battle_03"] = "Battle_03",
            ["Battle_04"] = "Battle_04",
        };

        public static Dictionary<string, string> BadgeIDs = new()
        {
            ["Invalid"] = "Invalid",
            ["BadgeId00"] = "BadgeId00",
            ["BadgeId04"] = "BadgeId04",
            ["BadgeId14"] = "BadgeId14",
            ["BadgeId19"] = "BadgeId19",
            ["BadgeId29"] = "BadgeId29",
            ["BadgeId34"] = "BadgeId34",
            ["BadgeId35"] = "BadgeId35",
            ["BadgeId38"] = "BadgeId38",
            ["BadgeId39"] = "BadgeId39",
            ["BadgeId53"] = "BadgeId53"
        };

        public static Dictionary<string, string> DynamicResolutionQuality = new()
        {
            ["None"] = "None",
            ["VeryLow"] = "Very Low",
            ["Low"] = "Low",
            ["High"] = "High"
        };

        public static Dictionary<string, string> EnvironmentSets = new()
        {
            ["Default"] = "Default",
            ["WorldMap"] = "World Map"
        };

        public static Dictionary<string, string> EnvironmentSounds = new()
        {
            ["None"] = "None",
            ["NoSetting"] = "NoSetting",
            ["Boss01_Room"] = "Boss01_Room",
            ["Cource_Cloudy"] = "Cource_Cloudy",
            ["Cource_HighPlaceWind"] = "Cource_HighPlaceWind",
            ["Cource_PalaceOutdoorHotArea"] = "Cource_PalaceOutdoorHotArea",
            ["Cource_PalaceRoom"] = "Cource_PalaceRoom",
            ["Cource_Yama_Wind"] = "Cource_Yama_Wind",
            ["Course_AirshipBoss"] = "Course_AirshipBoss",
            ["Course_AirshipInRoom"] = "Course_AirshipInRoom",
            ["Course_AirshipInRoomSwing"] = "Course_AirshipInRoomSwing",
            ["Course_AirshipWind"] = "Course_AirshipWind",
            ["Course_BaobabForest"] = "Course_BaobabForest",
            ["Course_BaseWind"] = "Course_BaseWind",
            ["Course_DokanMoriMori"] = "Course_DokanMoriMori",
            ["Course_EndingA"] = "Course_EndingA",
            ["Course_FarCoast"] = "Course_FarCoast",
            ["Course_Forest"] = "Course_Forest",
            ["Course_Gel"] = "Course_Gel",
            ["Course_GhostHouse"] = "Course_GhostHouse",
            ["Course_GhostHouseOutDoor"] = "Course_GhostHouseOutDoor",
            ["Course_Glassland_Demo"] = "Course_Glassland_Demo",
            ["Course_Grassland"] = "Course_Grassland",
            ["Course_GrasslandFirst"] = "Course_GrasslandFirst",
            ["Course_HotArea"] = "Course_HotArea",
            ["Course_HotAreaSilhouette"] = "Course_HotAreaSilhouette",
            ["Course_LastStage"] = "Course_LastStage",
            ["Course_LavaGreenRise"] = "Course_LavaGreenRise",
            ["Course_LavaRedRise"] = "Course_LavaRedRise",
            ["Course_MiniCourseCoin"] = "Course_MiniCourseCoin",
            ["Course_OrientalLake_01"] = "Course_OrientalLake_01",
            ["Course_OrientalLake_04"] = "Course_OrientalLake_04",
            ["Course_PalaceOutdoor"] = "Course_PalaceOutdoor",
            ["Course_PoisonousSwampHorror"] = "Course_PoisonousSwampHorror",
            ["Course_PoisonousSwampPurpleRise"] = "Course_PoisonousSwampPurpleRise",
            ["Course_Rain"] = "Course_Rain",
            ["Course_SavannaDay"] = "Course_SavannaDay",
            ["Course_SmallRoom"] = "Course_SmallRoom",
            ["Course_TwilightForest"] = "Course_TwilightForest",
            ["Course_Underground"] = "Course_Underground",
            ["Course_UndergroundDark"] = "Course_UndergroundDark",
            ["Course_UnderWater"] = "Course_UnderWater",
            ["Course_WhiteSandWind"] = "Course_WhiteSandWind",
            ["Course_WhiteSandWindInRoom"] = "Course_WhiteSandWindInRoom",
            ["Course_WhiteSandWindSilhouette"] = "Course_WhiteSandWindSilhouette",
            ["Course_Yama_Snow"] = "Course_Yama_Snow",
            ["Wonder_DokanMoriMori"] = "Wonder_DokanMoriMori",
            ["Wonder_Fast"] = "Wonder_Fast",
            ["Wonder_LavaRise"] = "Wonder_LavaRise",
            ["Wonder_PoisonousSwampPurpleRise"] = "Wonder_PoisonousSwampPurpleRise",
            ["Wonder_Rain"] = "Wonder_Rain",
            ["Wonder_Skydiving"] = "Wonder_Skydiving",
            ["Wonder_Slow"] = "Wonder_Slow",
            ["Wonder_Star"] = "Wonder_Star",
            ["Wonder_Tornado"] = "Wonder_Tornado",
            ["Wonder_Tosshin"] = "Wonder_Tosshin",
            ["Wonder_TwilightForest"] = "Wonder_TwilightForest"
        };

        public static Dictionary<string, string> WonderEnvironmentSounds = new()
        {
            ["NotChangeAtWonder"] = "NotChangeAtWonder",
            ["StopAllEnvironmentAtWonder"] = "StopAllEnvironmentAtWonder",
            // appends EnvironmentSounds dict at runtime
        };

        public static Dictionary<string, string> EnvironmentSoundEffects = new()
        {
            ["None"] = "None",
            ["CourseEnv_Biyon"] = "CourseEnv_Biyon",
            ["CourseEnv_Biyon_Palace"] = "CourseEnv_Biyon_Palace",
            ["CourseEnv_Cave"] = "CourseEnv_Cave",
            ["CourseEnv_Forest"] = "CourseEnv_Forest",
            ["CourseEnv_House"] = "CourseEnv_House",
            ["CourseEnv_Indoor"] = "CourseEnv_Indoor",
            ["CourseEnv_LastCourse"] = "CourseEnv_LastCourse",
            ["CourseEnv_Lava"] = "CourseEnv_Lava",
            ["CourseEnv_Mountain1"] = "CourseEnv_Mountain1",
            ["CourseEnv_Plain"] = "CourseEnv_Plain",
            ["CourseEnv_Sky"] = "CourseEnv_Sky",
            ["CourseEnv_Snow"] = "CourseEnv_Snow",
            ["CourseEnv_Underground"] = "CourseEnv_Underground",
            ["CourseEnv_Water"] = "CourseEnv_Water",
            ["CourseEnv_Waterside"] = "CourseEnv_Waterside",
            ["WorldMap_Default"] = "WorldMap_Default",
            ["WorldMap_World1"] = "WorldMap_World1",
            ["WorldMap_World5"] = "WorldMap_World5",
            ["WorldMap_World6"] = "WorldMap_World6",
            ["WorldMap_World8"] = "WorldMap_World8",
            ["Wonder_Default"] = "Wonder_Default",
            ["Wonder_Default_S"] = "Wonder_Default_S",
            ["Wonder_DokanMorimori"] = "Wonder_DokanMorimori",
            ["Wonder_Otoneta"] = "Wonder_Otoneta",
            ["Wonder_OverLooking"] = "Wonder_OverLooking",
            ["Wonder_PurupuruMario"] = "Wonder_PurupuruMario",
            ["Wonder_Space"] = "Wonder_Space"
        };

        public static Dictionary<string, string> RhythmJumpBadgeTiming = new()
        {
            ["None"] = "None",
            ["Default"] = "Default",
            ["RhythmJumpBadge"] = "RhythmJumpBadge",
            ["RhythmJumpBadgeForDokanMoriMori"] = "RhythmJumpBadgeForDokanMoriMori",
            ["RhythmJumpBadgeForThree"] = "RhythmJumpBadgeForThree",
        };

        public static Dictionary<string, string> RhythmJumpTiming = new()
        {
            ["None"] = "None",
            ["2-4Beat"] = "2-4Beat",
            ["FourBeatRhythmJump"] = "FourBeatRhythmJump",
            ["MusicKinopioHouse"] = "MusicKinopioHouse",
            ["AnInterludeFromGabon"] = "AnInterludeFromGabon",
            ["AnInterludeFromKillerZone"] = "AnInterludeFromKillerZone",
            ["AnInterludeFromKinoko"] = "AnInterludeFromKinoko",
            ["AnInterludeStaffCredit"] = "AnInterludeStaffCredit"
        };

        public static Dictionary<string, string> WonderBgmEffects = new()
        {
            ["None"] = "None",
            ["Wonder_SpeedChange"] = "Wonder_SpeedChange"
        };

        public static Dictionary<string, string> WonderSEKeyForTag = new()
        {
            [""] = "",
            ["se_wonder_hole_open_fast_notbgm"] = "se_wonder_hole_open_fast_notbgm",
            ["se_wonder_hole_open_longkiller"] = "se_wonder_hole_open_longkiller",
            ["se_wonder_hole_open_slow_notbgm"] = "se_wonder_hole_open_slow_notbgm",
            ["wonder_effect_000"] = "wonder_effect_000"
        };

        public static Dictionary<string, string> SkinParamFields = new()
        {
            ["Undefined"] = "Undefined",
            ["CastleFactory"] = "CastleFactory",
            ["CastleSiro"] = "CastleSiro",
            ["CommonSenkan"] = "CommonSenkan",
            ["CommonSora"] = "CommonSora",
            ["CommonSuityuAsase"] = "CommonSuityuAsase",
            ["CommonToride"] = "CommonToride",
            ["CommonTorideB"] = "CommonTorideB",
            ["CommonYashiki"] = "CommonYashiki",
            ["HajimariChika"] = "HajimariChika",
            ["HajimariKaigan"] = "HajimariKaigan",
            ["HajimariMori"] = "HajimariMori",
            ["HajimariSougen"] = "HajimariSougen",
            ["KinMori"] = "KinMori",
            ["KinMoriAkarui"] = "KinMoriAkarui",
            ["KinSlime"] = "KinSlime",
            ["MiniCourseA"] = "MiniCourseA",
            ["MushiChika"] = "MushiChika",
            ["MushiMachi"] = "MushiMachi",
            ["NettaiResort"] = "NettaiResort",
            ["NettaiResortDark"] = "NettaiResortDark",
            ["NettaiYogan"] = "NettaiYogan",
            ["SabakuChijou"] = "SabakuChijou",
            ["SabakuChika"] = "SabakuChika",
            ["SabakuIseki"] = "SabakuIseki",
            ["Savanna"] = "Savanna",
            ["SavannaChitei"] = "SavannaChitei",
            ["SavannaSabaku"] = "SavannaSabaku",
            ["WaKaigan"] = "WaKaigan",
            ["YamaDokutu"] = "YamaDokutu",
            ["YamaJyoku"] = "YamaJyoku",
            ["YamaTijyo"] = "YamaTijyo"
        };
    }
}
