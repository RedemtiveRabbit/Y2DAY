using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class AI_Chase1 : MonoBehaviour

{
    public GameObject player;
    public float followSpeed;
    public Rigidbody2D body;
    public float speed;
    public float distanceBetween;
    //private NavMeshAgent agent;
    private float distance;
    public PlayerMovement playerMovement;
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
    public FishEnemy fishEnemy;
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

        animator.SetBool("Dashing", fishEnemy.isDashing);
        if (!(knockbackinating))
        {
            if(fishEnemy.isDashing == false)
            {
                FollowPlayer();
            }
        }
        playerMovement.spriteDirection = direction;
        if (body.linearVelocityX != 0 || body.linearVelocityY != 0)
        {
            lastMoveDirEnemy = new Vector2(body.linearVelocityX, body.linearVelocityY);
            animator.SetFloat("LastMoveDirX", lastMoveDirEnemy.x);
            animator.SetFloat("LastMoveDirY", lastMoveDirEnemy.y);
            animator.SetBool("Walking", walking);
        }
        
    }

    void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize();
        // float angle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;

        if (distance >= distanceBetween)
        {
            //agent.enabled = false;
            walking = false;
        }
        if (Vector2.Distance(transform.position, player.transform.position) < keepDistance)
        {
            body.linearVelocity = Vector2.zero;
        }
        else if (distance < distanceBetween)
        {
            walking = true;
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
            //agent.enabled = true;
            // agent.SetDestination(player.transform.position);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        
        //body.velo
    }

    IEnumerator KnockBackRoutine()
    {
        //print("knockbacking");
        if (playerMovement.lastMoveDir.y > 0)
        {
            knockbackinating = true;
            //print("doopity dooobity doo");
            body.AddForceY(knockBackStrength, ForceMode2D.Impulse);
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }
        if (playerMovement.lastMoveDir.x > 0)
        {
            knockbackinating = true;
            //print("doopity dooobity daa");

            body.AddForceX(knockBackStrength, ForceMode2D.Impulse);
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }
        if (playerMovement.lastMoveDir.y < 0)
        {
            knockbackinating = true;
            //print("doopity dooobity dee");

            body.AddForceY(-knockBackStrength, ForceMode2D.Impulse);
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }
        if (playerMovement.lastMoveDir.x < 0)
        {
            knockbackinating = true;
            //print("doopity dooobity duu");
            body.AddForceX(-knockBackStrength, ForceMode2D.Impulse);
            yield return new WaitForSeconds(knockBackTime);
            knockbackinating = false;
        }



    }

    public void KnockBack()
    {
        StartCoroutine(KnockBackRoutine());
    }
}
