using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class FrameOverTime : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startLifetimeMultiplier = 2.0f;

        var tex = ps.textureSheetAnimation;
        tex.enabled = true;
        tex.numTilesX = 4;
        tex.numTilesY = 2;

        // A simple ping-pong curve.
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, 0.0f);
        curve.AddKey(0.5f, 1.0f);
        curve.AddKey(1.0f, 0.0f);

        // Apply the curve.
        tex.frameOverTime = new ParticleSystem.MinMaxCurve(1.0f, curve);
    }
}

