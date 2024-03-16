using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using StPatricksDay.Customs.Appliances;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class GoldFoil : CustomItem
    {
        public override string UniqueNameID => "GoldFoil";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("GoldFoil").AssignMaterialsByNames();

        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<GoldFoilProvider>().GameDataObject;
    }
}