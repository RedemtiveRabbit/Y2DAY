using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class AI_BossFollower : MonoBehaviour

{
    public GameObject boss;
    public float followSpeed;
    public Rigidbody2D body;
    public float speed;
    public float distanceBetween;
    //private NavMeshAgent agent;
    private float distance;
    private float direction;
    public int HP;
    public float knockBackStrength;
    public float knockBackTime;
    public bool knockbackinating = false;
    public Vector2 lastMoveDirEnemy = Vector2.zero;
    public float keepDistance = 0.1f;
    Vector2 lastMoveDir;
    public bool walking;
    public Animator animator;
    public int palette;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody2D>();
        //agent.enabled = false;
        //agent.updateUpAxis = false;
        //agent.updateRotation = false;
        palette = Random.Range(0, 4);

        animator.SetInteger("Palette", palette);

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        FollowBoss();

        

    }

    void FollowBoss()
    {
        distance = Vector2.Distance(transform.position, boss.transform.position);
        //Vector2 direction = boss.transform.position - transform.position;
        //direction.Normalize();
        // float angle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;

        if (distance >= distanceBetween)
        {
            //agent.enabled = false;
            walking = false;
        }
        if (Vector2.Distance(transform.position, boss.transform.position) < keepDistance)
        {
            body.linearVelocity = Vector2.zero;
        }
        else if (distance < distanceBetween)
        {
            walking = true;
            if (boss.transform.position.x > gameObject.transform.position.x)
            {
                body.linearVelocityX += followSpeed;
            }

            if (boss.transform.position.x < gameObject.transform.position.x)
            {
                body.linearVelocityX -= followSpeed;
            }

            if (boss.transform.position.y > gameObject.transform.position.y)
            {
                body.linearVelocityY += followSpeed;
            }

            if (boss.transform.position.y < gameObject.transform.position.y)
            {
                body.linearVelocityY -= followSpeed;
            }
            //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //agent.enabled = true;
            // agent.SetDestination(player.transform.position);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        //body.velo
    }

    
}
