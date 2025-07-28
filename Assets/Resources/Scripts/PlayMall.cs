using UnityEngine;

public class PlayMall : MonoBehaviour
{
    public Music music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("STOP");
        music.audioSource.Stop();
        //music.audioSource.PlayOneShot(music.mall);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
