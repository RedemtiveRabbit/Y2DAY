using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    public PlayerKnockbackTest2 knockback;

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
        health -= amount;
        knockback.Knockback();
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
