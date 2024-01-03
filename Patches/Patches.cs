using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace AouldsTweaks.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerPatch
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void weightSprintPatch(ref float ___carryWeight, ref float ___sprintMeter)
        {
            if (___carryWeight == 1f)
            {
                ___sprintMeter += 0.001f;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    [HarmonyPatch(typeof(Landmine))]
    internal class Minefix
    {
        [HarmonyPatch("OnTriggerEnter")]
        [HarmonyPrefix]
        static bool TriggerEnterPrefix(ref Collider other, ref bool ___localPlayerOnMine, Landmine __instance)
        {
            if (other.CompareTag("Player"))
            {
                __instance.mineAudio.PlayOneShot(__instance.minePress);
                WalkieTalkie.TransmitOneShotAudio(__instance.mineAudio, __instance.minePress, 1f);

                PlayerControllerB component = other.gameObject.GetComponent<PlayerControllerB>();
                while (component == GameNetworkManager.Instance.localPlayerController)
                {
                    ___localPlayerOnMine = false;
                    return false;
                }
                return true;
            }
            return true;
        }

        [HarmonyPatch("TriggerMineOnLocalClientByExiting")]
        [HarmonyPrefix]
        static void MineExitPrefix(Landmine __instance, ref bool ___hasExploded, ref bool ___sendingExplosionRPC, ref bool ___localPlayerOnMine)
        {
            if (___hasExploded == false && ___localPlayerOnMine == false)
            {
                __instance.SetOffMineAnimation();
                ___sendingExplosionRPC = true;
                __instance.ExplodeMineServerRpc();
                return;
            }
            else
            {
                return;
            }
        }
    }
}
