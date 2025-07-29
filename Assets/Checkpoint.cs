using Unity.Cinemachine;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public BoxCollider2D trigger;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DeathScreen.instance.respawnPoint = transform;
            trigger.enabled = false;
        }

    }
}
