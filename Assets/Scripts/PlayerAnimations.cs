using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    public spiralMinigameHandler minigame;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (minigame.minigameOn)
        {
            animator.SetBool("SpiralMinigameOn", true);
            animator.SetFloat("SpinSpeed", minigame.spinSpeed);
        }
        else
        {
            animator.SetBool("SpiralMinigameOn", false);
        }
        
    }
}
