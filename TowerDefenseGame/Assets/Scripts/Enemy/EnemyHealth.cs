using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hp = 100f;
    public CheckWinLoss WinPunten;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Haal de schadecomponent van het projectiel op
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();

            if (projectile != null)
            {
                TakeDamage(projectile.damage);
            }

            // Vernietig het projectiel na de impact
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0f)
        {
            WinPunten.WinPoints += 1;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
