using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimations : MonoBehaviour
{

    public Animator animator;
    public ActivateNPC activateNpc;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateNpc.isTalking)
        {
            animator.SetBool("IsTalking", true);
        }
        
        if (!activateNpc.isTalking)
        {
            animator.SetBool("IsTalking", false);
        }
    }
}
