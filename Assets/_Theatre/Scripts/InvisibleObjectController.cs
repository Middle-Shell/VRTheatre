using System.Collections;
using System.Collections.Generic;
using _Theatre.Scripts;
using UnityEngine;

public class InvisibleObjectController : MonoBehaviour, IInvisibleController
{
    [SerializeField] private GameObject _targetObject;
    
    public void SetUp()
    {
        _targetObject.SetActive(true);
    }
}
