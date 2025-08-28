using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private PlayerInput playerInput;

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
        float targetSpeed = moveInput.x * speed;
        rigidbody.linearVelocity = new Vector2 (targetSpeed, rigidbody.linearVelocity.y);
        Vector3 gravity = gravityForce * gravityScale * Vector3.down;
        rigidbody.AddForce(gravity, ForceMode.Acceleration);

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
        moveInput = value.Get<Vector2>();
        Flip();
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded)
        {
        rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, jumpForce);
        }
    }


}
