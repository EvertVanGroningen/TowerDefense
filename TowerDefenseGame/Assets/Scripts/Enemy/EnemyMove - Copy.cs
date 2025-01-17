using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 3f;
    public Transform[] waypoints;
    private int wayPointIndex = 0;
    public CheckWinLoss LosePunten;

    void Update()
    {
        EnemyBeweeg();
    }

    void EnemyBeweeg()
    {
        if (waypoints.Length == 0) return;
        Transform targetWaypoint = waypoints[wayPointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            wayPointIndex++;
            if (wayPointIndex >= waypoints.Length)
            {
                LosePunten.LosePoints += 1;
                Destroy(gameObject);
            }
        }
    }
}
