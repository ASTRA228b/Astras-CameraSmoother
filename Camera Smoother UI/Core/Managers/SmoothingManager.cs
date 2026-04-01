using UnityEngine;
using Liv.Lck.Smoothing;
using Astras_CameraSmoother.Core.Settings;

namespace Astras_CameraSmoother.Core.Managers;

public class SmoothingManager
{
    private Vector3 velocity;
    private readonly KalmanFilter kx = new(0f, 1f);
    private readonly KalmanFilter ky = new(0f, 1f);
    private readonly KalmanFilter kz = new(0f, 1f);

    public Vector3 ApplyKalman(Vector3 raw, float dt)
    {
        if (!SmoothSettings.LivEnabled) return raw;

        return new Vector3(
            kx.Update(raw.x, dt, SmoothSettings.KalmanR),
            ky.Update(raw.y, dt, SmoothSettings.KalmanR),
            kz.Update(raw.z, dt, SmoothSettings.KalmanR)
        );
    }

    public void ApplyMain(Camera cam, Transform target)
    {
        if (!SmoothSettings.MainEnabled || cam == null || target == null) return;

        Transform t = cam.transform;

        t.position = Vector3.SmoothDamp(
            t.position,
            target.position,
            ref velocity,
            SmoothSettings.MainSmooth
        );

        t.rotation = Quaternion.Slerp(
            t.rotation,
            target.rotation,
            Time.deltaTime * SmoothSettings.RotSmooth
        );
    }
}