using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI;
    public PlayerHealth playerHealth;

    private void Start()
    {
        deathScreenUI.SetActive(false);
    }

    public void gameOver()
    {
        print("flkb");
        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathScreenUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
