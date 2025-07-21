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

