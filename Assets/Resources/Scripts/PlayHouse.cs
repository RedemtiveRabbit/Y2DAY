using UnityEngine;

public class PlayHouse : MonoBehaviour
{
    public Music music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.audioSource.Stop();
        music.audioSource.PlayOneShot(music.house);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
