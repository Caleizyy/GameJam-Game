using UnityEngine;

public class PlayerMaskActions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.IsGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.hideHazards = false;
                GameManager.hideEnemies = true;
                GameManager.hidePlatforms = false;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameManager.hideHazards = false;
                GameManager.hideEnemies = false;
                GameManager.hidePlatforms = true;
            }
        }
    }
}
