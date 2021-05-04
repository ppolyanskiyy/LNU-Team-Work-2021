using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    public float jumpHeight = 3f;
    public float gravity = 9.8f;
    public float stepDown = 0.1f;
    public float airControl = 2.5f;
    public float jumpDamp = 0.8f;
    public float speed = 1;

    CharacterController controller;
    Animator animator;
    Vector2 input;

    Vector3 rootMotion;
    Vector3 velocity;
    bool isJumping;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", input.x, 0.1f, Time.deltaTime);
        animator.SetFloat("InputY", input.y, 0.1f, Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void OnAnimatorMove()
    {
        rootMotion += animator.deltaPosition; // disable ability of the player to move by root motion
    }
    private void FixedUpdate()
    {
        if (isJumping) // of in the air
        {
            UpdateInAir();
        }
        else
        {
            UpdateOnGround();
        }
    }
    private void UpdateOnGround()
    {
        Vector3 stepForwardAmount = rootMotion * speed;
        Vector3 stepDownAmount = Vector3.down * stepDown;
        controller.Move(stepForwardAmount + stepDownAmount);
        rootMotion = Vector3.zero;


        if (!controller.isGrounded)
        {
            isJumping = true;
            velocity = animator.velocity * jumpDamp * speed;
            velocity.y = 0;
            animator.SetBool("isJumping", true);
        }
    }

    private void UpdateInAir()
    {
        velocity.y -= gravity * Time.fixedDeltaTime;
        Vector3 displacement = velocity * Time.fixedDeltaTime;
        displacement += AirControl();
        controller.Move(displacement);
        isJumping = !controller.isGrounded;
        rootMotion = Vector3.zero;
        animator.SetBool("isJumping", isJumping);
    }

    void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            velocity = animator.velocity * jumpDamp;
            velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight);
            animator.SetBool("isJumping", true);
        }
    }
    Vector3 AirControl()
    {
        return ((transform.forward * input.y) + (transform.right * input.x)) * airControl / 100;
    }
}
