using Unity.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int phase;
    public bool stun;
    public bool walking;
    public bool attacking;
    public GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    public Health health;
    public Animator animator;
    public AI_Chase aiChase;
    public ShootTurret shootTurret;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

        if (health.HP <= 11 && health.HP > 6)
        {
            phase = 2;
        }
        else if (health.HP <= 6 && health.HP > 1)
        {
            phase = 3;
        }
        else if(health.HP == 1)
        {
            phase = 4;
        }
        
        if((aiChase.body.linearVelocityX != 0 || aiChase.body.linearVelocityY != 0) && !attacking)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        if(!shootTurret.coolingDown)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }



        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);
        animator.SetInteger("Stage", phase);
        animator.SetBool("Walking", walking);
        animator.SetBool("Attacking", attacking);

         

    }
}
