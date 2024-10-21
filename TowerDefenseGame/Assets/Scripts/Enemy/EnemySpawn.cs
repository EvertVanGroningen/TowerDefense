using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawned;
    [SerializeField] private float spawnSpeed = 3f;
    [SerializeField] private Transform spawnPoint;
    public Transform[] waypoints;
    public CheckWinLoss VerliesPunten;
    public CheckWinLoss WinnaarPunten;
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemySpawned, spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyMove>().waypoints = waypoints;
            enemy.GetComponent<EnemyMove>().LosePunten = VerliesPunten;
            enemy.GetComponent<EnemyHealth>().WinPunten = WinnaarPunten;
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
