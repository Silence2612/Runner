using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float obstacleSpawnTime = 1f;
    [SerializeField] Transform obstacleParent;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine() 
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
        }
    }

}
