using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SaveData saveData;
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
        SaveData.Load();
        Debug.Log(SaveData.current.levelsCompleted);
        Debug.Log(SaveData.current.hasCouch);


        if (SaveData.current.levelsCompleted == 0)
        {
            SceneManager.LoadScene("House Floor One");
        }
        else if (SaveData.current.levelsCompleted == 1)
        {
            SceneManager.LoadScene("House Floor One 1");
        }
        else if (SaveData.current.levelsCompleted == 2)
        {
            SceneManager.LoadScene("House Floor One 2");
        }
        else if (SaveData.current.levelsCompleted == 3)
        {
            SceneManager.LoadScene("House Floor One 3");
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

//Alive(health, hunger, thirst)
//Dog(breed)

