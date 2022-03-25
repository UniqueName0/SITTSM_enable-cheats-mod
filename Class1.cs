using BepInEx;
using HarmonyLib;
using UnityEngine;
using System;
using System.Reflection;
using HarmonyLib.Tools;
using BepInEx.Harmony;

namespace enable_cheats
{
    [BepInProcess("Stick It To The (Stick) Man.exe")]
    [BepInPlugin("uniquename.sittsm.enable-cheats", "enable-cheats", "0.0.0.0")]
    public class cheats_enable : BaseUnityPlugin
    {

        public void Awake()
        {
            var harmony = new Harmony("uniquename.sittsm.enable-cheats");
            harmony.PatchAll();
        }

        public const string modID = "uniquename.sittsm.enable-cheats";
        public const string modName = "enable-cheats";
    }

    [HarmonyPatch(typeof(Application), "get_isEditor")]
    public class IsEditor_patch
    {
        public static bool Prefix(ref bool __result)
        {
            __result = true;
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "SetUpPlayers")]
    public class Is2player_patch
    {
        public static bool Prefix(ref bool __test2Players)
        {
            __test2Players = false;
            return true;
        }
    }
}
