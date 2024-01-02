//using BepInEx;
//using HarmonyLib;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;
//using LC_API.BundleAPI;

//namespace AouldsTweaks.Patches
//{
//    [HarmonyPatch]
//    internal class EnemyReplacerAould
//    {
//        [HarmonyPatch(typeof(FlowermanAI), "Start")]
//        [HarmonyPostfix]
//        [HarmonyPatch]public static void SummonHerobrine(FlowermanAI __instance)
//        {
//            __instance.creatureAngerVoice.clip = BundleLoader.GetLoadedAsset<AudioClip>("hb/assets/assets/CaveAngry.mp3");
//            __instance.crackNeckSFX = BundleLoader.GetLoadedAsset<AudioClip>("hb/assets/assets/KillSound.mp3");
//            __instance.crackNeckAudio.clip = BundleLoader.GetLoadedAsset<AudioClip>("hb/assets/assets/KillSound.mp3");
//            Object.Destroy((Object)(object)((Component)((Component)__instance).gameObject.transform.Find("FlowermanModel").Find("LOD1")).gameObject.GetComponent<SkinnedMeshRenderer>());
//            GameObject val = Object.Instantiate<GameObject>(BundleLoader.GetLoadedAsset<GameObject>("hb/assets/assets/herobrine.prefab"), ((Component)__instance).gameObject.transform);
//            val.transform.localPosition = new Vector3(0f, 1.5f, 0f);
//        }
//    }
//}
