using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction menuAction;
    public GameObject pauseMenuUI;
    void Start()
    {
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        menuAction = playerInput.actions["Menu"];
    }
    void Update()
    {
        if (menuAction.triggered)
        {
            pauseMenuUI.SetActive(true);
        }
    }
}
