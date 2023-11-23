using System;
using System.Collections;
using System.Collections.Generic;
using _Theatre.Scripts;
using _Theatre.Scripts.Services;
using UnityEngine;

public class LibraryController : MonoBehaviour
{
    private void Start()
    {
        SelectController.SelectHandlerEvent += MakeChoice;
    }

    private void MakeChoice(GameObject gameObject)
    {
        var type = gameObject.GetComponent<IImageController>().GetType();
        gameObject.layer = 0;
        SaveController.SaveObject(type);
        
        //--------------------------------------------
        print(PlayerPrefs.GetString(type.GetType().ToString()));
        /*ForestType.TryParse(B, out ForestType _type);
        print(_type);*/
        
    }
}
