using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Interfaces;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.PlayerCosmetics
{
    public class IrishApron : CustomPlayerCosmetic, IDontRegister
    {
        public override string UniqueNameID => "IrishApron";
        public override CosmeticType CosmeticType => CosmeticType.Outfit;
        public override GameObject Visual => Mod.Bundle.LoadAsset<GameObject>("IrishApron").AssignMaterialsByNames();
        
        public override void OnRegister(PlayerCosmetic gameDataObject)
        {
            GameObject Prefab = gameDataObject.Visual;

            PlayerOutfitComponent playerOutfitComponent = Prefab.AddComponent<PlayerOutfitComponent>();
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Text").GetComponent<SkinnedMeshRenderer>());
        }
    }
}