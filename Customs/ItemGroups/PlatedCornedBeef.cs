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
    public class PlatedCornedBeef : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "PlatedCornedBeef";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PlatedCornedBeef").AssignMaterialsByNames().AssignVFXByNames();
        
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);

        public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);

        public override ItemValue ItemValue => ItemValue.Medium;

        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<CornedBeefPortion>().GameDataObject
                },
                Min = 1,
                Max = 1
            }
        };
    }
}