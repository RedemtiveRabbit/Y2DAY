using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    public PlayerKnockbackTest2 knockback;
    public AudioSource auidoSource;
    public AudioClip hurt;
    public DeathScreen deathScreen;

    private bool isDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount) 
    {
        auidoSource.PlayOneShot(hurt);
        health -= amount;
        knockback.Knockback();
        if(health <= 0 && !isDead)
        {
            Die();
        }

    }

    void Die()
    {
        deathScreen.gameOver();
    }
}
