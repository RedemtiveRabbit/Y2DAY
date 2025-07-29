using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip house;
    public AudioClip mall;
    public AudioClip gwen;
    public AudioClip arcade;
    public AudioClip miguel;
    public AudioSource audioSource;
    public bool playingHouse = false;
    public bool playingMall = false;
    public bool playingGwen = false;
    public bool playingArcade = false;
    public bool playingMiguel = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        if((SceneManager.GetActiveScene().name == "House Floor One" || SceneManager.GetActiveScene().name == "House Floor One 1" || SceneManager.GetActiveScene().name == "Basement") && !playingHouse)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(house);
            audioSource.loop = true;
            print("played house");
            playingHouse = true;
            playingMall = false;
            playingGwen = false;
            playingArcade = false;
            playingMiguel = false;
        }
        else if((SceneManager.GetActiveScene().name == "Mall Level 1" || SceneManager.GetActiveScene().name == "Mall Level 2" || SceneManager.GetActiveScene().name == "Mall Level 3" || SceneManager.GetActiveScene().name == "Mall Level 4" || SceneManager.GetActiveScene().name == "Mall Level 6") && !playingMall)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(mall);
            audioSource.loop = true;
            print("played mall");
            playingMall = true;
            playingHouse = false;
            playingGwen = false;
            playingArcade = false;
            playingMiguel = false;
        }
        else if(SceneManager.GetActiveScene().name == "Mall Level 5" && !playingGwen)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(gwen);
            audioSource.loop = true;
            print("played gweb");
            playingGwen = true;
            playingMall = false;
            playingHouse = false;
            playingArcade = false;
            playingMiguel = false;
        }
        else if(SceneManager.GetActiveScene().name == "Arcade Level 1" && !playingArcade || SceneManager.GetActiveScene().name == "Arcade Level 2" || SceneManager.GetActiveScene().name == "Arcade Level 3")
        {
            audioSource.Stop();
            audioSource.PlayOneShot(arcade);
            audioSource.loop = true;
            print("played arcade");
            playingArcade = true;
            playingMall = false;
            playingHouse = false;
            playingGwen = false;
            playingMiguel = false;
        }
        else if(SceneManager.GetActiveScene().name == "Arcade Level 4" && !playingMiguel)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(arcade);
            audioSource.loop = true;
            print("played arcade");
            playingMiguel = true;
            playingMall = false;
            playingHouse = false;
            playingGwen = false;
            playingArcade = false;
        }


    }
}
