using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public int maxHealth = 5;
    public PlayerKnockbackTest2 knockback;
    public AudioSource auidoSource;
    public AudioClip hurt;
    public DeathScreen deathScreen;
    public GameObject Respawn;
    public bool invincible;
    private float timer;

    private bool isDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
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
    public void TakeDamage(int amount) 
    {
        if(invincible == false)
        {
            auidoSource.PlayOneShot(hurt);
            health -= amount;
            knockback.Knockback();
            invincible = true;

        }

        if(health <= 0 && !isDead)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(Respawn);
            Die();
        }

    }

    void Die()
    {
        deathScreen.gameOver();
    }
}
