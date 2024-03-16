using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Customs.Items;
using StPatricksDay.Customs.Processes;
using UnityEngine;

namespace StPatricksDay.Customs.ItemGroups
{
    public class FilledCoinTray : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "FilledCoinTray";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FilledCoinTray").AssignMaterialsByNames();
        
        public override Item DisposesTo => (Item)GDOUtils.GetCustomGameDataObject<EmptyCoinTray>().GameDataObject;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<EmptyCoinTray>().GameDataObject
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.ChocolateMelted)
                },
                Min = 1,
                Max = 1
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 5,
                Process = (Process)GDOUtils.GetCustomGameDataObject<ChocolateSet>().GameDataObject,
                Result = (Item)GDOUtils.GetCustomGameDataObject<CookedCoinTray>().GameDataObject
            }
        };
    }
}