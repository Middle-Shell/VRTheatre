using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateResetPosition : MonoBehaviour
{

    
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector3 position;
    private Coroutine res;


    private void Start()
    {
		
        //position = transform.localPosition;
    }

    /*public void Update()
    {
        
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            position, speed * Time.deltaTime);

    }*/
    public void Drop()
    {
        if( res == null)
            res = StartCoroutine(Reset());
    }
    IEnumerator  Reset()
    {
        while (Vector3.Distance(transform.InverseTransformPoint(transform.position),position) > 0.01)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                position, speed * Time.deltaTime);
            yield return null;
        }
        
    }
}
