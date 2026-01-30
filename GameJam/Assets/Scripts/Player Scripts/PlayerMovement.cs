using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isFacingLeft = false;

    // Input System
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get Input System
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float horizontal = moveInput.x;

        if (horizontal > 0f)
        {
            if (isFacingLeft)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
            isFacingLeft = true;
        }
        else if (horizontal < 0f)
        {
            if (!isFacingLeft)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
            isFacingLeft = false;
        }
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        bool isJumpHeld = jumpAction.IsPressed();

        if (isJumpHeld && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (jumpAction.WasReleasedThisFrame() && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}