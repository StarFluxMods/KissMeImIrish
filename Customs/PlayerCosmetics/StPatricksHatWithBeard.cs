using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace StPatricksDay.Customs.PlayerCosmetics
{
    public class StPatricksHatWithBeard : CustomPlayerCosmetic
    {
        public override string UniqueNameID => "StPatricksHatWithBeard";
        public override CosmeticType CosmeticType => CosmeticType.Hat;
        public override GameObject Visual => Mod.Bundle.LoadAsset<GameObject>("StPatricksHatWithBeard").AssignMaterialsByNames();
        public override bool BlockHats => true;
        
        public override void OnRegister(PlayerCosmetic gameDataObject)
        {
            GameObject Prefab = gameDataObject.Visual;

            PlayerOutfitComponent playerOutfitComponent = Prefab.AddComponent<PlayerOutfitComponent>();
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Belt Buckel").GetComponent<SkinnedMeshRenderer>());
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Clover").GetComponent<SkinnedMeshRenderer>());
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Hat Body").GetComponent<SkinnedMeshRenderer>());
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Cube").GetComponent<SkinnedMeshRenderer>());
        }
    }
}