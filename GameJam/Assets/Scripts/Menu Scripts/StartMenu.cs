using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuUI;
    void Update()
    {
        if (startMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        startMenuUI.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
