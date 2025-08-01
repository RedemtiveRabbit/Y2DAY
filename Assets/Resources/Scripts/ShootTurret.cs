using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ShootTurret : MonoBehaviour
{
    public GameObject TurretBullet;
    public Transform bulletPos;
    public GameObject player;
    public float RoF;
    public bool coolingDown = false;
    public int coolTime;
    public int maxShots;
    public int shots;
    public float rotationSpeed = 5f;
    public bool shooting;
    private float timer;
    public float timeUntilRoF;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("Shooting", shooting);
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        //  Debug.Log(distance);

        if (distance < 2.2)
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * 100f);
            timer += Time.deltaTime;
            if (coolingDown != true && shots < maxShots)
            {
                shooting = true;
                timeUntilRoF += Time.deltaTime;

                if (timeUntilRoF > RoF)
                {
                    shoot();
                    shots += 1;
                    timeUntilRoF = 0;
                }

            }
            else if (shots >= maxShots) 
            {
                shooting = false;
                coolingDown = true;
                StartCoroutine(CoolingTime());
            }

        }
        
    }
    IEnumerator CoolingTime()
    {
        yield return new WaitForSeconds(coolTime);
        shots = 0;
        coolingDown = false;
    }
void shoot()
    {
        Instantiate(TurretBullet, bulletPos.position, Quaternion.identity);
        
    }
}
