using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootCooldown = 2f;
    public float detectionRadius = 10f;
    public float projectileSpeed = 10f;
    public float damage = 20f;
    private float shootCooldownTimer = 0f;
    private Transform targetEnemy;

    void Update()
    {
        DetectEnemies();

        if (targetEnemy != null)
        {
            shootCooldownTimer -= Time.deltaTime;
            if (shootCooldownTimer <= 0f)
            {
                ShootAtEnemy();
                shootCooldownTimer = shootCooldown;
            }
        }

        Debug.Log(targetEnemy);
    }

    void DetectEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                targetEnemy = hit.transform;
                return;
            }
        }
        targetEnemy = null;
    }

    void ShootAtEnemy()
    {
        if (targetEnemy == null) return;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (targetEnemy.position - transform.position).normalized;
            rb.velocity = direction * projectileSpeed;
        }
        Destroy(projectile, 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
