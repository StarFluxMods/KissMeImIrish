using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class CornedBeefPortion : CustomItem
    {
        public override string UniqueNameID => "CornedBeefPortion";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CornedBeefPortion").AssignMaterialsByNames();
        
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    }
}