using System;
using System.Collections;
using System.Collections.Generic;
using _Theatre.Scripts;
using _Theatre.Scripts.Services;
using UnityEngine;

public class LibraryController : MonoBehaviour
{
    [SerializeField] private GameObject Forest;
    [SerializeField] private GameObject Sun;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private Animator ShowStart;
    
    
    private void Start()
    {
        SelectController.SelectHandlerEvent += StartGame;
    }

    private void StartGame(GameObject gameObject)
    {
        //ShowStart.SetBool("Start",true);
        Canvas.SetActive(false);
        Forest.SetActive(true);
        Sun.SetActive(true);

    }
}
