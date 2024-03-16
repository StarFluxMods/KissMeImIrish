using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class GoldFoilStack : CustomItem
    {
        public override string UniqueNameID => "GoldFoilStack";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("GoldFoilStack").AssignMaterialsByNames();
    }
}