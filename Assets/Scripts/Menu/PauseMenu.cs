using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public void TogglePauseMenu()
    {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(!isActive);

        if (!isActive)
            Time.timeScale = 0f; // Пауза
        else
            Time.timeScale = 1f; // Возобновление
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Возобновление игры
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // Сбрасываем паузу перед загрузкой сцены
        SceneManager.LoadScene("MainMenu");
    }
}