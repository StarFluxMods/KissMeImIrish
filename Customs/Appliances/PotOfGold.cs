using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class PotOfGold : CustomAppliance
    {
        public override string UniqueNameID => "PotOfGold";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PotOfGold").AssignMaterialsByNames();

        public override PriceTier PriceTier => PriceTier.Free;
        
        public override RarityTier RarityTier => RarityTier.Common;

        public override ShoppingTags ShoppingTags => ShoppingTags.SpecialEvent;

        public override bool IsPurchasable => true;

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Pot O' Gold",
                Description = "Where's the rainbow?"
            })
        };
    }
}