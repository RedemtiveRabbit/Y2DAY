using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelMoveCollision : MonoBehaviour
{
    public int destination;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if(other.tag == "Player")
        {
            SceneManager.LoadScene(destination, LoadSceneMode.Single);
        }
    }
}
