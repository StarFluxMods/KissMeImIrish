using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class LuckyTree : CustomAppliance
    {
        public override string UniqueNameID => "LuckyTree";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("LuckyTree").AssignMaterialsByNames();

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CImmovable(),
            new CStatic()
        };

        public override bool IsNonInteractive => true;

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Lucky Tree",
                Description = ""
            })
        };
    }
}