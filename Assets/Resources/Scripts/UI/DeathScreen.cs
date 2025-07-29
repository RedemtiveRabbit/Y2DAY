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

        if (PlayerPrefs.GetInt("HasCheckpoint", 0) == 1)
        {
            float x = PlayerPrefs.GetFloat("CheckpointX");
            float y = PlayerPrefs.GetFloat("CheckpointY");
            Vector2 savedPosition = new Vector2(x, y);

            GameObject checkpointObj = new GameObject("LoadedCheckpoint");
            checkpointObj.transform.position = savedPosition;
            respawnPoint = checkpointObj.transform;
        }
        else
        {
            respawnPoint = player.transform; 
        }
    }

    private void Start()
    {
        deathScreenUI.SetActive(false);


        if (PlayerPrefs.GetInt("ShouldRespawn", 0) == 1)
        {
            if (respawnPoint != null)
            {
                player.transform.position = respawnPoint.position;
            }

            PlayerPrefs.SetInt("ShouldRespawn", 0);
            onScreenUI.Respawn();
            playerHealth.Reset();
            Time.timeScale = 1f;
        }
    }

    public void gameOver()
    {
        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Respawn()
    {
        PlayerPrefs.SetInt("ShouldRespawn", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }
}