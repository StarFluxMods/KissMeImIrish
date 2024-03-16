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
    public class WetThickBeef : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "WetThickBeef";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("WetThickBeef").AssignMaterialsByNames();
        
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(-2080052245);
        
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(-2080052245)
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.MeatThick),
                },
                Min = 2,
                Max = 2
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 5,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Result = (Item)GDOUtils.GetCustomGameDataObject<SemiCookedWetBeef>().GameDataObject
            }
        };
        
        public override void OnRegister(ItemGroup gameDataObject)
        {
            ItemGroupView view = gameDataObject.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Water"),
                    DrawAll = true
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.MeatThick),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Meat"),
                    DrawAll = true
                }
            };
        }
    }
}