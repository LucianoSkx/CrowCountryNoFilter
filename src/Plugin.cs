using System;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace CamEffectOff
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "luciano.crowcountry.camoff";
        public const string NAME = "CrowCountryCamEffectOff";
        public const string VERSION = "1.8";

        public static ConfigEntry<bool> Disable;
        internal static BepInEx.Logging.ManualLogSource Log;
        internal static readonly System.Collections.Generic.HashSet<string> Hits =
            new System.Collections.Generic.HashSet<string>();

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo("[camoff] Awake entered");
            try
            {
                Disable = Config.Bind("Cam Effect", "Disable All Filters", true,
                    "Desliga os efeitos de camera (CRT/PSX/SFB/grain/noise).");
                Log.LogInfo($"[camoff] config bound = {Disable.Value}");

                var harmony = new Harmony(GUID + ".instance");
                harmony.PatchAll(typeof(Plugin).Assembly);
                Log.LogInfo("[camoff] patches applied");
            }
            catch (Exception e)
            {
                Log.LogError($"[camoff] FALHOU: {e}");
            }
        }

        internal static bool BlitThrough(string who, MonoBehaviour instance, object[] args)
        {
            if (!Disable.Value) return true;
            if (Hits.Add(who))
                Log.LogInfo($"[camoff] {who} -> blit");
            if (instance != null) instance.enabled = false;
            var src = args.Length > 0 ? args[0] as RenderTexture : null;
            var dst = args.Length > 1 ? args[1] as RenderTexture : null;
            if (src != null && dst != null) Graphics.Blit(src, dst);
            return false;
        }

        internal static bool Skip(string who)
        {
            if (!Disable.Value) return true;
            if (Hits.Add(who)) Log.LogInfo($"[camoff] {who} -> skipped");
            return false;
        }
    }

    [HarmonyPatch(typeof(com.sfbgames.crowcountry.CrowCountryCamEffect), "OnRenderImage")]
    internal static class CamRenderImage
    {
        private static bool Prefix(MonoBehaviour __instance, object[] __args)
            => Plugin.BlitThrough("CamEffect.OnRenderImage", __instance, __args);
    }

    [HarmonyPatch(typeof(PSXEffects), "OnRenderImage")]
    internal static class PsxRenderImage
    {
        private static bool Prefix(MonoBehaviour __instance, object[] __args)
            => Plugin.BlitThrough("PSXEffects.OnRenderImage", __instance, __args);
    }

    [HarmonyPatch(typeof(PSXEffects), "Update")]
    [HarmonyPatch(typeof(PSXEffects), "UpdateProperties")]
    internal static class PsxStages
    {
        private static void Postfix(MonoBehaviour __instance)
        {
            if (Plugin.Hits.Add("PSXEffects:" + __instance.gameObject.name))
                Plugin.Log.LogInfo($"[camoff] PSXEffects '{__instance.gameObject.name}' enabled={__instance.enabled}");
            if (Plugin.Disable.Value) __instance.enabled = false;
        }
    }

    [HarmonyPatch(typeof(CRTEffect), "OnRenderImage")]
    internal static class CrtRenderImage
    {
        private static bool Prefix(MonoBehaviour __instance, object[] __args)
            => Plugin.BlitThrough("CRTEffect.OnRenderImage", __instance, __args);
    }

    [HarmonyPatch(typeof(BaseCRTEffect), "OnPostRender")]
    [HarmonyPatch(typeof(BaseCRTEffect), "InternalPreRender")]
    internal static class BaseCrtStages
    {
        private static bool Prefix() => Plugin.Skip("BaseCRTEffect");
    }
}