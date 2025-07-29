using UnityEngine;

public class DeathProtection : MonoBehaviour
{
    public Health health;
    public int maxHP;
    public float timer;
    public bool stunned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHP = health.HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.HP < 2)
        {
            print("stun started");
            health.invincible = true;
            stunned = true;
            timer += Time.deltaTime;
        }
        if (timer > 3.7)
        {
            print("stun is over");
            health.HP = 4;
            stunned = false;
            health.invincible = false;
            timer = 0;
        }
    }
}
