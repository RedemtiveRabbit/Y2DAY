using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void DeBug ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
