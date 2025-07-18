using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip house;
    public AudioClip mall;
    public AudioClip gwen;
    public AudioSource audioSource;
    public bool playingHouse = false;
    public bool playingMall = false;
    public bool playingGwen = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        if((SceneManager.GetActiveScene().name == "House Floor One" || SceneManager.GetActiveScene().name == "House Floor One 1") && !playingHouse)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(house);
            audioSource.loop = true;
            print("played house");
            playingHouse = true;
            playingMall = false;
            playingGwen = false;
        }
        if((SceneManager.GetActiveScene().name == "Mall Level 1") && !playingMall)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(mall);
            audioSource.loop = true;
            print("played mall");
            playingMall = true;
            playingHouse = false;
            playingGwen = false;
        }
        if(SceneManager.GetActiveScene().name == "Mall Level 5" && !playingGwen)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(gwen);
            audioSource.loop = true;
            print("played gweb");
            playingGwen = true;
            playingMall = false;
            playingHouse = false;
        }
        if (audioSource.isPlaying == false)
        {
            playingGwen = false;
            playingMall = false;
            playingHouse = false;
        }

    }
}
