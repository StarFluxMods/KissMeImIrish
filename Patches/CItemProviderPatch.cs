using HarmonyLib;
using Kitchen;
using KitchenLib.Utils;
using StPatricksDay.Customs.Items;
using Unity.Entities;

namespace StPatricksDay.Patches
{
    [HarmonyPatch(typeof(CItemProvider), "Attach")]
    public class CItemProviderPatch
    {
        static bool Prefix(CItemProvider __instance, EntityManager em, EntityCommandBuffer ecb, Entity e)
        {
            if (__instance.ProvidedItem != GDOUtils.GetCustomGameDataObject<EmptyCoinTray>().ID && __instance.ProvidedItem != GDOUtils.GetCustomGameDataObject<GoldFoil>().ID) return true;
            
            ecb.AddComponent(e, __instance);
            return false;

        }
    }
}