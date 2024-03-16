using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using StPatricksDay.Customs.Items;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class GoldFoilProvider : CustomAppliance
    {
        public override string UniqueNameID => "GoldFoilProvider";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("GoldFoilProvider").AssignMaterialsByNames();

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemProvider
            {
                Available = -1,
                Maximum = -1,
                ProvidedItem = GDOUtils.GetCustomGameDataObject<GoldFoil>().ID,
                ProvidedComponents = new ItemList(GDOUtils.GetCustomGameDataObject<GoldFoil>().ID)
            }
        };

        public override PriceTier PriceTier => PriceTier.Medium;
        public override RarityTier RarityTier => RarityTier.Uncommon;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Gold Leaf",
                Description = "Provides Gold Leaf"
            })
        };

    }
}