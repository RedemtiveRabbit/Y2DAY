using UnityEngine;

public class Healing : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth HP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //collect my gameobjects...
        player = GameObject.FindGameObjectWithTag("Player");
        HP = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && HP.health < HP.maxHealth)
        {
            HP.health = HP.maxHealth;
            Destroy(gameObject);
        }
    }
}
