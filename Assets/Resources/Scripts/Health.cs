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
    public float knockBackStrength;
    public float knockBackTime;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Die()
    {
        if (transform.localScale.x > 0)
        {
           transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
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
        StartCoroutine(KnockBackRoutine());
        
    }

    IEnumerator KnockBackRoutine()
    {
        if (direction == 0.25)
        {
            body.linearVelocityY = knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);
        }
        if (direction == 0.5)
        {
            body.linearVelocityX = knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);
        }
        if (direction == 0.75)
        {
            body.linearVelocityY = -knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);
        }
        if (direction == 1)
        {
            body.linearVelocityX = -knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);

        }
    }


}
