using UnityEngine;

namespace Astras_CameraSmoother.Core.GUIHelpers;

public static class Texturing
{
    public static Texture2D MakeItWork(int ww, int hh, Color color)
    {
        var tex = new Texture2D(ww, hh);
        tex.SetPixel(0, 0, color);
        tex.Apply();
        return tex;
    }
}