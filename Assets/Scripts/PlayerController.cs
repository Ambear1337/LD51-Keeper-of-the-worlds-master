using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float inputX;
    float inputY;
    float inputJump;

    private float gravityValue = -9.81f;
    private float speed = 3.0f;

    KeyCode sprint;

    [SerializeField]
    private float walkSpeed = 3.0f;

    [SerializeField]
    private float sprintSpeed = 6.0f;

    [SerializeField]
    private float jumpHeight = 1.0f;

    [SerializeField]
    private float rotationSpeed = 1.0f;

    [SerializeField]
    private Camera followCam;

    bool isMoving = false;
    bool isGrounded = true;
    bool jumped = false;
    bool isSprinted = false;

    Vector3 movementInput;
    Vector3 movementDirection;
    Vector3 velocity;

    public CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerRotation();
    }

    void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        inputJump = Input.GetAxisRaw("Jump");
        isSprinted = Input.GetKey(sprint);
        if (movementInput != Vector3.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void PlayerMovement()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (isGrounded && isSprinted)
        {
            speed = sprintSpeed;
            Debug.Log("Sprinting!");
        }
        else
        {
            speed = walkSpeed;
        }

        movementInput = Quaternion.Euler(0, followCam.transform.eulerAngles.y, 0) * new Vector3(inputX, 0, inputY);
        movementDirection = movementInput.normalized;

        controller.Move(movementDirection * speed * Time.deltaTime);

        if (inputJump != 0 && isGrounded && jumped == false)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        JumpCheck();

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void PlayerRotation()
    {
        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void JumpCheck()
    {
        if (inputJump == 0)
        {
            jumped = false;
        }
        else
        {
            jumped = true;
        }
    }

    public bool GetIsMoving()
    {
        return isMoving;
    }
}
