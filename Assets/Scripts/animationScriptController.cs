using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScriptController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    int isJumpingHash;
    int isSlidingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Debug.Log(animator);

        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isSlidingHash = Animator.StringToHash("isSliding");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool jumpPressed = Input.GetKey(KeyCode.Space);
        bool slidePressed = Input.GetKey(KeyCode.LeftControl);

        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isSliding = animator.GetBool(isSlidingHash);

        // If W is pressed
        if(forwardPressed && !isRunning && !isJumping)
        {
            // set boolean to be true
            animator.SetBool(isRunningHash, true);
        }
        else if(!forwardPressed && isRunning) // if not then set boolean false
            animator.SetBool(isRunningHash, false);

        if (forwardPressed && isRunning && jumpPressed && !isJumping)
            animator.SetBool(isJumpingHash, true);
        else if (forwardPressed && isRunning && !jumpPressed)
            animator.SetBool(isJumpingHash, false);

        if (forwardPressed && isRunning && slidePressed && !isSliding)
            animator.SetBool(isSlidingHash, true);
        else if (forwardPressed && isRunning && !slidePressed)
            animator.SetBool(isSlidingHash, false);
    }
}
