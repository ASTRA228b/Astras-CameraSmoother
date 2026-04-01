using UnityEngine;

namespace Astras_CameraSmoother.Core.GUIHelpers;

public static class GlobalStyles
{
    // the stuff that is used ouside of this script
    public static GUIStyle? WindowStyle, SliderStyle, SliderThumbStyle, Buttonss;

    // stuff only used inside
    private static Texture2D? Windowtex, Background, Slidertex, SliderThumbtex;
    private static Color WindowColor = new(0.1f, 0.1f, 0.1f, 1f);
    private static Color sliderTrackColor = new(0.15f, 0.15f, 0.15f, 1f);
    private static Color sliderThumbColor = new(0.0f, 0.6f, 1f, 1f);
    private static Color ButtonColor = new(0.2f, 0.2f, 0.2f, 1f);

    // the thing we call in ongui (me head hurts)
    public static void INIT()
    {
        Windowtex = Texturing.MakeItWork(1, 1, WindowColor);
        Slidertex = Texturing.MakeItWork(1, 1, sliderTrackColor);
        SliderThumbtex = Texturing.MakeItWork(1, 1, sliderThumbColor);
        Background = Texturing.MakeItWork(1, 1, ButtonColor);
        WindowStyle = new GUIStyle(GUI.skin.window);
        Buttonss = new GUIStyle(GUI.skin.button);
        SliderStyle = new GUIStyle(GUI.skin.horizontalSlider);
        SliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb);
        SliderStyle.normal.background = Slidertex;
        SliderStyle.active.background = Slidertex;
        SliderStyle.hover.background = Slidertex;
        SliderThumbStyle.normal.background = SliderThumbtex;
        SliderThumbStyle.active.background = SliderThumbtex;
        SliderThumbStyle.hover.background = SliderThumbtex;
        WindowStyle.normal.textColor = Color.white;
        WindowStyle.fontStyle = FontStyle.Normal;
        Buttonss.normal.textColor = Color.white;
        Buttonss.hover.textColor = Color.blue;
        Buttonss.active.textColor = Color.red;
        Buttonss.focused.textColor = Color.white;
        Buttonss.onNormal.textColor = Color.blue;
        Buttonss.onHover.textColor = Color.blue;
        Buttonss.onActive.textColor = Color.blue;
        Buttonss.onFocused.textColor = Color.blue;
        // only used for buttons and windows 
        ApplyBackground(Buttonss, Background);
        ApplyBackground(WindowStyle, Windowtex);
    }
    public static void ApplyBackground(GUIStyle style, Texture2D tex)
    {
        style.normal.background = tex;
        style.hover.background = tex;
        style.active.background = tex;
        style.focused.background = tex;
        style.onNormal.background = tex;
        style.onHover.background = tex;
        style.onActive.background = tex;
        style.onFocused.background = tex;
    }
}