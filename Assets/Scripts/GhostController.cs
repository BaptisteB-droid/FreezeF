using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class GhostController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private FreezeFrame freezeFrame;
    [SerializeField] private PlayerController player;

    private Vector2 moveInput;
    private bool facingForward = true;

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

    [Header("Rewind")]
    public List<Vector3> positions = new List<Vector3>();
    private bool isRecord = false;

    void Start()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

    private void RecordMove()
    {
        positions.Add(transform.position);
    }

    public void checkGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FixedUpdate()
    {
        if(!player.isRewinding)
        {
            float targetSpeed = moveInput.x * speed;
            rigidbody.linearVelocity = new Vector2(targetSpeed, rigidbody.linearVelocity.y);
            Vector3 gravity = gravityForce * gravityScale * Vector3.down;
            rigidbody.AddForce(gravity, ForceMode.Acceleration);

            checkGrounded();
        }

        if (player.isRecording)
        {
            RecordMove();
        }

    }

    void Flip()
    {
        if (moveInput.x > 0.1f)
        {
            facingForward = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < -0.1f)
        {
            facingForward = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }


    public void OnMove(InputValue value)
    {
        if (!player.isRewinding)
        {
            moveInput = value.Get<Vector2>();
            Flip();
        }

    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, jumpForce);
        }
    }
}
