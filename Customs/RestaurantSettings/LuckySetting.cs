using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Customs.Appliances;
using UnityEngine;

namespace StPatricksDay.Customs.RestaurantSettings
{
    public class LuckySetting : CustomRestaurantSetting
    {
        public override string UniqueNameID => "LuckySetting";

        public override List<IDecorationConfiguration> Decorators => new List<IDecorationConfiguration>
        {
            new LuckyDecorator.DecorationsConfiguration
            {
                Cobblestone = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Cobblestone),
                Ground = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.CountrysideGround),
                Scatters = new List<LuckyDecorator.DecorationsConfiguration.Scatter>
                {
                    new LuckyDecorator.DecorationsConfiguration.Scatter
                    {
                        Appliance = (Appliance)GDOUtils.GetCustomGameDataObject<LuckyTree>().GameDataObject,
                        Probability = 0.15f
                    },
                    new LuckyDecorator.DecorationsConfiguration.Scatter
                    {
                        Appliance = (Appliance)GDOUtils.GetCustomGameDataObject<FourLeafCloverPatch>().GameDataObject,
                        Probability = 0.25f
                    }
                },
                BorderSpacing = 1,
                FrontBorder = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Flowerbed),
                OnlyDecorateLowerHalf = false
            }
        };

        public override WeatherMode WeatherMode => WeatherMode.None;
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("LuckySettingSnowglobe").AssignMaterialsByNames();
        
        public override bool AlwaysLight => true;
        
        public override List<(Locale, BasicInfo)> InfoList => new List<(Locale, BasicInfo)>
        {
            (Locale.English, new BasicInfo
            {
                Name = "Lucky"
            })
        };
    }
}