using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float dashStrength;
    public float dashTime;
    public bool dashing = false;
    Rigidbody2D body;
    private int direction;
    private float xVelocity;
    private float yVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = playerMovement.direction;
        if(Input.GetButtonDown("Dash") && dashing == false)
        {
            StartCoroutine(DashRoutine());
        }
    }

    IEnumerator DashRoutine()
    {
        dashing = true;
        print("dashed");

        if(direction == 1)
        {
            body.linearVelocityY = dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityY = yVelocity;
        }
        if (direction == 2)
        {
            body.linearVelocityX = dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityX = xVelocity;
        }
        if (direction == 3)
        {
            body.linearVelocityY = -dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityY = yVelocity;
        }
        if (direction == 4)
        {
            body.linearVelocityX = -dashStrength;
            yield return new WaitForSeconds(dashTime);
            body.linearVelocityX = xVelocity;
        }

        dashing = false;
    }
}
