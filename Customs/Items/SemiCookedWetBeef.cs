using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class SemiCookedWetBeef : CustomItem
    {
        public override string UniqueNameID => "SemiCookedWetBeef";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("SemiCookedWetBeef").AssignMaterialsByNames();
        
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(-2080052245);
    }
}