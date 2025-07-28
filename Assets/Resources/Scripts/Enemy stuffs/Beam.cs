using UnityEngine;

public class Beam : MonoBehaviour
{
    public BoxCollider2D beamBox;
    public GameObject player;
    public bool active;
    public float beamTime;
    public float timer;
    public GameObject beam;
    public float rotationSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        beam.transform.rotation = Quaternion.RotateTowards(beam.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * 100f);
        if (active == false)
        {
            timer += Time.deltaTime;
            if (timer >= 5 && active == false)
            {
                active = true;
                timer = 0;
            }
        }
        if (active == true)
            {
              beamTime += Time.deltaTime;
             if (beamTime >= 8)
                {
                    active = false;
                    beamTime = 0;
                }

            }

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Player" && player.GetComponent<PlayerHealth>().invincible == false && active == true)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(1, new Vector2(0, 0));

        }

    }
}
