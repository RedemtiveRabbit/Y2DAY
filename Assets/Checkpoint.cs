using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D trigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 pos = transform.position;
            PlayerPrefs.SetFloat("CheckpointX", pos.x);
            PlayerPrefs.SetFloat("CheckpointY", pos.y);
            PlayerPrefs.SetInt("HasCheckpoint", 1);
            PlayerPrefs.Save();

            DeathScreen.instance.respawnPoint = transform;
            trigger.enabled = false;
        }
    }
}
