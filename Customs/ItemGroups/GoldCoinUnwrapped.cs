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
    public class GoldCoinUnwrapped : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "GoldCoinUnwrapped";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("GoldCoinUnwrapped").AssignMaterialsByNames();

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<ChocolateCoin>().GameDataObject,
                    (Item)GDOUtils.GetCustomGameDataObject<GoldFoil>().GameDataObject
                },
                Min = 2,
                Max = 2,
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
                Result = (Item)GDOUtils.GetCustomGameDataObject<GoldCoin>().GameDataObject
            }
        };
    }
}