using UnityEngine;
using UnityEngine.Audio;

public class BossMusic : MonoBehaviour
{
    public BossManager bossManager;
    public int phase;

    public AudioClip SciFiBoss;
    public AudioClip westernBoss;
    public AudioClip heroBoss;
    public AudioClip deadBoss;
    public AudioSource audioSource;
    public bool playingSciFi = false;
    public bool playingWestern = false;
    public bool playingHero = false;
    public bool playingDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        phase = bossManager.phase;
        if (phase == 1 && !playingWestern)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(westernBoss);
            audioSource.loop = true;
            playingSciFi = false;
            playingWestern = true;
            playingHero = false;
            playingDead = false;
        }
        else if (phase == 2 && !playingSciFi)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(SciFiBoss);
            audioSource.loop = true;
            playingSciFi = true;
            playingWestern = false;
            playingHero = false;
            playingDead = false;
        }
        else if (phase == 3 && !playingHero)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(heroBoss);
            audioSource.loop = true;
            playingSciFi = false;
            playingWestern = false;
            playingHero = true;
            playingDead = false;
        }
        else if (phase == 4 && !playingDead)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(deadBoss);
            audioSource.loop = true;
            playingSciFi = false;
            playingWestern = false;
            playingHero = false;
            playingDead = true;
        }
        if (audioSource.isPlaying == false)
        {
            playingSciFi = false;
            playingWestern = false;
            playingHero = false;
            playingDead = false;
        }
    }
}
