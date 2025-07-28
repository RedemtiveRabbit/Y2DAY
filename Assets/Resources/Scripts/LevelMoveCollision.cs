using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelMoveCollision : MonoBehaviour
{
    public string destination;
    PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");

        if(collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerMovement>() != null)
            {
                if (spawnDestination == null || spawnDestination.Length == 0)
                {
                    PlayerMovement.destination = null;
                }
                else
                {
                    PlayerMovement.destination = spawnDestination;
                }
            }
            SceneManager.LoadScene(destination, LoadSceneMode.Single);
        }
    }

    public string spawnDestination = "";
    private void Start()
    {
        
    }
    
}
