using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private FreezeFrame freezeFrame;
    [SerializeField] private GhostController ghost;

    private Vector2 moveInput;
    private bool facingForward = true;
    public bool isRewinding = false;
    public bool isRecording = false;

    [Header("Movement")]
    public float speed;
    public float jumpForce;

    [Header("GroundCheck")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    [Header("Gravity")]
    public float gravityScale;
    public float gravityForce;


    private void Update()
    {
        checkGrounded();
    }


    public void checkGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FixedUpdate()
    {
        if (!isRewinding && !isRecording)
        {
            float targetSpeed = moveInput.x * speed;
            rigidbody.linearVelocity = new Vector2 (targetSpeed, rigidbody.linearVelocity.y);
            Vector3 gravity = gravityForce * gravityScale * Vector3.down;
            rigidbody.AddForce(gravity, ForceMode.Acceleration);
        }
        if (isRewinding && !isRecording)
        {
            Rewind();
        }
    }

    void Rewind()
    {
        if (ghost.positions.Count > 0)
        {
            transform.position = ghost.positions[0];
            ghost.positions.RemoveAt(0);
        }
        else if(ghost.positions.Count == 0)
        {
            isRewinding = false;
            rigidbody.linearVelocity = new Vector3(0, 0, 0);
            transform.position = ghost.transform.position;
        }
    }


    void Flip()
    {
        if (moveInput.x > 0.1f && !freezeFrame.isFreeze && !isRewinding && !isRecording)
        {
            facingForward = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < -0.1f && !freezeFrame.isFreeze && !isRewinding && !isRecording)
        {
            facingForward = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }


    public void OnMove(InputValue value)
    {
        if (!freezeFrame.isFreeze && !isRewinding && !isRecording)
        {
            moveInput = value.Get<Vector2>();
            Flip();
        }

    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded && !freezeFrame.isFreeze && !isRewinding && !isRecording)
        {
        rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, jumpForce);
        }
    }

    public void OnFreeze(InputValue value)
    {
        if (!isRewinding)
        {
            freezeFrame.Freeze();

            if (isRecording && !freezeFrame.isFreeze)
            {
                isRewinding = true;
                isRecording = false;
            }
            else
            {
                isRecording = true;
            }

            rigidbody.linearVelocity = new Vector3(0, 0, 0);
        }
    }
}
