using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class Marker : CustomAppliance
    {
        public override string UniqueNameID => "Marker";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Marker").AssignMaterialsByNames();
        
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
                Name = "Marker",
                Description = ""
            })
        };
    }
}