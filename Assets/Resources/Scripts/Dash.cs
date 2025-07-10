using UnityEngine;

public class Dash : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float dashStrength;
    Rigidbody2D body;
    private int direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = playerMovement.direction;

        if (direction == 1)
        {
            body.linearVelocityY = dashStrength;
        }
    }
}
