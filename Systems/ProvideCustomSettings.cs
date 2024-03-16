using Kitchen;
using KitchenLib.Utils;
using KitchenMods;
using StPatricksDay.Customs.RestaurantSettings;
using Unity.Collections;
using Unity.Entities;

namespace StPatricksDay.Systems
{
    public class ProvideCustomSettings : GameSystemBase, IModSystem
    {

        private EntityQuery _settingUpgrades;
        
        protected override void Initialise()
        {
            base.Initialise();
            _settingUpgrades = GetEntityQuery(typeof(CSettingUpgrade));
        }

        protected override void OnUpdate()
        {
            using NativeArray<Entity> settingUpgrades = _settingUpgrades.ToEntityArray(Allocator.TempJob);
            foreach (Entity settingUpgrade in settingUpgrades)
            {
                if (Require(settingUpgrade, out CSettingUpgrade cSettingUpgrade))
                {
                    if (cSettingUpgrade.SettingID == GDOUtils.GetCustomGameDataObject<LuckySetting>().ID)
                    {
                        return;
                    }
                }
            }
            
            Entity e = EntityManager.CreateEntity(typeof(CSettingUpgrade));
            EntityManager.SetComponentData(e, new CSettingUpgrade
            {
                SettingID = GDOUtils.GetCustomGameDataObject<LuckySetting>().ID
            });
        }
    }
}