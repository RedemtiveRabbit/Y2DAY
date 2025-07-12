using System.Collections;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float time = 0;
    public PlayerMovement playerMovement;
    private int direction;
    public float rightOffset;
    public float leftOffset;
    public float upOffset;
    public float downOffset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GetComponent<CircleCollider2D>().enabled = false;
        //attack collider starts deactivated
    }

    // Update is called once per frame
    void Update()
    {
        
        direction = playerMovement.direction;
        // so it's a little more convenient to refer to the sprite's direction later
       
        if (Input.GetButtonDown("Fire1"))
        {

            StartCoroutine(BoxRoutine());
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
        GetComponent<CircleCollider2D>().enabled = true;
        //make collider visible
        if (direction == 1)
        {
            transform.localPosition = new Vector3(0, upOffset, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (direction == 2)
        {
            transform.localPosition = new Vector3(rightOffset, 0, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (direction == 3)
        {
            transform.localPosition = new Vector3(0, -downOffset, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (direction == 4)
        {
            transform.localPosition = new Vector3(-leftOffset, 0, 0);
            yield return new WaitForSeconds(time);
            transform.localPosition = new Vector3(0, 0, 0);
        }
        //move collider based on what direction sprite was facing at the time that the attack was activated
        //delay before the collider deactivates
        GetComponent<CircleCollider2D>().enabled = false;
        //collider deactivates at the end
    }
}
