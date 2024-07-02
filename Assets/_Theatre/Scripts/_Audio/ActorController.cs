using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> Clips;
    [SerializeField] private AudioSyncScale DRM;

    private AudioSource audioSorce;
    [SerializeField] private int numAudio = 0;
    [SerializeField] private MeshRenderer actorRenderer;


    private void Start()
    {
        //numAudio = 0;
        audioSorce = GetComponent<AudioSource>();
    }

    public void NextSound()
    {
        DRM.enabled = true;
        DRM.play = true;
        if(audioSorce == null)
            audioSorce = GetComponent<AudioSource>();
        if(actorRenderer != null)
            actorRenderer.enabled = true;
        audioSorce.PlayOneShot(Clips[numAudio]);
        numAudio++;
        if (Clips.Count == numAudio)
            numAudio = 0;
    }
}
