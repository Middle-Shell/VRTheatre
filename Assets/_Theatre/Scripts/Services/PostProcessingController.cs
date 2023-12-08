using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour
{
    public Volume volume;
    DepthOfField blur;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (volume.profile.TryGet<DepthOfField>(out blur))
        {
            
        }
    }

    void FixedUpdate()
    {
        blur.focusDistance.value = Mathf.PingPong(Time.time, 1);
    }
}
