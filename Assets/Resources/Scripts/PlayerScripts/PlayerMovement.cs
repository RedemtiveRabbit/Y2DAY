using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public Dash dash;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;
    public int direction; // up = 1, right = 2, down = 3, right = 4

    public float moveSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        GetDirection(); //uses input to figure out what direction the player should move
        LimitDiag(); //limits the diagonal movement so that it isn't faster than horizontal or vertical
        ApplyMovement(); //applies direction information to effect the player's linear velocity
        SetSpriteDirection(); //makes it so the sprite faces the direction it's moving

    }

    void GetDirection()
    {
        // Gives a value between -1 and 1 depending on direction
        if(!dash.dashing)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        }
     
    }

    void LimitDiag()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
    }

    void ApplyMovement()
    {
        if (dash.dashing == false)
        {
            body.linearVelocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed); // sets linear velocity as a Vector2, multiplying direction by the moveSpeed
        }
    }

    void SetSpriteDirection()
    {
        SpriteRenderer sprite = body.GetComponent<SpriteRenderer>();

        //checks the velocities and sets sprites accordingly
        if (vertical > 0)
        {
            sprite.sprite = up;
            direction = 1;

        }
        else if(vertical < 0)
        {
            sprite.sprite = down;
            direction = 3;
        }
        else if(horizontal > 0)
        {
            sprite.sprite = right;
            direction = 2;
        }
        else if(horizontal < 0)
        {
            sprite.sprite = left;
            direction = 4;
        }
    }
}