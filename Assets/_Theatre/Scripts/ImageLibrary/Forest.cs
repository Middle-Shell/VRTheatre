using System;
using System.Collections;
using System.Collections.Generic;
using _Theatre.Scripts;
using UnityEngine;

public class Forest : MonoBehaviour, IImageController
{
    [SerializeField] private ForestType _forestType;

    public new Enum GetType()
    {
        return _forestType;
    }
}
