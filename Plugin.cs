using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using FixHalloweenSummonEvent.Patches;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Linq;

namespace FixHalloweenSummonEvent
{
    [BepInPlugin("com.November75.FixHalloweenSummonEvent", "FixHalloweenSummonEvent", "1.0.0")]
    [BepInDependency("com.SPT.core", "3.11.0")]  
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource log;
        private void Awake()
        {
            log = Logger;
            BotHalloweenEventPatch.Enable();
        }
    }
}





/*

  BotHalloweenEvent.method_1
  when kill PeaceZryachiyKilled
  at FixHalloweenSummonEvent.Patches.BotHalloweenEventPatch.PatchPrefix (EFT.Grenade __instance) [0x00000] in <73824fe0405847f3a1cd32aa7a20e4be>:0 
  at BotHalloweenEvent.DMD<BotHalloweenEvent::method_1> (BotHalloweenEvent ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at BotHalloweenEvent.PeaceZryachiyKilled () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at GClass438.Dispose () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at BotBoss.Dispose () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.BotOwner.DMD<EFT.BotOwner::Dispose> (EFT.BotOwner ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.BotOwner.method_6 (EFT.EDamageType damageType) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.HealthSystem.ActiveHealthController.Kill (EFT.EDamageType damageType) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.HealthSystem.ActiveHealthController.method_23 (EBodyPart bodyPart, EFT.EDamageType damageType) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.HealthSystem.ActiveHealthController.DestroyBodyPart (EBodyPart bodyPart, EFT.EDamageType damageType) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.HealthSystem.ActiveHealthController.DMD<EFT.HealthSystem.ActiveHealthController::ApplyDamage> (EFT.HealthSystem.ActiveHealthController , EBodyPart , System.Single , DamageInfoStruct ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.Player.ApplyDamageInfo (DamageInfoStruct damageInfo, EBodyPart bodyPartType, EBodyPartColliderType colliderType, System.Single absorbed) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.Player.ApplyShot (DamageInfoStruct damageInfo, EBodyPart bodyPartType, EBodyPartColliderType colliderType, EArmorPlateCollider armorPlateCollider, ShotIdStruct shotId) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at BodyPartCollider+PlayerBridge.ApplyShot (DamageInfoStruct damageInfo, EBodyPart bodyPart, EBodyPartColliderType bodyPartCollider, EArmorPlateCollider armorPlateCollider, ShotIdStruct shotId) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at BodyPartCollider.ApplyHit (DamageInfoStruct damageInfo, ShotIdStruct shotID) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.ClientGameWorld.ShotDelegate (EftBulletClass shotResult) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.Ballistics.BallisticsCalculator.method_2 (System.Single simulationTime) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.Ballistics.BallisticsCalculator.ManualUpdate (System.Single deltaTime) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.GameWorld.BallisticsTick (System.Single dt) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.GameWorld.DoWorldTick (System.Single dt) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.GameWorldUnityTickListener.Update () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 





    BotHalloweenEvent.StartRitual 
  _eventTime is 390

  at FixHalloweenSummonEvent.Patches.BotHalloweenEventPatch.PatchPrefix (EFT.Grenade __instance) [0x00000] in <bc057730c92e49d291fdaa75a3b0dfab>:0 
  at BotHalloweenEvent.DMD<BotHalloweenEvent::StartRitual> (BotHalloweenEvent ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at GClass432.StartRitual () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at GClass93.GetDecision () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at AICoreLayerClass[T].Update (System.Nullable`1[T] prevDecision) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at DrakiaXYZ.BigBrain.Patches.BotBaseBrainUpdatePatch.PatchPrefix (System.Object __instance, AICoreActionResultStruct[T,U] prevResult, System.Nullable`1[AICoreActionResultStruct[BotLogicDecision,GClass26]]& __result) [0x00000] in <05447b5405e74c3a834b7e8e9d549c39>:0 
  at AICoreStrategyAbstractClass[T].DMD<AICoreStrategyAbstractClass[[BotLogicDecision, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]::Update> (AICoreStrategyAbstractClass[T] , AICoreActionResultStruct[T,U] ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at MonoMod.Utils.DynamicMethodDefinition.Glue:ThiscallStructRetPtr<AICoreStrategyAbstractClass[[BotLogicDecision, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]::Update,DMD<AICoreStrategyAbstractClass[[BotLogicDecision, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]::Update>> (AICoreStrategyAbstractClass[T] , System.Nullable`1[AICoreActionResultStruct[BotLogicDecision,GClass26]]& , AICoreActionResultStruct[T,U] ) [0x00000] in <6733e342b5b549bba815373898724469>:0 
  at DrakiaXYZ.BigBrain.Patches.BotAgentUpdatePatch.PatchPrefix (AICoreAgentClass[T] __instance) [0x00000] in <05447b5405e74c3a834b7e8e9d549c39>:0 
  at AICoreAgentClass[T].DMD<AICoreAgentClass[[BotLogicDecision, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]::Update> (AICoreAgentClass[T] ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at AICoreControllerClass.Update () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.BotsController.method_0 () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.BaseLocalGame`1[TPlayerOwner].Update () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 


    BotHalloweenEvent.method_2
  at FixHalloweenSummonEvent.Patches.BotHalloweenEventPatch+method_2Patch.PatchPrefix (BotHalloweenEvent __instance) [0x00000] in <641db83d9b2549f6a1baa98554434598>:0 
  at BotHalloweenEvent.DMD<BotHalloweenEvent::method_2> (BotHalloweenEvent ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at BotHalloweenEvent.UpdateFromBoss () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at GClass186.UpdateNodeByBrain (GClass26 data) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at GClass169`1[T].UpdateNodeByMain (GClass26 lastResultData) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at DrakiaXYZ.BigBrain.Patches.BotAgentUpdatePatch.PatchPrefix (AICoreAgentClass[T] __instance) [0x00000] in <05447b5405e74c3a834b7e8e9d549c39>:0 
  at AICoreAgentClass[T].DMD<AICoreAgentClass[[BotLogicDecision, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]::Update> (AICoreAgentClass[T] ) [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at AICoreControllerClass.Update () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.BotsController.method_0 () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 
  at EFT.BaseLocalGame`1[TPlayerOwner].Update () [0x00000] in <13b3da31885d4b8d827d4190298e367f>:0 


    _spawner == null

    BotHalloweenEvent.RitualCompleted
    Not call



    BotsController.init they make spawner after call event
*/