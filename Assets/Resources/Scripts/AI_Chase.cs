using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AI_Chase : MonoBehaviour

{
    public GameObject player;
    public float followSpeed;
    public Rigidbody2D body;
    public float speed;
    public float distanceBetween;
    private NavMeshAgent agent;
    private float distance;
    public PlayerMovement playerMovement;
    private float direction;
    public int HP;
    public float knockBackStrength;
    public float knockBackTime;
    public bool knockbackinating = false;
    public Vector2 lastMoveDirEnemy = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody2D>();
        agent.enabled = false;
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (!(knockbackinating))
        {
            FollowPlayer();

        }
        playerMovement.spriteDirection = direction;
    }

    void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize();
        // float angle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;

        if (distance >= distanceBetween)
        {
            agent.enabled = false;
        }
        if (distance < distanceBetween)
        {
            if (playerMovement.transform.position.x > gameObject.transform.position.x)
            {
                body.linearVelocityX += followSpeed;
            }

            if (playerMovement.transform.position.x < gameObject.transform.position.x)
            {
                body.linearVelocityX -= followSpeed;
            }

            if (playerMovement.transform.position.y > gameObject.transform.position.y)
            {
                body.linearVelocityY += followSpeed;
            }

            if (playerMovement.transform.position.y < gameObject.transform.position.y)
            {
                body.linearVelocityY -= followSpeed;
            }
            //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            agent.enabled = true;
            // agent.SetDestination(player.transform.position);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        //body.velo
    }

    IEnumerator KnockBackRoutine()
    {
        print("knockbacking");
        if (playerMovement.lastMoveDir.y == 1)
        {
            knockbackinating = true;
            print("doopity dooobity doo");
            body.linearVelocityY = knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }
        if (playerMovement.lastMoveDir.x == 1)
        {
            knockbackinating = true;
            print("doopity dooobity daa");

            body.linearVelocityX = knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }
        if (playerMovement.lastMoveDir.y == -1)
        {
            knockbackinating = true;
            print("doopity dooobity dee");

            body.linearVelocityY = -knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }
        if (playerMovement.lastMoveDir.x == -1)
        {
            knockbackinating = true;
            print("doopity dooobity duu");

            body.linearVelocityX = -knockBackStrength;
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }
    }

    public void KnockBack()
    {
        StartCoroutine(KnockBackRoutine());
    }
}
