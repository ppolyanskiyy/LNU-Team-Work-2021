using UnityEngine;


using Photon.Pun;

public class PlayerAnimatorManager : MonoBehaviourPun
{
    #region Private Fields
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    Animator animator;
    float timeInAir = 0.0f;
    float timeAfterGround = 0.0f;
    float waitAfterGround = 0.25f;

    #endregion

    #region MonoBehaviour CallBacks
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Prevent control is connected to Photon and represent the localPlayer
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //if (isGrounded)
        //{
        //    if (x == 0 && z == 0)
        //    {
        //        animator.SetBool("StayRotationX", true);
        //        float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
        //        animator.SetFloat("VelocityX", mouseX, 0.1f, Time.deltaTime);
        //    }
        //    else if (x != 0 || z != 0 || (x != 0 && z != 0))
        //    {
        //        animator.SetBool("StayRotationX", false);
        //        animator.SetFloat("VelocityX", x, 0.1f, Time.deltaTime);
        //        animator.SetFloat("VelocityZ", z, 0.1f, Time.deltaTime);
        //    }
        //}
        if (isGrounded)
        {
            if (x == 0 && z == 0)
            {
                float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
                animator.SetFloat("VelocityX", mouseX, 0.1f, Time.deltaTime);
                animator.SetFloat("VelocityZ", 0f, 0.1f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("VelocityZ", z, 0.1f, Time.deltaTime);
                animator.SetFloat("VelocityX", x, 0.1f, Time.deltaTime);
            }
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && timeAfterGround > waitAfterGround)
        {
            timeAfterGround = 0.0f;
            timeInAir = 0.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetInteger("Jumping", 2);
        }
        else if (!isGrounded)
        {
            timeInAir += Time.deltaTime;
            if (timeInAir > 0.5f)
            {
                animator.SetInteger("Jumping", 1);
            }
        }
        else
        {
            if (timeAfterGround < waitAfterGround)
            {
                timeAfterGround += Time.deltaTime;
            }
            else
            {
                timeAfterGround = waitAfterGround + 0.1f;
            }
            timeInAir = 0.0f;
            animator.SetInteger("Jumping", 0);
        }
    }
    #endregion
}
