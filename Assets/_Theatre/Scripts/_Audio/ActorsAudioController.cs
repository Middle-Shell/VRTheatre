using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorsAudioController : MonoBehaviour
{
    [SerializeField] private List<ActorController> actors;
    [SerializeField] private int blockI;
    

    public void Babki()
    {
        actors[0].NextSound();
    }

    public void OldWoman()
    {
        actors[1].NextSound();
    }

    public void YoungLady()
    {
        actors[2].NextSound();
    }

    public void OldMan()
    {
        actors[3].NextSound();
    }
    
    public void ThirdBlind()
    {
        actors[4].NextSound();
    }

    public void SecondBlind()
    {
        actors[5].NextSound();
    }

    public void FirstBlind()
    {
        actors[6].NextSound();
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
