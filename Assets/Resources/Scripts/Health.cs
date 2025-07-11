using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int HP; 
    void Start()
    {
        
    }

    void Die()
    {
        if (transform.localScale.x > 0)
        {
           transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP <= 0)
        {
            Die();
        }

    }
}
