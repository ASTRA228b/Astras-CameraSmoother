using BepInEx;
using UnityEngine;
using Astras_CameraSmoother.Stuff;
using Astras_CameraSmoother.Core.Managers;
using Astras_CameraSmoother.Core.Controllers;

namespace Astras_GUI_Template.Plugin;

[BepInPlugin(Constantss.GUID, Constantss.Name, Constantss.Version)]
public class Plugin : BaseUnityPlugin
{
    private void Start()
    {
        PatchLoader.Apply();
    }

    private void Awake()
    {
        GameObject Plugin = new(Constantss.ObjectName);
        Plugin.AddComponent<GUIController>();
        Plugin.AddComponent<MainManager>();
        DontDestroyOnLoad(Plugin);
    }
}