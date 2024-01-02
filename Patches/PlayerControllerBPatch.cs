using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace AouldsTweaks.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
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
    }
}
