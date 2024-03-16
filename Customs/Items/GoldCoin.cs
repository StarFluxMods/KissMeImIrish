using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class GoldCoin : CustomItem
    {
        public override string UniqueNameID => "GoldCoin";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("GoldCoin").AssignMaterialsByNames();
        
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override ItemValue ItemValue => ItemValue.Small;
    }
}