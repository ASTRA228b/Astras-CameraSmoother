using UnityEngine;
using UnityEngine.InputSystem;
using Astras_CameraSmoother.Core.Settings;
using Astras_CameraSmoother.Core.GUIHelpers;

namespace Astras_CameraSmoother.Core.Controllers;

public class GUIController : MonoBehaviour
{
    // its just simple 
    private Rect window = new(100, 100, 300, 250);
    private bool Open = false;
    private bool SInit = false;

    private void OnGUI()
    {
        if (!SInit)
        {
            GlobalStyles.INIT();
            SInit = true;
        }
        if (Open)
        {
           window = GUILayout.Window(79896754, window, UIM, "Astras CamSmoother", GlobalStyles.WindowStyle);
        }
    }

    private void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            Open = !Open;
        }
    }

    private void UIM(int id)
    {
        Settings();
        GUILayout.Space(10f);
        if (GUILayout.Button("Close", GlobalStyles.Buttonss))
        {
            Open = !Open;
        }
        GUI.DragWindow();
    }

    private void Settings()
    {
        GUILayout.BeginVertical();
        SmoothSettings.MainEnabled = GUILayout.Toggle(SmoothSettings.MainEnabled, "Main Cam Smooth");
        SmoothSettings.LivEnabled = GUILayout.Toggle(SmoothSettings.LivEnabled, "LIV Smooth");
        GUILayout.EndVertical();
        GUILayout.Space(10);
        GUILayout.Label("Main Smooth: " + SmoothSettings.MainSmooth.ToString("F2"));
        SmoothSettings.MainSmooth = GUILayout.HorizontalSlider(SmoothSettings.MainSmooth, 0.01f, 0.5f, GlobalStyles.SliderStyle, GlobalStyles.SliderThumbStyle);
        GUILayout.Label("Rotation Speed: " + SmoothSettings.RotSmooth.ToString("F1"));
        SmoothSettings.RotSmooth = GUILayout.HorizontalSlider(SmoothSettings.RotSmooth, 1f, 25f, GlobalStyles.SliderStyle, GlobalStyles.SliderThumbStyle);
        GUILayout.Space(10);
        GUILayout.Label("Kalman R: " + SmoothSettings.KalmanR.ToString("F0"));
        SmoothSettings.KalmanR = GUILayout.HorizontalSlider(SmoothSettings.KalmanR, 1f, 200f, GlobalStyles.SliderStyle, GlobalStyles.SliderThumbStyle);

    }
}