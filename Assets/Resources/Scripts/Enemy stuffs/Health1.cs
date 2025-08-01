using System;
using System.Collections;
using UnityEngine;
public class Health1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D body;
    public PlayerMovement playerMovement;
    private float direction;
    public int HP;
    private int MaxHP;
    public AI_Chase1 AIChase;
    public AudioSource audioSource;
    public bool invincible;

    void Start()
    {
        invincible = false;
        body = GetComponent<Rigidbody2D>();
    }

    void Die()
    {
        if (transform.localScale.x > 0)
        {
           transform.localScale -= new Vector3(0.08f, 0.08f, 0.08f);
        }
        else
        {
    
            Destroy(gameObject);
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP <= 0)
        {
            Die();
        }
        playerMovement.spriteDirection = direction;

    }
    public void Defend(int damage)
    {
        print("Damage Attempted");
        if (invincible == false)
        {
            print("Damage Taken");
            audioSource.Play();
            HP -= damage;
            AIChase.KnockBack();
        } 
    }

    


}
