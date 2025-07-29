using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI;
    public PlayerHealth playerHealth;
    public OnScreenUI onScreenUI;

    public static DeathScreen instance;
    public Transform respawnPoint;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }
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
            player.transform.position = respawnPoint.position;
            deathScreenUI.SetActive(false);
            onScreenUI.Respawn();
            playerHealth.Reset();
            Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
