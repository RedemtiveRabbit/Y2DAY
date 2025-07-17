using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNewLevel : MonoBehaviour
{
    public GameObject levelMenuUI;
    public void OpenMall()
    {
        SceneManager.LoadScene(12);
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

