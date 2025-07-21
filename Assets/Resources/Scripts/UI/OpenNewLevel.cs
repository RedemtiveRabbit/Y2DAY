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

    public void Locked()
    {

    }

    public void CloseMenu()
    {
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}

