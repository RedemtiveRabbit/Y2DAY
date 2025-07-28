using System.Threading;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public float lifespan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
       
        timer += Time.deltaTime;
        
        if(timer > lifespan)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.tag == "Player" && player.GetComponent<PlayerHealth>().invincible == false)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(1, rb.linearVelocity);
            Destroy(gameObject);
        }
        
    }
}

