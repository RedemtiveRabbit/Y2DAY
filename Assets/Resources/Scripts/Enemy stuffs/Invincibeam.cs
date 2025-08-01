using UnityEngine;

public class Invincibeam : MonoBehaviour
{
    public BoxCollider2D beamBox;
    public GameObject boss;
    public bool active;
    public float beamTime;
    public float timer;
    public GameObject beam;
    public float rotationSpeed = 5f;
    public int damage;
    public Health bossHealth;
    public DeathProtection DP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, boss.transform.position);
        Vector3 direction = boss.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        beam.transform.rotation = Quaternion.RotateTowards(beam.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * 100f);
        if (DP.stunned == true)
        {
            beamBox.enabled = false;
        }
        else
        {
            beamBox.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Boss" && bossHealth.invincible == false)
        {
            bossHealth.invincible = true;
        }
        else
        {
            bossHealth.invincible = false;
        }

    }
}
