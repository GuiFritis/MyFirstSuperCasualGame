using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{

    public List<AnimatorSetup> setups;
    public Animator animator;

    public enum AnimationType{
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type){
        foreach(var setup in setups){
            if(setup.type == type){
                animator.SetTrigger(setup.trigger);
            }
        }
    }
}

[System.Serializable]
public class AnimatorSetup{
    public AnimatorManager.AnimationType type;
    public string trigger;
}