using System.Collections;
using System.Collections.Generic;
using _Theatre.Scripts;
using UnityEngine;

public class PerformanceController : MonoBehaviour
{
    void Start()
    {
        SelectController.SelectHandlerEvent += SetUp;
    }

    private void SetUp(GameObject gameObject)
    { 
        gameObject.GetComponent<IInvisibleController>().SetUp();
    }
}
