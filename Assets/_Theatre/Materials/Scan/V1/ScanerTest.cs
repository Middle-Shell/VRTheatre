using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScanerTest : MonoBehaviour
{
    public Material ScanMat;
    private Vector3 scanObj;
    private void OnRenderImage(RenderTexture cameraView, RenderTexture shaderView)
    
    {
        Graphics.Blit(cameraView,shaderView,ScanMat,0);    
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Scaning());
        }
    }

    public IEnumerator Scaning()
    {
        float Timer = 0;
        float Range = 0;
        float Opacity = 0;
        scanObj = this.transform.position;
        ScanMat.SetVector("_Position",scanObj);
        while (true)
        {
            Timer += Time.deltaTime;
            if (Timer <= 1)
            {
                Range = Mathf.Lerp(0, 100, Timer);
                Opacity = Mathf.Lerp(1, 0, Timer);
                ScanMat.SetFloat("_Range",Mathf.Lerp(0, 50, Timer/3));
                ScanMat.SetFloat("_Opacity",Mathf.Lerp(2, 1f, Timer/2));

            }
            else
                yield break;
            yield return null;
        }
            
    }
    
}
