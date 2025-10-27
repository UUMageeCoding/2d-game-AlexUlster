using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; 
    public Animator animator;
    public float walkSpeed = 10f;

    public float sprintJump = 0;
    public float sprintJumpBost = 0f;

    float horizontalMove = 0f;
    bool jump = false;

    private void Start()
    {
        sprintJump = controller.m_JumpForce;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftShift))
        {
   
            horizontalMove *= 2f;
            controller.m_JumpForce = sprintJump * sprintJumpBost;       
            animator.SetBool("IsRunning", true);
        }
        else
        {
            controller.m_JumpForce = sprintJump;
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
