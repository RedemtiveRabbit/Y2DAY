using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHealth : MonoBehaviour
{
    public static int health { get; set; } = 6;
    public int maxHealth = 6;
    public PlayerKnockbackTest2 knockback;
    public AudioSource auidoSource;
    public AudioClip hurt;
    public DeathScreen deathScreen;
    public OnScreenUI onScreenUI;
    public GameObject Respawn;
    public bool invincible;
    private float timer;

    private bool isDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (invincible == true)
        {
            timer += Time.deltaTime;
            if (timer > .35)
            {
                invincible = false;
                timer = 0;
            }
        }
    }
    public void TakeDamage(int amount, Vector2 dir) 
    {
        if(invincible == false)
        {
            auidoSource.PlayOneShot(hurt);
            health -= amount;
            knockback.Knockback(dir);
            invincible = true;

        }

        if(health <= 0 && !isDead)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(Respawn);
            Die();
        }

    }

    public void Reset()
    {
        print("oasjdnvo");
        health = maxHealth;
    }

    void Die()
    {
        deathScreen.gameOver();
        onScreenUI.Die();
    }
}
