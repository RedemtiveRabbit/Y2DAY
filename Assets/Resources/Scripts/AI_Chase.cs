using UnityEngine;
using UnityEngine.AI;

public class AI_Chase : MonoBehaviour

{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private NavMeshAgent agent;
    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            agent.SetDestination(player.transform.position);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
