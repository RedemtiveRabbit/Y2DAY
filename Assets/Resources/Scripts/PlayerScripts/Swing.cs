using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swing : MonoBehaviour
{
    public float time = 0;
    public PlayerMovement playerMovement;
    public Animator animator;
    private int direction;
    private float spriteDirection;
    public float rightOffset;
    public float leftOffset;
    public float upOffset;
    public float downOffset;
    public bool attacking;
    public float hitBoxDelay;
    public bool canAttack;
    public bool shouldYouAttack;
    public AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GetComponent<CircleCollider2D>().enabled = false;
        //attack collider starts deactivated
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attacking", attacking);
        animator.SetFloat("Direction", spriteDirection);
        direction = playerMovement.direction;
        spriteDirection = playerMovement.spriteDirection;
        string currentSceneName = SceneManager.GetActiveScene().name;
        // so it's a little more convenient to refer to the sprite's direction later
        if(currentSceneName == "House Floor One" || currentSceneName == "House Floor One 1" || currentSceneName == "House Floor One 2" || currentSceneName == "House Floor One 3" || currentSceneName == "House Floor One 4" || currentSceneName == "Basement" || currentSceneName == "Basement 1" || currentSceneName == "Basement 2" || currentSceneName == "Basement 3" || currentSceneName == "Basement 4" || currentSceneName == "Mall Level 5" || currentSceneName == "Arcade Level 4" || currentSceneName == "Aquarium 3")
        {
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }

        if (Input.GetButtonDown("Attack") && !attacking && canAttack && shouldYouAttack)
        {
            StartCoroutine(BoxRoutine());
            //print("hit hit hit");
        }
        // if attack button pressed then it starts a method where time is being tracked
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other?.GetComponent<Health>() is Health target)
        {
            //this isnt happening
            if (target.enabled) 
            {
                target.Defend(1); 
            }
        }
    }
    private IEnumerator BoxRoutine()
    {
        attacking = true;
        audioSource.Play();
        yield return new WaitForSeconds(hitBoxDelay);


        //make collider visible
        if (direction == 1)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            transform.localPosition = new Vector3(0, upOffset, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
            attacking = false;
        }
        else if (direction == 2)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            transform.localPosition = new Vector3(rightOffset, 0, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
            attacking = false;
        }
        else if (direction == 3)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            transform.localPosition = new Vector3(0, -downOffset, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
            attacking = false;
        }
        else if (direction == 4)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            transform.localPosition = new Vector3(-leftOffset, 0, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
            attacking = false;
        }
        //move collider based on what direction sprite was facing at the time that the attack was activated
        //delay before the collider deactivates
        GetComponent<CircleCollider2D>().enabled = false;
        //collider deactivates at the end
    }
}
