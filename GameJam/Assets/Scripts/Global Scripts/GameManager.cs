using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public static bool IsPlayerDead = false;
    public static int Score = 0;
    private float reloadTimer = 0f;
    private float reloadDelay = 2f;
    public static bool hidePlatforms = false;
    public static bool hideEnemies = false;
    public static bool hideHazards = false;

    void Start()
    {
        IsGamePaused = false;
        Time.timeScale = 1f;
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
