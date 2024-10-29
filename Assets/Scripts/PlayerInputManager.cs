using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private Rigidbody bottleRigidbody;
    [SerializeField]
    private float jumpForce = 10.0f;
    [SerializeField]
    private float doubleJumpForce = 3.0f;
    [SerializeField]
    private float forwardForce = 10.0f;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private bool canDoubleJump = false;

    private Animator animator;
    private string flipAnimation = "Take001";

    


    void Start()
    {
        bottleRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position,Vector3.down,0.6f);

        if (isGrounded)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FlipAnimation(1);
                Jump(jumpForce);
                canDoubleJump = true;
            }
            
        }
        else if (canDoubleJump)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FlipAnimation(2);
                Jump(doubleJumpForce);
                canDoubleJump = false;
            }
        }
        if (IsAnimationFinished()) animator.SetInteger("Flip", 0);

    }

    bool IsAnimationFinished()
    {
        // Get the current state of the animation
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Check if the current state is the one you want to check
        if (stateInfo.IsName(flipAnimation))
        {
            // Check if the normalized time is equal to or greater than 1.0
            if (stateInfo.normalizedTime >= 1.0f)
            {
                return true;
            }
        }

        return false;
    }

    private void Jump(float force) => bottleRigidbody.velocity = new Vector3(forwardForce, force, 0);

    private void FlipAnimation(int flip) => animator.SetInteger("Flip", flip);


    //PlayerInputManager player = new PlayerInputManager();

    

}
