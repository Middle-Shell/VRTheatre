using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorsAudioController : MonoBehaviour
{
    [SerializeField] private List<ActorController> actors;
    [SerializeField] private List<AudioSyncScale> actorsDRM;
    [SerializeField] private int blockI;
    

    public void Babki()
    {
        StopPLayAll();
        actorsDRM[0].enabled = true;
        actorsDRM[0].play = true;
        actors[0].NextSound();
    }

    public void OldWoman()
    {
        StopPLayAll();
        actorsDRM[1].enabled = true;
        actorsDRM[1].play = true;
        actors[1].NextSound();
    }

    public void YoungLady()
    {
        StopPLayAll();
        actorsDRM[2].enabled = true;
        actorsDRM[2].play = true;
        actors[2].NextSound();
    }

    public void OldMan()
    {
        StopPLayAll();
        actorsDRM[3].enabled = true;
        actorsDRM[3].play = true;
        actors[3].NextSound();
    }
    
    public void ThirdBlind()
    {
        StopPLayAll();
        actorsDRM[4].enabled = true;
        actorsDRM[4].play = true;
        actors[4].NextSound();
    }

    public void SecondBlind()
    {
        StopPLayAll();
        actorsDRM[5].enabled = true;
        actorsDRM[5].play = true;
        actors[5].NextSound();
    }

    public void FirstBlind()
    {
        StopPLayAll();
        actorsDRM[6].enabled = true;
        actorsDRM[6].play = true;
        actors[6].NextSound();
    }
    public void SixthBlind()
    {
        StopPLayAll();
        actorsDRM[7].enabled = true;
        actorsDRM[7].play = true;
        actors[7].NextSound();
    }

    private void StopPLayAll()
    {
        foreach (AudioSyncScale element in actorsDRM)
        {
            if(element.play)
                element.play = false;
        }
    }

    public void NextBlock()
    {
        var animator = this.GetComponent<Animator>();
        print(blockI);
        switch (blockI)
        {
            case 0:
                animator.SetBool("Block1", true);
                print(1);
                blockI++;
                break;
            case 1:
                animator.SetBool("Block2", true);
                print(2);
                blockI++;
                break;
            case 2:
                animator.SetBool("Block3", true);
                blockI++;
                break;
            case 3:
                animator.SetBool("Block4", true);
                blockI++;
                break;
            case 4:
                animator.SetBool("Block5", true);
                blockI++;
                break;
            case 5:
                break;
        }
        
    }
}
