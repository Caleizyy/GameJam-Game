using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isFacingLeft = false;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x != 0f && !GameManager.IsGamePaused)
        {
            if (!isFacingLeft && moveInput.x > 0f)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                isFacingLeft = true;
            }
            else if (isFacingLeft && moveInput.x < 0f)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                isFacingLeft = false;
            }
        }
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

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
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }  
}