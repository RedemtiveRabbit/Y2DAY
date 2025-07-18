using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip house;
    public AudioClip mall;
    public AudioClip gwen;
    public AudioSource audioSource;
    void Start()
    {
        audioSource.PlayOneShot(house);
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
    }
}
