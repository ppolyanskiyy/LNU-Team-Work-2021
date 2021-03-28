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

    Vector3 velocity;
    bool isGrounded;
    Animator animator;
    float timeInAir = 0.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded)
        {
            if (x == 0 && z == 0)
            {
                animator.SetBool("StayRotationX", true);
                float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
                animator.SetFloat("VelocityX", mouseX, 0.1f, Time.deltaTime);
            }
            else if (x != 0 || z != 0 || (x != 0 && z != 0))
            {
                animator.SetBool("StayRotationX", false);
                animator.SetFloat("VelocityX", x, 0.1f, Time.deltaTime);
                animator.SetFloat("VelocityZ", z, 0.1f, Time.deltaTime);
            }  
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            timeInAir = 0.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetInteger("Jumping", 2);
        }
        else if (!isGrounded)
        {
            timeInAir += Time.deltaTime;
            if (timeInAir > 0.4f)
            {
                animator.SetInteger("Jumping", 1);
            }
        }
        else
        {
            timeInAir = 0.0f;
            animator.SetInteger("Jumping", 0);
        }
    }
}


//void Update()
//{
//    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

//    if(isGrounded && velocity.y < 0)
//    {
//        velocity.y = -2f;
//    }
//    float x = Input.GetAxis("Horizontal");
//    float z = Input.GetAxis("Vertical");
//    if (Input.GetKey(KeyCode.W))
//    {
//        animator.SetInteger("WalkForward", 1);
//    }
//    if (Input.GetKeyUp(KeyCode.W))
//    {
//        animator.SetInteger("WalkForward", 0);
//    }

//    Vector3 move = transform.right * x + transform.forward * z;
//    controller.Move(move * speed * Time.deltaTime);

//    if(Input.GetButtonDown("Jump") && isGrounded)
//    {
//        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//    }

//    velocity.y += gravity * Time.deltaTime;

//    controller.Move(velocity * Time.deltaTime);
//}

//void Update()
//{
//    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

//    if (isGrounded && velocity.y < 0)
//    {
//        velocity.y = -2f;
//    }

//    float x = Input.GetAxis("Horizontal");
//    float z = Input.GetAxis("Vertical");

//    Vector3 move = new Vector3(x, 0f, z);

//    if (move.magnitude > 0)
//    {
//        move.Normalize();
//        move *= speed * Time.deltaTime;
//        transform.Translate(move, Space.World);
//    }

//    float velocityX = Vector3.Dot(move.normalized, transform.right);
//    float velocityZ = Vector3.Dot(move.normalized, transform.forward);

//    animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
//    animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
//}