using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Customs.ItemGroups;
using UnityEngine;

namespace StPatricksDay.Customs.Dishes
{
    public class CornedBeef : CustomDish
	{
		public override string UniqueNameID => "CornedBeef";
		
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
		
		public override bool IsUnlockable => true;
		
		public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
		
		public override CardType CardType => CardType.Default;
		
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
		
		public override DishType Type => DishType.Base;

		public override int Difficulty => 2;
		
		public override List<string> StartingNameSet => new List<string> {
			"Top o’ the Cornin’",
			"Lepre-corned Beef",
			"Sham Rockin’",
			"Kiss Me, I’m Irish",
			"Four Leaf Clover",
			"Shamrock n’ roll",
			"Cute Clovers",
			"Pots o’ Gold",
			"Can’t Pinch This",
			"A Wee Bit Irish",
			"Bunch of Blarney",
			"Lucky & Charming",
			"Luck o’ the Irish",
			"Figs & Jigs",
			"A Wee Feast",
			"Emerald Eatery",
			"Shake Your Shamrock",
			"Emotional Cabbage",
			"Get Clover It",
			"Wanna Be My Clover",
			"Brunch of the Irish",
			"Lucky Legend",
		};
		
		public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
		{
			(Item)GDOUtils.GetExistingGDO(-2080052245),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.MeatThick),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Potato),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Lettuce),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Carrot),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
			
		};

		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.RequireOven)
		};
		
		public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("PlatedCornedBeefIcon").AssignMaterialsByNames().AssignVFXByNames();
		
		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = (Item)GDOUtils.GetCustomGameDataObject<PlatedCornedBeef>().GameDataObject,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			}
		};
		
		public override bool IsAvailableAsLobbyOption => true;
        
		public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add Water and Thick Meat into a tray and cook, add chopped Carrot, Potato, and Lettuce, then cook again. Portion and Plate. (Serves 4)" }
        };

		public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
		{
			(Locale.English, new UnlockInfo
			{
				Name = "Corned Beef",
				Description = "Adds Corned Beef as a Main",
				FlavourText = ""
			})
		};
    }
}