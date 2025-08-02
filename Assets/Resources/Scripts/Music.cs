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
    public AudioClip aquarium;
    public AudioClip shark;
    public AudioClip bossIntro;
    public AudioSource audioSource;
    public bool playingHouse = false;
    public bool playingMall = false;
    public bool playingGwen = false;
    public bool playingArcade = false;
    public bool playingMiguel = false;
    public bool playingAquarium = false;
    public bool playingShark = false;
    public bool playingBossIntro = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        if((SceneManager.GetActiveScene().name == "House Floor One" || SceneManager.GetActiveScene().name == "House Floor One 1" || SceneManager.GetActiveScene().name == "Basement" || SceneManager.GetActiveScene().name == "House Floor One 2" || SceneManager.GetActiveScene().name == "Basement 2" || SceneManager.GetActiveScene().name == "House Floor One 3" || SceneManager.GetActiveScene().name == "House Floor One 4" || SceneManager.GetActiveScene().name == "Basement 3" || SceneManager.GetActiveScene().name == "Basement 4") && !playingHouse)
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
            playingShark = false;
            playingAquarium = false;
            playingBossIntro = false;
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
            playingShark = false;
            playingAquarium = false;
            playingBossIntro = false;
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
            playingShark = false;
            playingAquarium = false;
            playingBossIntro = false;
        }
        else if((SceneManager.GetActiveScene().name == "Arcade Level 1" || SceneManager.GetActiveScene().name == "Arcade Level 2" || SceneManager.GetActiveScene().name == "Arcade Level 3") && !playingArcade)
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
            playingShark = false;
            playingAquarium = false;
            playingBossIntro = false;
        }
        else if(SceneManager.GetActiveScene().name == "Arcade Level 4" && !playingMiguel)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(miguel);
            audioSource.loop = true;
            print("played arcade");
            playingMiguel = true;
            playingMall = false;
            playingHouse = false;
            playingGwen = false;
            playingArcade = false;
            playingShark = false;
            playingAquarium = false;
            playingBossIntro = false;
        }
        else if ((SceneManager.GetActiveScene().name == "Aquarium 1" || SceneManager.GetActiveScene().name == "Aquarium 2") && !playingAquarium)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(aquarium);
            audioSource.loop = true;
            print("played arcade");
            playingAquarium = true;
            playingMall = false;
            playingHouse = false;
            playingGwen = false;
            playingArcade = false;
            playingShark = false;
            playingMiguel = false;
            playingBossIntro = false;
        }
        else if (SceneManager.GetActiveScene().name == "Aquarium 3" && !playingShark)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(shark);
            audioSource.loop = true;
            print("played arcade");
            playingMiguel = false;
            playingMall = false;
            playingHouse = false;
            playingGwen = false;
            playingArcade = false;
            playingShark = true;
            playingAquarium = false;
            playingBossIntro = false;
        }
        else if (SceneManager.GetActiveScene().name == "Theater Level 1" && !playingBossIntro)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(bossIntro);
            audioSource.loop = true;
            print("played arcade");
            playingMiguel = false;
            playingMall = false;
            playingHouse = false;
            playingGwen = false;
            playingArcade = false;
            playingShark = false;
            playingAquarium = false;
            playingBossIntro = true;
        }
        else if (SceneManager.GetActiveScene().name == "Theater Level 2")
        {
            audioSource.Stop();
        }

        if (audioSource.isPlaying == false)
        {
            playingMiguel = false;
            playingMall = false;
            playingHouse = false;
            playingGwen = false;
            playingArcade = false;
            playingShark = false;
            playingAquarium = false;
            playingBossIntro = false;
        }
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            audioSource.Stop();
        }



    }
}
