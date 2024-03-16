using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class FourLeafCloverPatch : CustomAppliance
    {
        public override string UniqueNameID => "FourLeafCloverPatch";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("4LeafCloverPatch").AssignMaterialsByNames();

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
                Name = "4 Leaf Clover Patch",
                Description = ""
            })
        };
    }
}