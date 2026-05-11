using Avalonia.Controls;
using BymlLibrary;
using SharpYaml;
using System.Collections.Generic;
using System.IO;

namespace Wondertools.FileTypes
{
    internal class AreaParamFileType : BgymlFileType
    {
        public override string FileName => "Area Param";
        public override string FileExtension => "game__stage__AreaParam.bgyml";

        public override void CreateUI(Panel parentUI)
        {
            stackPanel.Children.Add(UIHeader("Text"));
            stackPanel.Children.Add(new Separator());

            SetupComboBoxDict("Background Music String", "BgmString", "", StaticData.BgmStrings);
            SetupComboBoxDict("Background Music Type", "BgmType", "None", StaticData.BgmTypes);

            stackPanel.Children.Add(new Separator());

            SetupComboBoxDict("Wonder Music Type", "WonderBgmType", "None", StaticData.BgmTypes);
            SetupComboBoxDict("Wonder Music Effects", "WonderBgmEfx", "None", StaticData.WonderBgmEffects);
            SetupDecimalBox("Wonder Music Start Offset", "WonderBgmStartOffset", 0);
            
            stackPanel.Children.Add(new Separator());

            SetupComboBoxDict("Environment Set", "EnvSetName", "Default", StaticData.EnvironmentSets);
            SetupComboBoxDict("Environment Sounds", "EnvironmentSound", "None", StaticData.EnvironmentSounds);
            SetupComboBoxDict("Environment SFX", "EnvironmentSoundEfx", "None", StaticData.EnvironmentSoundEffects);
            SetupComboBoxDict("Wonder Environment Sounds", "WonderEnvironmentSound", "NotChangeAtWonder", StaticData.WonderEnvironmentSounds);
            SetupComboBoxDict("Wonder Environment SFX", "WonderEnvironmentSoundEfx", "None", StaticData.EnvironmentSoundEffects);
            SetupComboBoxDict("WonderSEKeyForTag", "WonderSEKeyForTag", "", StaticData.WonderSEKeyForTag);

            stackPanel.Children.Add(new Separator());

            SetupComboBoxDict("Badge Medley Equip", "BadgeMedleyEquipBadgeId", "Invalid", StaticData.BadgeIDs);
            SetupComboBoxDict("PlayerRhythmJumpBadgeTiming", "PlayerRhythmJumpBadgeTiming", "None", StaticData.RhythmJumpBadgeTiming);
            SetupComboBoxDict("PlayerRhythmJumpTiming", "PlayerRhythmJumpTiming", "None", StaticData.RhythmJumpTiming);

            stackPanel.Children.Add(new Separator());

            SetupComboBoxDict("Dynamic Resolution Quality", "DynamicResolutionQuality", "None", StaticData.DynamicResolutionQuality);
            SetupComboBoxArr("Background Area Type", "BackGroundAreaType", "Normal", ["Normal", "None", "WithScroll"]);            
            SetupIntBox("RemotePlayerSEPriority", "RemotePlayerSEPriority", 0);

            stackPanel.Children.Add(new Separator());

            SetupCheckBox("BGM Interlock", "BgmInterlock", false);
            SetupCheckBox("Wonder BGM Interlock", "BgmInterlockOfWonder", false);
            SetupCheckBox("Underwater Level", "IsWaterArea", false);
            SetupCheckBox("IsInvisibleDeadLine", "IsInvisibleDeadLine", false);
            SetupCheckBox("IsKoopaJr04Area", "IsKoopaJr04Area", false);
            SetupCheckBox("IsNeedCallWaterInSE", "IsNeedCallWaterInSE", false);
            SetupCheckBox("IsNotCallWaterEnvSE", "IsNotCallWaterEnvSE", false);
            SetupCheckBox("IsResetMarkerFlag", "IsResetMarkerFlag", false);
            SetupCheckBox("IsSetListenerCenter", "IsSetListenerCenter", false);
            SetupCheckBox("IsVisibleOnlySameWonderPlayer", "IsVisibleOnlySameWonderPlayer", false);
            SetupCheckBox("UseMetalicPlayerSoundAsset", "UseMetalicPlayerSoundAsset", false);

            stackPanel.Children.Add(new Separator());
            stackPanel.Children.Add(UIHeader("Skin Param"));
            stackPanel.Children.Add(new Separator());

            SetupCheckBox("DisableBgUnitDecoA", "DisableBgUnitDecoA", false, (Dictionary<string, object>)data["SkinParam"]);
            SetupComboBoxDict("FieldA", "FieldA", "Undefined", StaticData.SkinParamFields, (Dictionary<string, object>)data["SkinParam"]);
            SetupComboBoxDict("FieldB", "FieldB", "Undefined", StaticData.SkinParamFields, (Dictionary<string, object>)data["SkinParam"]);
            SetupComboBoxDict("Object", "Object", "Undefined", StaticData.SkinParamFields, (Dictionary<string, object>)data["SkinParam"]);

            parentUI.Children.Add(stackPanel);
        }

        public override void Save(string path)
        {
            Dictionary<string, object> dataClone = new(data);
            if ((string)dataClone["DynamicResolutionQuality"] == "None")
                dataClone.Remove("DynamicResolutionQuality");
            if ((string)dataClone["EnvironmentSoundEfx"] == "None")
                dataClone.Remove("EnvironmentSoundEfx");

            string yaml = YamlSerializer.Serialize(dataClone);
            using MemoryStream ms = new();
            Byml.FromText(yaml).WriteBinary(ms, Revrs.Endianness.Little);
            File.WriteAllBytes(path, ms.ToArray());
            HasBeenEdited = false;
        }
    }
}
