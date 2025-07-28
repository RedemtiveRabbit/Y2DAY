using UnityEngine;

public class OnScreenUI : MonoBehaviour 
{
    public GameObject screenUI;
    public PlayerHealth playerHealth;

    private void Start()
    {
        screenUI.SetActive(true);
    }

    public void Die ()
    {
        screenUI.SetActive(false);
    }

    public void Respawn ()
    {
        screenUI.SetActive(true);
    }
}
