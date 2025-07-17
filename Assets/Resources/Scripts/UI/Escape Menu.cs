using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EscapeMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseFirstButton;
    public GameObject Resumeb;

    
    
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {

            if (gameIsPaused)
            {
                Resume();
            } 
            else
            {
         
                Pause();
            }
            Debug.Log(gameIsPaused);

        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Resumeb);

        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }
}
