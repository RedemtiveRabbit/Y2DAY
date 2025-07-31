using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class OctoEnemy : MonoBehaviour
{
    public string chargeState = "Off";

    //public enum ChargeState
    //{
    //    None,
    //    On,
    //    Off,
    //}
    //public ChargeState chargetState;

    public bool stunned;
    public float chargeDuration;
    public bool playerDetected;
    public GameObject player;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public float aggroRange;
    public float timer;
    public float delay;
    public float followSpeed;
    public Rigidbody2D body;
    public float stunDuration;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("stunned", stunned);
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= aggroRange && stunned == false)
        {
            if (chargeState == "Off")
            {
                timer += Time.deltaTime;
            }
            
            if (timer >= delay && chargeState == "Off")
            {
                timer = 0f;
                StartCoroutine(Charge());
            }
        }
        if (chargeState == "Start")
        {
  
        }
        if (chargeState == "Ongoing")
        {
            
        }
        else
        {
            
        }
        if (chargeState == "End")
        {


            
        }

    }
    IEnumerator Charge()
    {
        //if (playerMovement.transform.position.x > gameObject.transform.position.x)
        //{
        //    body.linearVelocityX = followSpeed;
        //}

        //if (playerMovement.transform.position.x < gameObject.transform.position.x)
        //{
        //    body.linearVelocityX = -followSpeed;
        //}

        //if (playerMovement.transform.position.y > gameObject.transform.position.y)
        //{
        //    body.linearVelocityY = followSpeed;
        //}

        //if (playerMovement.transform.position.y < gameObject.transform.position.y)
        //{
        //    body.linearVelocityY = -followSpeed;
        //}

        Vector2 direction = (player.transform.position - transform.position).normalized;
        body.linearVelocity = direction * 2;
        GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(chargeDuration);
        GetComponent<CircleCollider2D>().enabled = false;
        body.linearVelocityX = 0f;
        body.linearVelocityY = 0f;
        if (playerDetected == false)
        {
            stunned = true;
        }
        if (stunned == true)
        {
            yield return new WaitForSeconds(stunDuration);
            stunned = false;
        }

        chargeState = "Off";
        playerDetected = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = true;
            playerHealth.TakeDamage(1, body.linearVelocity);
        }
        else
        {
            playerDetected = false;
        }
    }
}
