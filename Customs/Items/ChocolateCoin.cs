using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class ChocolateCoin : CustomItem
    {
        public override string UniqueNameID => "ChocolateCoin";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChocolateCoin").AssignMaterialsByNames();
        
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override ItemValue ItemValue => ItemValue.Small;
    }
}