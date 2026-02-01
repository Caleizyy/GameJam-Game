using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

public class PlayerMaskActions : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction mask1, mask2, mask3;
    public Sprite[] sprites;
    public SpriteRenderer sprite;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        mask1 = playerInput.actions["Mask1"];
        mask2 = playerInput.actions["Mask2"];
        mask3 = playerInput.actions["Mask3"];
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!GameManager.IsGamePaused)
        {
            if (mask1.triggered && GameManager.hasMask1)
            {
                sprite.sprite = sprites[0];
                GameManager.hideHazards = true;
                GameManager.hideEnemies = false;
                GameManager.hidePlatforms = true;
            }
            if (mask2.triggered && GameManager.hasMask2)
            {
                sprite.sprite = sprites[1];
                GameManager.hideHazards = false;
                GameManager.hideEnemies = true;
                GameManager.hidePlatforms = true;
            }
            if (mask3.triggered && GameManager.hasMask3)
            {
                sprite.sprite = sprites[2];
                GameManager.hideHazards = true;
                GameManager.hideEnemies = true;
                GameManager.hidePlatforms = false;
            }
        }
    }
}
