using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class FishEnemy : MonoBehaviour
{
    public bool isDashing = false;
    public bool canDash = true;
    public float timer;
    public GameObject player;
    public Rigidbody2D body;
    public float dashTime;
    public AI_Chase1 aiChase;
    public int dashStrength;
    public float coolDown;
    public float aggroRange;
    public bool noWalk;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < aggroRange && isDashing == false && canDash == true)
        {
            StartCoroutine(EnemyDash());
        }
        animator.SetBool("Dashing", isDashing);

        if(isDashing == true)
        {
            aiChase.walking = false;
            noWalk = true;
        }
        else
        {
            noWalk = false;
        }
    }
    IEnumerator EnemyDash()
    {
        isDashing = true;
        canDash = false;
        if (aiChase.lastMoveDirEnemy.y > 0)
        {
            body.linearVelocityY = dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityY = 0;
        }
        if (aiChase.lastMoveDirEnemy.x > 0)
        {
            body.linearVelocityX = dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityX = 0;
        }
        if (aiChase.lastMoveDirEnemy.y < 0)
        {
            body.linearVelocityY = -dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityY = 0;
        }
        if (aiChase.lastMoveDirEnemy.x < 0)
        {
            body.linearVelocityX = -dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityX = 0;
        }

        isDashing = false;

        yield return new WaitForSeconds(coolDown);
        canDash = true;


    }

    
}
