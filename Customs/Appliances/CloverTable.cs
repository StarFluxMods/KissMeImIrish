using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using StPatricksDay.Components;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class CloverTable : CustomAppliance
    {
        public override string UniqueNameID => "CloverTable";
        
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CloverTable").AssignMaterialsByNames();
        
        public override PriceTier PriceTier => PriceTier.Medium;
        
        public override bool IsPurchasableAsUpgrade => true;

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CApplianceTable(),
            new CItemHolder(),
            new CItemStorage
            {
                ActiveIndex = 0,
                Capacity = 16,
                IsStack = true,
                PreventManualCycling = true
            },
            new CHolderFirstIfStorage(),
            new CLuckyTable()
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Clover Table",
                Description = "Ya feelin' lucky pu... patron?",
                Sections = new List<Appliance.Section>
                {
                    new Appliance.Section
                    {
                        Title = "Lucky",
                        Description = "<color=#55ff55>25%</color> chance for double <sprite name=\"coin\" color=#FF9800>"
                    }
                }
            })
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            base.OnRegister(gameDataObject);
            
            HoldPointContainer holdPointContainer = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
            holdPointContainer.HoldPoint = gameDataObject.Prefab.GetChild("HoldPoint").transform;
        }
    }
}