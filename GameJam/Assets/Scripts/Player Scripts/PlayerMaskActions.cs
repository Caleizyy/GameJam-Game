using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMaskActions : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction mask1, mask2, mask3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        mask1 = playerInput.actions["Mask1"];
        mask2 = playerInput.actions["Mask2"];
        mask3 = playerInput.actions["Mask3"];
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.IsGamePaused)
        {
            if (mask1.triggered)
            {
                GameManager.hideHazards = false;
                GameManager.hideEnemies = true;
                GameManager.hidePlatforms = false;
            }
            if (mask2.triggered)
            {
                GameManager.hideHazards = false;
                GameManager.hideEnemies = false;
                GameManager.hidePlatforms = true;
            }
        }
    }
}
