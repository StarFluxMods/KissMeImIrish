using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Customs.Items;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class EmptyCoinTrayProvider : CustomAppliance
    {
        public override string UniqueNameID => "EmptyCoinTrayProvider";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("EmptyCoinTrayProvider").AssignMaterialsByNames();

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemHolder(),
            new CItemProvider
            {
                Available = 1,
                Maximum = 1,
                PreventReturns = true,
                AutoPlaceOnHolder = true,
                Item = GDOUtils.GetCustomGameDataObject<EmptyCoinTray>().ID
            }
        };

        public override List<Appliance.ApplianceProcesses> Processes => ((Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Countertop)).Processes;

        public override PriceTier PriceTier => PriceTier.Medium;
        public override RarityTier RarityTier => RarityTier.Uncommon;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Coin Tray",
                Description = "Allows you to make Chocolate Coins"
            })
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            base.OnRegister(gameDataObject);
            
            HoldPointContainer holdPointContainer = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
            holdPointContainer.HoldPoint = gameDataObject.Prefab.GetChild("HoldPoint").transform;

            LimitedItemSourceView limitedItemSourceView = gameDataObject.Prefab.AddComponent<LimitedItemSourceView>();

            limitedItemSourceView.Items = new List<GameObject>
            {
                gameDataObject.Prefab.GetChild("HoldPoint/EmptyCoinTray")
            };

            limitedItemSourceView.DisplayedItems = 1;
        }
    }
}