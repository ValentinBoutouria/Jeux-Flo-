using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class setInputDelay : StandaloneInputModule
{
    public float delay = 0.3f;
    private float lastTime = 0;

    public override void Process()
    {
        if (Time.unscaledTime - lastTime < delay)
        {
            return;
        }
        lastTime = Time.unscaledTime;
        base.Process();
    }
}

