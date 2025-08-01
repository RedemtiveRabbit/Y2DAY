using UnityEngine;

public class TriggerWall : MonoBehaviour 
{
    public GameObject wall;

    public void Start ()
    {
        wall.SetActive(false);
    }
    void OnTriggerExit2D (Collider2D other)
    {
        wall.SetActive (true);
    }
}
