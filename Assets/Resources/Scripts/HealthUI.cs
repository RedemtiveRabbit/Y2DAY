using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth  playerHealth;
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

        if (playerHealth.health == 3)
        {
            sprite.sprite = threeHealth;
        }
        else if(playerHealth.health == 2)
        {
            sprite.sprite= twoHealth;
        }
        else if (playerHealth.health == 1)
        {
            sprite.sprite = oneHealth;
        }
        else if (playerHealth.health <= 0)
        {
            sprite.sprite = zeroHealth;
        }
    }
}
