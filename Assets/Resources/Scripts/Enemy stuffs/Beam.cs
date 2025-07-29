using UnityEngine;

public class Beam : MonoBehaviour
{
    public BoxCollider2D beamBox;
    public GameObject player;
    public bool active;
    private float beamTime;
    private float timer;
    public GameObject beam;
    public float rotationSpeed = 5f;
    public bool charging = false;
    public bool beaming = false;
    public float chargeTime;
    public float beamTimes;
    public Animator animator;
    public float alertDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Charging", charging);
        animator.SetBool("Beaming", beaming);

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        beam.transform.rotation = Quaternion.RotateTowards(beam.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * 100f);
        if (active == false && distance < alertDistance)
        {
            charging = true;
            timer += Time.deltaTime;
            if (timer >= chargeTime && active == false)
            {
                active = true;
                timer = 0;
                charging = false;
            }
        }
        if (active == true)
            {
            beaming = true; 
             beamTime += Time.deltaTime;
             if (beamTimes >= 8)
                {
                    active = false;
                    beamTime = 0;
                    beaming = false;
                }

            }

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Player" && player.GetComponent<PlayerHealth>().invincible == false && active == true)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(1, new Vector2(0, 0));
            active = false;
        }

    }
}
