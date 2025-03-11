using UnityEngine;
using System.Collections;

public class AudioScript : StateMachineBehaviour
{
    private AudioSource[] audio;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get access to GetComponentsInParent, this will return an array
        audio = animator.GetComponentsInParent<AudioSource>();
        // Play audio file at index 0 (walking)
        audio[0].Play();
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop audio file[0] (walking)
        audio[0].Stop();
    }
}


