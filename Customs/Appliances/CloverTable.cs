using System.Collections.Generic;
using System.Reflection;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Components;
using UnityEngine;

namespace StPatricksDay.Customs.Appliances
{
    public class CloverTable : CustomAppliance
    {
        public override string UniqueNameID => "CloverTable";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CloverTable").AssignMaterialsByNames().AssignVFXByNames();
        
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
                    },
                    new Appliance.Section
                    {
                        Title = "Combinable",
                        Description = "Combines with adjacent tables"
                    }
                }
            })
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            base.OnRegister(gameDataObject);
            
            HoldPointContainer holdPointContainer = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
            holdPointContainer.HoldPoint = gameDataObject.Prefab.GetChild("HoldPoint").transform;
            ItemVariableStorageView itemVariableStorageView = gameDataObject.Prefab.GetChild("Table Dirt Attachment").AddComponent<ItemVariableStorageView>();
            
            FieldInfo _Storage = ReflectionUtils.GetField<ItemVariableStorageView>("Storage");
            FieldInfo _MoveHeldItemPosition = ReflectionUtils.GetField<ItemVariableStorageView>("MoveHeldItemPosition");
            
            itemVariableStorageView.HeldItemPosition = gameDataObject.Prefab.GetChild("HoldPoint").transform;

            List<GameObject> Storage = new List<GameObject>
            {
                gameDataObject.Prefab.GetChild("Table Dirt Attachment/Storage1"),
                gameDataObject.Prefab.GetChild("Table Dirt Attachment/Storage2"),
                gameDataObject.Prefab.GetChild("Table Dirt Attachment/Storage3"),
                gameDataObject.Prefab.GetChild("Table Dirt Attachment/Storage4"),
                gameDataObject.Prefab.GetChild("Table Dirt Attachment/Storage5"),
                gameDataObject.Prefab.GetChild("Table Dirt Attachment/Storage6"),
            };
            
            _Storage.SetValue(itemVariableStorageView, Storage);
            _MoveHeldItemPosition.SetValue(itemVariableStorageView, true);
            
            AttachmentView attachmentView = gameDataObject.Prefab.GetChild("Table Decoration Attachment").AddComponent<AttachmentView>();

            FieldInfo _EffectLookups = ReflectionUtils.GetField<AttachmentView>("EffectLookups");
            FieldInfo _OrientedObjects = ReflectionUtils.GetField<AttachmentView>("OrientedObjects");
            
            
            List<AttachmentView.EffectLookup> EffectLookups = new List<AttachmentView.EffectLookup>
            {
                new AttachmentView.EffectLookup
                {
                    Effect = (Effect)GDOUtils.GetExistingGDO(EffectReferences.Breadsticks),
                    Inactive = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Breadsticks"),
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Breadsticks Active")
                },
                new AttachmentView.EffectLookup
                {
                    Effect = (Effect)GDOUtils.GetExistingGDO(EffectReferences.Candles),
                    Inactive = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Unlit Candle"),
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Lit Candle")
                },
                new AttachmentView.EffectLookup
                {
                    Effect = (Effect)GDOUtils.GetExistingGDO(EffectReferences.Napkins),
                    Inactive = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Napkin"),
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Napkin Active")
                },
                new AttachmentView.EffectLookup
                {
                    Effect = (Effect)GDOUtils.GetExistingGDO(EffectReferences.SharpCutlery),
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Sharp Cutlery")
                }
            };
            
            List<AttachmentView.OrientedObject> OrientedObjects = new List<AttachmentView.OrientedObject>
            {
                new AttachmentView.OrientedObject
                {
                    Orientation = Orientation.Up,
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Sharp Cutlery/Sharp_Cutlery1")
                },
                new AttachmentView.OrientedObject
                {
                    Orientation = Orientation.Right,
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Sharp Cutlery/Sharp_Cutlery2")
                },
                new AttachmentView.OrientedObject
                {
                    Orientation = Orientation.Down,
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Sharp Cutlery/Sharp_Cutlery3")
                },
                new AttachmentView.OrientedObject
                {
                    Orientation = Orientation.Left,
                    Active = gameDataObject.Prefab.GetChild("Table Decoration Attachment/Sharp Cutlery/Sharp_Cutlery4")
                }
            };
            
            _EffectLookups.SetValue(attachmentView, EffectLookups);
            _OrientedObjects.SetValue(attachmentView, OrientedObjects);
        }
    }
}