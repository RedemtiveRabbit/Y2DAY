using UnityEngine;

public class EnemyDamage1 : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerHealth.invincible == false)
        {
            playerHealth.TakeDamage(damage, GetComponent<AI_Chase1>().lastMoveDirEnemy);
        }
    }
}
