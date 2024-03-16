using System.Collections.Generic;
using System.Reflection;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class CookedCornedBeef : CustomItem
    {
        public override string UniqueNameID => "CookedCornedBeef";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CookedCornedBeef").AssignMaterialsByNames();
        
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(-2080052245);
        
        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<CornedBeefPortion>().GameDataObject;
        
        public override int SplitCount => 4;
        
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetExistingGDO(-2080052245)
        };

        public override void OnRegister(Item gameDataObject)
        {
            ObjectsSplittableView view = gameDataObject.Prefab.AddComponent<ObjectsSplittableView>();

            FieldInfo info = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            List<GameObject> list = new List<GameObject>();
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Group 4"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Group 3"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Group 2"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Group 1"));
            info.SetValue(view, list);
        }
    }
}