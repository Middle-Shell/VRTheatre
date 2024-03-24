using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> Clips;

    private AudioSource audioSorce;
    private int numAudio;


    private void Start()
    {
        numAudio = 0;
        audioSorce = GetComponent<AudioSource>();
    }

    public void NextSound()
    {
        audioSorce.PlayOneShot(Clips[numAudio]);
        numAudio++;
    }
}
