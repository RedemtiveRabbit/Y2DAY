using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D body;
    public PlayerMovement playerMovement;
    private float direction;
    public int HP;
    public AI_Chase AIChase;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Die()
    {
        if (transform.localScale.x > 0)
        {
           transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
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
        HP -= damage;
        AIChase.KnockBack();
        
    }

    


}
