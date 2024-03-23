using KitchenLib;
using KitchenLib.Logging;
using KitchenLib.Logging.Exceptions;
using KitchenMods;
using System.Linq;
using System.Reflection;
using KitchenData;
using KitchenLib.Event;
using KitchenLib.Interfaces;
using KitchenLib.References;
using KitchenLib.Utils;
using StPatricksDay.Customs.Appliances;
using StPatricksDay.Customs.Processes;
using UnityEngine;

namespace StPatricksDay
{
    public class Mod : BaseMod, IModSystem, IAutoRegisterAll
    {
        public const string MOD_GUID = "com.starfluxgames.stpatricksday";
        public const string MOD_NAME = "Kiss Me I'm Irish";
        public const string MOD_VERSION = "0.1.1";
        public const string MOD_AUTHOR = "StarFluxGames";
        public const string MOD_GAMEVERSION = ">=1.1.9";

        public static AssetBundle Bundle;
        public static KitchenLogger Logger;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            Logger.LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);
            Logger = InitLogger();

            Events.BuildGameDataEvent += (s, args) => 
            {
                if (!args.firstBuild) return;
                
                args.gamedata.Get<Item>(-2080052245).IsIndisposable = true; // Temporary fix for the vanilla Lasagna Tray not being indisposable
                
                args.gamedata.Get<Appliance>(ApplianceReferences.TableLarge).Upgrades.Add((Appliance)GDOUtils.GetCustomGameDataObject<CloverTable>().GameDataObject);

                foreach (Appliance appliance in args.gamedata.Get<Appliance>())
                {
                    for (var i = 0; i < appliance.Processes.Count; i++)
                    {
                        var process = appliance.Processes[i];
                        if (process.Process.ID == ProcessReferences.SteepTea
                            || process.Process.ID == ProcessReferences.Chop
                            || process.Process.ID == ProcessReferences.Knead) 
                        {
                            appliance.Processes.Add(new Appliance.ApplianceProcesses
                            {
                                Process = (Process)GDOUtils.GetCustomGameDataObject<ChocolateSet>().GameDataObject,
                                Speed = 1,
                                IsAutomatic = true
                            });
                            break;
                        }
                    }
                }

                Item tray = args.gamedata.Get<Item>(ItemReferences.Tray);
                tray.Prefab.GetChild("Storage 1").transform.localPosition = tray.Prefab.GetChild("Storage 1").transform.localPosition + new Vector3(0, 0, -0.118f);
                tray.Prefab.GetChild("Storage 2").transform.localPosition = tray.Prefab.GetChild("Storage 2").transform.localPosition + new Vector3(0, 0, -0.118f);
            };
        }
    }
}

