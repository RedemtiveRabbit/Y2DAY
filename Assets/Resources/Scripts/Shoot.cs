using UnityEngine;
using UnityEngine.Rendering;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;

    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
      //  Debug.Log(distance);

        if(distance < 2.2)
        {
            timer += Time.deltaTime;

            if (distance < 1 && timer > 10)
            {
                timer = 0;
                shoot();
            }
            else if (distance > 1 && timer > 1.7)
            {
                timer = 0;
                shoot();
            }
        }
        
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        
    }
}
