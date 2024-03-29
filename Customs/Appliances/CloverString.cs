using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class CloverString : CustomAppliance
    {
        public override string UniqueNameID => "CloverString";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CloverString").AssignMaterialsByNames();

        public override PriceTier PriceTier => PriceTier.Free;
        
        public override RarityTier RarityTier => RarityTier.Common;

        public override OccupancyLayer Layer => OccupancyLayer.Wall;

        public override ShoppingTags ShoppingTags => ShoppingTags.SpecialEvent;

        public override bool IsPurchasable => true;

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CMustHaveWall()
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Clover String"
            })
        };
    }
}