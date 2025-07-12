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
    public float spriteDirection; // up = 0.25, right = 0.5, down = 0.75, right = 1
    public bool walking;
    public Animator animator;

    public float moveSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        LimitDiag(); //limits the diagonal movement so that it isn't faster than horizontal or vertical
        ApplyMovement(); //applies direction information to effect the player's linear velocity

    }
    private void Update()
    {
        GetDirection(); //uses input to figure out what direction the player should move
        SetSpriteDirection(); //makes it so the sprite faces the direction it's moving

    }


    public Vector2 lastMoveDir = Vector2.zero;
    void GetDirection()
    {
        // Gives a value between -1 and 1 depending on direction
        if(!dash.dashing)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
            if (horizontal != 0 || vertical != 0) { lastMoveDir = new Vector2(horizontal, vertical); }
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
            animator.SetFloat("LastMoveX", lastMoveDir.x);
            animator.SetFloat("LastMoveY", lastMoveDir.y);
            animator.SetBool("Walking", walking);
            animator.SetFloat("Direction", spriteDirection);
        }
     
    }

    void LimitDiag()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally
            horizontal *= moveLimiter;
            vertical *= moveLimiter;

            /*if(horizontal != 0)
            {
                vertical = 0;
            }

            if (vertical != 0)
            {
                horizontal = 0;
            }
            */
        }
    }

    void ApplyMovement()
    {
        if (dash.dashing == false)
        {
            body.linearVelocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed); // sets linear velocity as a Vector2, multiplying direction by the moveSpeed
            if(body.linearVelocityX != 0 ||  body.linearVelocityY != 0)
            {
                walking = true;
            }
            else
            {
                walking = false;
            }
        }
    }

    void SetSpriteDirection()
    {
        SpriteRenderer sprite = body.GetComponent<SpriteRenderer>();

        //checks the velocities and sets sprites accordingly
        if (vertical > 0)
        {
           //sprite.sprite = up;
            direction = 1;
            spriteDirection = 0.25f;
            
        }
        else if(vertical < 0)
        {
           //sprite.sprite = down;
            direction = 3;
            spriteDirection = 0.75f;
        }
        else if(horizontal > 0)
        {
           //sprite.sprite = right;
            direction = 2;
            spriteDirection = 0.5f;
        }
        else if(horizontal < 0)
        {
            //sprite.sprite = left;
            direction = 4;
            spriteDirection = 1;

        }
    }
}