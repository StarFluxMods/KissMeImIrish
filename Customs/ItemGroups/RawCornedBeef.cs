using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Customs.Items;
using UnityEngine;

namespace StPatricksDay.Customs.ItemGroups
{
    public class RawCornedBeef : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "RawCornedBeef";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("RawCornedBeef").AssignMaterialsByNames();
        
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(-2080052245);
        
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<SemiCookedWetBeef>().GameDataObject
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.CarrotChopped),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.PotatoChopped),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.LettuceChopped)
                },
                Min = 3,
                Max = 3
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 15,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Result = (Item)GDOUtils.GetCustomGameDataObject<CookedCornedBeef>().GameDataObject
            }
        };
        
        public override void OnRegister(ItemGroup gameDataObject)
        {
            ItemGroupView view = gameDataObject.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.CarrotChopped),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Carrot"),
                    DrawAll = true
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.PotatoChopped),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Potato"),
                    DrawAll = true
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.LettuceChopped),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Salad"),
                    DrawAll = true
                }
            };
        }
    }
}