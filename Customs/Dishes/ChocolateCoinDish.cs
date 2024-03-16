using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Customs.Items;
using StPatricksDay.Customs.Processes;

namespace StPatricksDay.Customs.Dishes
{
    public class ChocolateCoinDish : CustomDish
    {
        public override string UniqueNameID => "ChocolateCoinDish";
		
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
		
		public override bool IsUnlockable => true;
		
		public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
		
		public override CardType CardType => CardType.Default;
		
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
		
		public override DishType Type => DishType.Dessert;

		public override int Difficulty => 1;
		
		public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
		{
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Chocolate),
			(Item)GDOUtils.GetCustomGameDataObject<EmptyCoinTray>().GameDataObject,
			(Item)GDOUtils.GetCustomGameDataObject<GoldFoil>().GameDataObject,
		};

		public override List<Unlock> HardcodedRequirements => new List<Unlock>
		{
			(Unlock)GDOUtils.GetCustomGameDataObject<CornedBeef>().GameDataObject
		};

		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
			(Process)GDOUtils.GetCustomGameDataObject<ChocolateSet>().GameDataObject
		};

		public override bool RequiredNoDishItem => true;

		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = (Item)GDOUtils.GetCustomGameDataObject<GoldCoin>().GameDataObject,
				Phase = MenuPhase.Dessert,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			}
		};
        
		public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Melt Chocolate, put into tray and wait until hardened, portion, wrap in gold leaf, and serve." }
        };
		
        public override bool IsAvailableAsLobbyOption => false;

		public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
		{
			(Locale.English, new UnlockInfo
			{
				Name = "Chocolate Coins",
				Description = "Adds Chocolate Coins as a Dessert",
				FlavourText = ""
			})
		};
    }
}