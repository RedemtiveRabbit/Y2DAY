using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(10);
    }

    public void OpenSetings()
    {
        SceneManager.LoadScene(19);
    }

    public void OpenCredits ()
    {
        SceneManager.LoadScene(11);
    }
    
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}

