using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int StartingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    float chunklength = 10;

    void Start()
    {
        for (int i = 0; i < StartingChunksAmount; i++)
        {
            float spawnPositionZ;

            if (i == 0) 
            {
                spawnPositionZ = transform.position.z;
            }
            else 
            {
                spawnPositionZ = transform.position.z + (i * chunklength);
            }

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        }
    }
}
