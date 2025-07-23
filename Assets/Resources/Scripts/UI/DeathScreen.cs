using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI;
    public PlayerHealth playerHealth;
    public OnScreenUI onScreenUI;

    private void Start()
    {
        deathScreenUI.SetActive(false);
    }

    public void gameOver()
    {
        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathScreenUI.SetActive(false);
        onScreenUI.Respawn();
        print("milk");
        playerHealth.Reset();
        print("pancake");
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
