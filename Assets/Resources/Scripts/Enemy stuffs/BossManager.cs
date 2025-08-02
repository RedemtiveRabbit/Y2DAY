using System.Collections;
using Unity.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Diagnostics;

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
    public Transform BossLocation;
    public Transform TVLocation;
    public GameObject TV;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = Vector3Int.RoundToInt((player.transform.position - transform.position).normalized);
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

        if (health.HP <= 11 && health.HP > 6)
        {
            phase = 2;
        }
        else if (health.HP <= 6 && health.HP > 1)
        {
            phase = 3;
        }
        else if(health.HP < 2 || health.HP > 100)
        {
            phase = 4;
            StartCoroutine("TimeToDie");
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
        Debug.Log(direction);
        if (direction.x > 0 && direction.y == 0)
        {
            if (phase == 1)
            {
                bulletPos.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
            }
            if (phase == 2)
            {
                bulletPos.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
            }
            if (phase == 3)
            {
                bulletPos.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
            }
        }
        else if (direction.x < 0 && direction.y == 0)
        {
            if (phase == 1)
            {
                bulletPos.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
            }
            if (phase == 2)
            {
                bulletPos.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
            }
            if (phase == 3)
            {
                bulletPos.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
            }
        }
        else if (direction.x == 0 && direction.y > 0)
        {
            if (phase == 1)
            {
                bulletPos.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            }
            if (phase == 2)
            {
                bulletPos.position = new Vector2(transform.position.x + 0.3f, transform.position.y + 0.2f);
            }
            if (phase == 3)
            {
                bulletPos.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
            }
        }
        else if (direction.x == 0 && direction.y < 0)
        {
            if (phase == 1)
            {
                bulletPos.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            }
            if (phase == 2)
            {
                bulletPos.position = new Vector2(transform.position.x + 0.3f, transform.position.y - 0.3f);
            }
            if (phase == 3)
            {
                bulletPos.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
            }

        }

        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);
        animator.SetInteger("Stage", phase);
        animator.SetBool("Walking", walking);
        animator.SetBool("Attacking", attacking);

         

    }

    private IEnumerator TimeToDie()
    {
        health.HP = 200;
        shootTurret.enabled = false;
        yield return new WaitForSeconds(2.4f);
        print("iunvn");
        TVLocation.position = BossLocation.position;
        TV.SetActive(true);
        Destroy(gameObject);
    }
}
