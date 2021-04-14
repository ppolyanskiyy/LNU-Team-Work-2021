using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] private float turnSmoothTime = 0.1f;

    [SerializeField] private Transform thirdPlayerCamera;

    Vector3 velocity;
    Animator animator;

    float turnSmoothVelocity;
    float timeInAir = 0.0f;
    float timeAfterGround = 0.0f;
    float waitAfterGround = 0.25f;

    bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
    }

    void ThirdPlayerMove(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + thirdPlayerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (horizontal == 0 && vertical == 0)
            {
                animator.SetBool("StayRotationX", true);
                float mouseX = Input.GetAxis("Mouse X") * 1000f * Time.deltaTime;
                animator.SetFloat("VelocityX", mouseX, 0.1f, Time.deltaTime);
            }
            else if (horizontal != 0 || vertical != 0 || (horizontal != 0 && vertical != 0))
            {
                animator.SetBool("StayRotationX", false);
                animator.SetFloat("VelocityX", horizontal, 0.1f, Time.deltaTime);
                animator.SetFloat("VelocityZ", vertical, 0.1f, Time.deltaTime);
            }
        }

        ThirdPlayerMove(horizontal, vertical);

        JumpAnimation();
    }

    void JumpAnimation()
    {
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
                animator.SetInteger("Jumping", 1);
        }
        else
        {
            if (timeAfterGround < waitAfterGround)
                timeAfterGround += Time.deltaTime;
            else
                timeAfterGround = waitAfterGround + 0.1f;

            timeInAir = 0.0f;
            animator.SetInteger("Jumping", 0);
        }
    }
}
