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
                print("milk");
                if (gameIsPaused)
                {
                    print("soda");
                    Resume();
                }
                else
                {
                    print("Juice");
                    Pause();
                }
            }
        }
        
    }

    void Resume()
    {
        print("lemonade");
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        print("tea");
        levelMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Interact()
    {
        print("water");
        if (!gameIsPaused) return;
        print("beer");
    }

    public bool CanInteract()
    {
        print("Coffee");
        return interactionDetector.interactionIcon == true;
    }
}
