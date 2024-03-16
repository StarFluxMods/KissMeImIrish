using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using StPatricksDay.Customs.Appliances;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class EmptyCoinTray : CustomItem
    {
        public override string UniqueNameID => "EmptyCoinTray";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("EmptyCoinTray").AssignMaterialsByNames();

        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<EmptyCoinTrayProvider>().GameDataObject;

        public override bool IsIndisposable => true;
    }
}