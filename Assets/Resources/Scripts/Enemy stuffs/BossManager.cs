using Unity.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int phase;
    public bool stun;
    public GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    public Health health;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, 4);
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

        if (health.HP < 6 && health.HP > 3)
        {
            phase = 2;
        }
        if (health.HP < 3)
        {
            phase = 3;
        }
        if (phase == 1)
        {

        }
        else if (phase == 2)
        {

        }
        else if (phase == 3)
        {

        }
        
         animator.SetFloat("DirectionX", direction.x);
         animator.SetFloat("DirectionY", direction.y);

         

    }
}
