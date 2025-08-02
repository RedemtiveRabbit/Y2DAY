using UnityEngine;

public class soundsy : MonoBehaviour
{
    public ShootTurret shootTurret;
    public BossManager bossManager;
    public AudioSource audioSource;
    public AudioClip west;
    public AudioClip scifi;
    public AudioClip hero;
    public bool playing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shootTurret.shooting)
        {
            if(bossManager.phase == 1 && !playing)
            {
                playing = true;
                audioSource.PlayOneShot(west);
            }
            if (bossManager.phase == 2 && !playing)
            {
                playing  = true;
                audioSource.PlayOneShot(scifi);
            }
            if (bossManager.phase == 3 && !playing)
            {
                playing = true;
                audioSource.PlayOneShot(hero);
            }
        }

        if(!audioSource.isPlaying)
        {
            playing = false;
        }
    }
}
