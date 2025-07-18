using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioSource audioSource2;
    public float coolDown;
    public bool canDash = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        direction = playerMovement.direction;
        if(Input.GetButtonDown("Jump") && dashing == false && canDash && currentSceneName != "House Floor One" && currentSceneName != "Basement" && currentSceneName != "House Floor One 1")
        {
            StartCoroutine(DashRoutine());
        }
    }

    IEnumerator DashRoutine()
    {
        dashing = true;
        canDash = false;
        print("dashed");
        audioSource2.Play();

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
        yield return new WaitForSeconds(coolDown);
        canDash = true;
        
    }
}
