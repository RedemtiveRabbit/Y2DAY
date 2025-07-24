using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("House Floor One");
    }

    public void OpenSetings()
    {
        SceneManager.LoadScene(19);
    }

    public void LoadGame()
    {
        GlobalSaveData data = SaveSystem.LoadGame();
        Debug.Log(GlobalSaveData.levelsCompleted);
        if (GlobalSaveData.levelsCompleted == 0)
        {
            SceneManager.LoadScene("House Floor One");
        }
        else if (GlobalSaveData.levelsCompleted == 1)
        {
            SceneManager.LoadScene("House Floor One 1");
        }
    }

    public void OpenCredits ()
    {
        SceneManager.LoadScene("Credits");
    }

    public void PlayCinematic ()
    {
        SceneManager.LoadScene("Cinematic");
    }
    
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}

