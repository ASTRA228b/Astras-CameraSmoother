using UnityEngine;
// idk im have headache

namespace Astras_CameraSmoother.Core.Managers;

public class MainManager : MonoBehaviour
{
    public Transform? livTarget;
    private Camera? cam;
    private SmoothingManager? smoothing;

    private void Start()
    {
        cam = Camera.main;
        smoothing = new SmoothingManager();
    }

    private void LateUpdate()
    {
        if (livTarget == null || cam == null) return;
        if (smoothing == null) return;
        float dt = Time.deltaTime;
        livTarget.position = smoothing.ApplyKalman(livTarget.position, dt);
        smoothing.ApplyMain(cam, livTarget);
    }
}