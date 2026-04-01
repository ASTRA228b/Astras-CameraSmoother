namespace Astras_CameraSmoother.Core.Settings;

public static class SmoothSettings
{
    public static float MainSmooth = 0.1f;
    public static float RotSmooth = 10f;

    public static float KalmanR = 99f;

    public static bool MainEnabled = true;
    public static bool LivEnabled = true;
}