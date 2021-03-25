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

    void Start()
    {
        animator = GetComponent<Animator>();
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

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        animator.SetFloat("VelocityX", x);
        animator.SetFloat("VelocityZ", z);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
