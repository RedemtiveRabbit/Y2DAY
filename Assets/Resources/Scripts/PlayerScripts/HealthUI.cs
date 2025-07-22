using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Sprite sixHealth;
    public Sprite fiveHealth;
    public Sprite fourHealth;
    public Sprite threeHealth;
    public Sprite twoHealth;
    public Sprite oneHealth;
    public Sprite zeroHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

// Update is called once per frame
void FixedUpdate()
    {
        UpdateSprite();
    }

    void UpdateSprite()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
       
        if (PlayerHealth.health == 6)
        {
            sprite.sprite = sixHealth;
        }
        else if (PlayerHealth.health == 5)
        {
            sprite.sprite = fiveHealth;
        }
        else if(PlayerHealth.health == 4)
        {
            sprite.sprite= fourHealth;
        }
        else if (PlayerHealth.health == 3)
        {
            sprite.sprite = threeHealth;
        }
        else if (PlayerHealth.health == 2)
        {
            sprite.sprite = twoHealth;
        }
        else if (PlayerHealth.health == 1)
        {
            sprite.sprite = oneHealth;
        }
        else if (PlayerHealth.health <= 0)
        {
            sprite.sprite = zeroHealth;
        }
    }
}
