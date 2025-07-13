using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AI_Chase : MonoBehaviour

{
    public GameObject player;
    Rigidbody2D body;
    public float speed;
    public float distanceBetween;
    private NavMeshAgent agent;
    private float distance;
    public PlayerMovement playerMovement;
    private float direction;
    public int HP;
    public float knockBackStrength;
    public float knockBackTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody2D>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;

        if (distance >= distanceBetween)
        {
            agent.enabled = false;
        }
        if (distance < distanceBetween)
        {
            //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
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

    public void KnockBack()
    {
        StartCoroutine(KnockBackRoutine());
    }
}
