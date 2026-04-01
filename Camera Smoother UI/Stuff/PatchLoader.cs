using HarmonyLib;

namespace Astras_CameraSmoother.Stuff;

public class PatchLoader
{
    public static void Apply()
    {
        Harmony VALLL = new(Constantss.GUID);
        VALLL.PatchAll();
    }
}