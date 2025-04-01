using System;
using System.Reflection;
using SPT.Reflection.Patching;
using EFT.UI.Map;
using HarmonyLib;
using EFT.UI.WeaponModding;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFT;
using SPT.Custom.Utils;
using System.Linq;
using JetBrains.Annotations;
using EFT.Game.Spawning;
using Comfort.Common;
using Comfort.Logs;


namespace FixHalloweenSummonEvent.Patches;

public static class BotHalloweenEventPatch
{
    public static void Enable()
    {
        new BotsControllerInitPatch().Enable();
        new BotsEventsControllerActivatePatch().Enable();        
    }

    public class BotsControllerInitPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(BotsController), nameof(BotsController.Init));
        }

        [PatchPostfix]
        public static void PatchPostfix(BotsController __instance, LocationSettingsClass.Location.GClass1353 events)
        {
            // Run it again with a non-null _botSpawner.
            __instance.EventsController = new BotsEventsController(
                __instance.BotGame.GameDateTime, 
                __instance.Bots, 
                __instance.ZonesLeaveController, 
                __instance._botSpawner, 
                __instance.CoversData.AIPlaceInfoHolder, 
                events, 
                __instance.CoversData);
            __instance.EventsController.Activate();
        }
    }    
    
    public class BotsEventsControllerActivatePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {  
            return AccessTools.Method(typeof(BotsEventsController), nameof(BotsEventsController.Activate));
        }

        [PatchPrefix]
        public static bool PatchPrefix(BotsEventsController __instance)
        {
            if (__instance.BotHalloweenEvent._spawner == null)
            {                
                Plugin.log.LogInfo($"__instance.BotHalloweenEvent._spawner is null skip Activate");    
                return false;
            }
            Plugin.log.LogInfo($"__instance.BotHalloweenEvent._spawner is not null run Activate"); 
            return true;
        }
    }
}


/* SPT 3.11
    BotsController
    public void Init(IBotGame botGame, IBotCreator botCreator, BotZone[] botZones, ISpawnSystem spawnSystem, BotLocationModifier botLocationModifier, bool botEnable, bool freeForAll, bool enableWaveControl, bool online, bool haveSectants, [NotNull] IPlayersCollection players, string openZones, LocationSettingsClass.Location.GClass1353 events)
    {
        smethod_0();
        BotGame = botGame;
        Players = players;
        _coversData = AICoversData.CreateOrFind(undestandAtGame: true);
        _coversData.RestoreData();
        _coversData.CachePoints();
        BotCoverBounds.DisableAllCoilliders();
        BotDoorsController.CreateOrFind(doErrorMsg: false).RefreshData(this);
        BotCreationDataClass.ProfilesLoadingProcess = 0;
        if (Singleton<IBotGame>.Instantiated)
        {
            Singleton<IBotGame>.Release(Singleton<IBotGame>.Instance);
        }

        Singleton<IBotGame>.Create(BotGame);
        PlantedMines = new BotsPlantedMinesController(_coversData);
        StationaryWeapons = GClass849.FindUnityObjectOfType<AIStationaryController>();
        StationaryWeapons.Init(_coversData.AICorePointsHolder);
        AiTaskManager = new AITaskManager();
        ZonesLeaveController = new ZoneLeaveControllerClass(Bots, botGame.GameDateTime, botZones, haveSectants, _maxCount, players);
        ArtilleryZonesController = new GClass1645(this);
        ArtilleryZonesController.Activate();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Singleton<GClass600>.Create(new GClass600());
        Singleton<GClass600>.Instance.SetSettings(_botPresets, _botScatterings, botLocationModifier);
        OnlineDependenceSettings = new GClass3383(online);
        BotSettingsRepoClass.Init();
        if (DebugBotData.UseDebugData)
        {
            DebugBotData.Instance.InitMessage();
            if (!botEnable)
            {
                UnityEngine.Debug.LogError("Really? You are using DebugBotData, but you turned off bots? Why??? ");
                botEnable = true;
                UnityEngine.Debug.LogError("Bots turned ON!!! (If u still want to play without bots but with DBD write code)");
            }
        }

        if (DebugBotData.UseDebugData && DebugBotData.Instance.FreeForAllOverride)
        {
            freeForAll = DebugBotData.Instance.FreeForAll;
        }

        EventsController = new BotsEventsController(BotGame.GameDateTime, Bots, ZonesLeaveController, _botSpawner, CoversData.AIPlaceInfoHolder, events, CoversData);
        method_2();
        GClass359.Init();
        _canSpawn = botEnable;
        for (int i = 0; i < botZones.Length; i++)
        {
            botZones[i].Init(botLocationModifier, this);
        }

        BotLocationModifier = botLocationModifier ?? new BotLocationModifier();
        BotLocationModifier.Validate();
        List<BotZone> list = new List<BotZone>();
        BotZone[] array = botZones;
        foreach (BotZone botZone in array)
        {
            if (botZone.SpawnPointMarkers.Count != 0)
            {
                list.Add(botZone);
            }
        }

        if (list.Count <= 0)
        {
            _canSpawn = false;
        }

        Dictionary<PatrolPoint, BotZone> dictionary = method_1(botZones);
        botZones = list.ToArray();
        _botSpawner = new GClass1661(botCreator, botGame, botZones, Bots, spawnSystem, _maxCount, freeForAll, dictionary, openZones);
        _botSpawner.SetMaxBots(_maxCount);
        if (DebugBotData.UseDebugData)
        {
            DebugBotData.Instance.StartUseAutoRespawn(_botSpawner, Bots, _botSpawner.Groups);
        }

        _spawnControlScenario = new GClass656();
        if (enableWaveControl)
        {
            _spawnControlScenario.Init(_botSpawner, dictionary);
        }

        if (Singleton<BotEventHandler>.Instantiated)
        {
            if (_canSpawn)
            {
                Singleton<BotEventHandler>.Instance.OnKill += method_11;
                Singleton<BotEventHandler>.Instance.OnBeingHit += method_12;
                Singleton<BotEventHandler>.Instance.OnGrenadeThrow += method_5;
                Singleton<BotEventHandler>.Instance.OnGrenadeExplosive += method_3;
                Singleton<BotEventHandler>.Instance.OnRocketExplosive += method_4;
                Singleton<BotEventHandler>.Instance.OnApplyLighthouseKeeperFriendlyUsecs += method_6;
                Singleton<BotEventHandler>.Instance.OnApplyLighthouseKeeperFriendlyZryachiy += method_7;
            }

            Singleton<BotEventHandler>.Instance.OnApplyTraderServiceBtrSupport += method_8;
            Singleton<BotEventHandler>.Instance.OnStopTraderServiceBtrSupport += method_9;
            Singleton<BotEventHandler>.Instance.OnInterruptTraderServiceBtrSupportByBetrayer += method_10;
        }

        _connections.Activate();
        if (BotGame != null)
        {
            BotGame.UpdateByUnity += method_0;
        }

        stopwatch.Stop();
        ZonesLeaveController.Activate();
        AICoreController.Activate();
        EventsController.Activate();
        CutController.Init(this, botZones);
        PlantedMines.Activate();
        CutController.Init(this, botZones);
        if (!(_coversData.Patrols != null) || _coversData.Patrols.LootPointClusters == null)
        {
            return;
        }

        foreach (AILootPointsCluster lootPointCluster in _coversData.Patrols.LootPointClusters)
        {
            lootPointCluster.CollectActualSpawnedLoot(Singleton<GameWorld>.Instance.AllLoot);
        }
    }


*/
