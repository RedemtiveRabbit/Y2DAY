using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    public PlayerKnockbackTest2 knockback;
    public GameObject deathScreen;
    public GameObject deathScreenUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathScreenUI.SetActive(false);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount) 
    {
        health -= amount;
        knockback.Knockback();
        if(health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
   
    }
}
