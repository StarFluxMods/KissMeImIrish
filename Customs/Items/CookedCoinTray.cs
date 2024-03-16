using System.Collections.Generic;
using System.Reflection;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Items
{
    public class CookedCoinTray : CustomItem
    {
        public override string UniqueNameID => "CookedCoinTray";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CookedCoinTray").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetCustomGameDataObject<EmptyCoinTray>().GameDataObject;
        
        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<ChocolateCoin>().GameDataObject;
        
        public override int SplitCount => 12;
        
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetCustomGameDataObject<EmptyCoinTray>().GameDataObject
        };

        public override void OnRegister(Item gameDataObject)
        {
            ObjectsSplittableView view = gameDataObject.Prefab.AddComponent<ObjectsSplittableView>();

            FieldInfo info = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            List<GameObject> list = new List<GameObject>();
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 1"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 2"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 3"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 4"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 5"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 6"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 7"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 8"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 9"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 10"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 11"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Coins/ChocolateCoin 12"));
            info.SetValue(view, list);
        }
    }
}