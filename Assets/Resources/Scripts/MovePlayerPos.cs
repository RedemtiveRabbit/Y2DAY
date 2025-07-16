using Unity.VisualScripting;
using UnityEngine;

public class MovePlayerPos
{
    public GameObject player;
    public Vector2 spawnPosition;
    void Start()
    {
        
        if (player != null)
        {
        player.transform.position = spawnPosition;
        }
    }
    public void MovePlayerPosition()
    {

    }
}
