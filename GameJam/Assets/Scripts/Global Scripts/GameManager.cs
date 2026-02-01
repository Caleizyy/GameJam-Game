using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGamePaused = false;
    private float reloadTimer = 0f;
    private float reloadDelay = 2f;
    public static bool hidePlatforms = false;
    public static bool hideEnemies = false;
    public static bool hideHazards = false;
    public static bool hasMask1 = false;
    public static bool hasMask2 = false;
    public static bool hasMask3 = false;

    void Start()
    {
        IsGamePaused = false;
        Time.timeScale = 1f;
        hidePlatforms = true;
        hideEnemies= true;
        hideHazards = true;
        hasMask1 = false;
        hasMask2 = false;
        hasMask3 = false;
    }
    void Update()
    {
        if (IsGamePaused)
        {
            reloadTimer += Time.unscaledDeltaTime;
        }
        if (reloadTimer >= reloadDelay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public static void PauseEverything()
    {
        IsGamePaused = true;
        Time.timeScale = 0f;
    }

    public static void ResumeEverything()
    {
        IsGamePaused = false;
        Time.timeScale = 1f;
    }
}
