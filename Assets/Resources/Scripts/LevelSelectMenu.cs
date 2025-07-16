using UnityEngine;

public class LevelSelectMenu : MonoBehaviour, IInteractable
{
    public InteractionDetector interactionDetector;
    public static bool gameIsPaused = false;
    public GameObject levelMenuUI;
    
    void Start()
    {
        levelMenuUI.SetActive(false);
    }
    void Update()
    {
        if (interactionDetector.interactionIcon.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        
    }

    void Resume()
    {
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        levelMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Interact()
    {
        if (!gameIsPaused) return;
    }

    public bool CanInteract()
    {
        return interactionDetector.interactionIcon == true;
    }
}
