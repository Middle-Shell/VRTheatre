using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorsAudioController : MonoBehaviour
{
    [SerializeField] private List<ActorController> Actors;

    public void Babki()
    {
        Actors[0].NextSound();
    }

    public void OldWoman()
    {
        Actors[1].NextSound();
    }

    public void YoungLady()
    {
        Actors[2].NextSound();
    }

    public void OldMan()
    {
        Actors[3].NextSound();
    }
    
    public void ThirdBlind()
    {
        Actors[4].NextSound();
    }

    public void SecondBlind()
    {
        Actors[5].NextSound();
    }

    public void FirstBlind()
    {
        Actors[6].NextSound();
    }
}
