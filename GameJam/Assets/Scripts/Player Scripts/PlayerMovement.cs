
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump_height;
    private Rigidbody2D rigid_body_player;
    public bool isGrounded = false; //Logic for this is in grounded_check_script
    private bool isGroundedCopy = false;
    public bool isDead = false;

    public bool spawnFacingLeft;
    private bool isFacingLeft;
    private Vector2 facingLeft;

    public float move_horizontal;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private bool jumpPressed = false;
    private bool jumpReleased = false;

    private float timer = 0f;
    public float stepSoundInterval = 0.1f;
    private float stepIntervalCopy;

    void Start()
    {
        rigid_body_player = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();


        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions["Jump"];

        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if (spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }

        stepIntervalCopy = stepSoundInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        move_horizontal = moveInput.x;

        bool isJumpPressed = jumpAction.ReadValue<float>() > 0.5f;
        bool wasJumpPressed = jumpPressed;
        jumpPressed = isJumpPressed;

        if (isJumpPressed && !wasJumpPressed && isGrounded)
        {
            rigid_body_player.linearVelocity = new Vector2(rigid_body_player.linearVelocity.x, jump_height);
        }
        if (wasJumpPressed && !isJumpPressed && rigid_body_player.linearVelocity.y > -1f)
        {
            rigid_body_player.linearVelocity = new Vector2(rigid_body_player.linearVelocity.x, rigid_body_player.linearVelocity.y * 0.5f); //* 0.5f so that jump height depends on how long jump was pressed
        }
        if (move_horizontal != 0)
        {
            rigid_body_player.linearVelocity = new Vector2(speed * move_horizontal, rigid_body_player.linearVelocity.y);
        }
        if (move_horizontal == 0)
        {
            rigid_body_player.linearVelocity = new Vector2(rigid_body_player.linearVelocity.y * 0.1f * Time.deltaTime, rigid_body_player.linearVelocity.y); //* 0.1f a
        }
        if (move_horizontal > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            Flip();
        }
        if (move_horizontal < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            Flip();
        }
        isGroundedCopy = isGrounded;
    }
    protected virtual void Flip()
    {
        if (!isDead)
        {
            if (isFacingLeft)
            {
                transform.localScale = facingLeft;
            }
            if (!isFacingLeft)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
    }
}
