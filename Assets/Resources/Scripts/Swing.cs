using System.Collections;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public int time = 0;
    public PlayerMovement playerMovement;
    private int direction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GetComponent<BoxCollider2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        direction = playerMovement.direction;
        if (Input.GetButtonDown("Fire1"))
        {

            StartCoroutine(BoxRoutine());
        }

    }

    private IEnumerator BoxRoutine()
    {
        GetComponent<BoxCollider2D>().enabled = true;

        if (direction == 1)
        {
            transform.position += new Vector3(0, .1f, 0);
            yield return new WaitForSeconds(time);
            transform.position -= new Vector3(0, .1f, 0);
        }
        else if (direction == 2)
        {
            transform.position += new Vector3(.1f, 0, 0);
            yield return new WaitForSeconds(time);
            transform.position -= new Vector3(.1f, 0, 0);
        }
        else if (direction == 3)
        {
            transform.position += new Vector3(0, -.12f, 0);
            yield return new WaitForSeconds(time);
            transform.position -= new Vector3(0, -.12f, 0);
        }
        else if (direction == 4)
        {
            transform.position += new Vector3(-.1f, 0, 0);
            yield return new WaitForSeconds(time);
            transform.position -= new Vector3(-.1f, 0, 0);
        }

        GetComponent<BoxCollider2D>().enabled = false;

    }
}
