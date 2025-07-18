using UnityEngine;

public class PlayGwen : MonoBehaviour
{
    public Music music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.audioSource.Stop();
        music.audioSource.PlayOneShot(music.gwen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
