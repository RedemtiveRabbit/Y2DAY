using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNewLevel : MonoBehaviour
{
    public GameObject levelMenuUI;
    public void OpenMall()
    {
        SceneManager.LoadScene("Mall Level 1");
        Time.timeScale = 1f;
    }

    public void OpenArcade()
    {
        SceneManager.LoadScene("Arcade Level 1");
        Time.timeScale = 1f;
    }
    public void OpenAquarium()
    {
        SceneManager.LoadScene("Aquarium 1");
        Time.timeScale = 1f;
    }
    public void OpenTheater()
    {
        SceneManager.LoadScene("Theater Level 1");
        Time.timeScale = 1f;
    }
    public void Locked()
    {

    }

    public void CloseMenu()
    {
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}

