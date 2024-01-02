using AouldsTweaks.Patches;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AouldsTweaks
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class AouldsTweaksBase : BaseUnityPlugin
    {
        private const string modGUID = "Aouldrain.AouldsTweaks";
        private const string modName = "AouldsTweaks";
        private const string modVersion = "0.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static AouldsTweaksBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Big Booty Bitches be like");
            mls.LogInfo(".▄▄▄·.......▄•.▄▌▄▄▌..·▄▄▄▄..▄▄▄...▄▄▄·.▪...▐.▄.");
            mls.LogInfo("▐█.▀█.▪.....█▪██▌██•..██▪.██.▀▄.█·▐█.▀█.██.•█▌▐█");
            mls.LogInfo("▄█▀▀█..▄█▀▄.█▌▐█▌██▪..▐█·.▐█▌▐▀▀▄.▄█▀▀█.▐█·▐█▐▐▌");
            mls.LogInfo("▐█.▪▐▌▐█▌.▐▌▐█▄█▌▐█▌▐▌██..██.▐█•█▌▐█.▪▐▌▐█▌██▐█");
            mls.LogInfo(".▀..▀..▀█▄▀▪.▀▀▀..▀▀▀.▀▀▀▀▀•..▀..▀.▀..▀.▀▀▀▀▀.█▪");
            mls.LogInfo("AouldsTweaks version " + modVersion + " has successfully loaded.");

            harmony.PatchAll(typeof(AouldsTweaksBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            //harmony.PatchAll(typeof(EnemyReplacerAould));
        }
    }
}
