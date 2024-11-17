using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement movement;
    public float levelRestartDealay = 2f;

    public void EndGame()
    {
        movement.enabled = false;
        Invoke("RestartLevel", levelRestartDealay);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}