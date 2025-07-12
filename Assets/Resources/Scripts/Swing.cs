using System.Collections;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float time = 0;
    public PlayerMovement playerMovement;
    public float leftOffset;
    public float rightOffset;
    public float upOffset;
    public float downOffset;
    private int direction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GetComponent<CircleCollider2D>().enabled = false;

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
        GetComponent<CircleCollider2D>().enabled = true;

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

        GetComponent<CircleCollider2D>().enabled = false;

    }
}
