using Unity.VisualScripting;
using UnityEngine;

public class MovePlayerPos
{
    public GameObject player;
    public Vector2 spawnPosition;
    
    public void MovePlayerPosition()
    {
        if (player != null)
        {
            player.transform.position = spawnPosition;
        }
    }
}
