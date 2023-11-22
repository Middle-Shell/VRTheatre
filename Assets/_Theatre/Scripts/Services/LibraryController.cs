using System;
using System.Collections;
using System.Collections.Generic;
using _Theatre.Scripts;
using UnityEngine;

public class LibraryController : MonoBehaviour
{
    private void Start()
    {
        SelectController.SelectHandlerEvent += MakeChoice;
    }

    private void MakeChoice(GameObject gameObject)
    {
        print(gameObject.GetComponent<IImageController>().GetType());
    }
}
