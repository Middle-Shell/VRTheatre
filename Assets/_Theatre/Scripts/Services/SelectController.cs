using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Vector3 _rayStartPosition = new(Screen.width/2, Screen.height/2, 0);
    public LayerMask layerMask;
    private GameObject _currentHit = null;
    
    public delegate void SelectHandler(GameObject gameObject);
    public static event SelectHandler SelectHandlerEvent;

    private void OnSelectHandler(GameObject gameObject)
    {
        SelectHandlerEvent?.Invoke(gameObject);
    }

    private void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        StartCoroutine(ReleaseRay());
    }
    
    IEnumerator ReleaseRay ()
    {
        Ray ray = _camera.ScreenPointToRay(_rayStartPosition);
        
        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red);
        
        Physics.Raycast(ray, out var firstHit, Mathf.Infinity, layerMask);

        if (firstHit.transform == null)
            yield break;
        
        if (firstHit.transform.gameObject == _currentHit)
            yield break;
        
        _currentHit = firstHit.transform.gameObject;
        
        yield return new WaitForSeconds(3f);
        
        ray = _camera.ScreenPointToRay(_rayStartPosition);
        Physics.Raycast(ray, out var secondHit, Mathf.Infinity, layerMask);
        
        if(secondHit.transform == null)
            yield break;
        
        if (firstHit.transform.gameObject == secondHit.transform.gameObject)
            OnSelectHandler(secondHit.transform.gameObject);
            //secondHit.transform.GetComponent<InvisibleObjectController>()?.SetUp();
    }
}
