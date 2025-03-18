using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int StartingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float moveSpeed = 8f;

    float chunklength = 10;
    GameObject[] chunks = new GameObject[12];

    void Start()
    {
        SpawnChunks();
    }

    void SpawnChunks()
    {
        for (int i = 0; i < StartingChunksAmount; i++)
        {
            float spawnPositionZ = ChunkSpawnPointZ(i);

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
            chunks[i] = newChunk;
        }
    }

    float ChunkSpawnPointZ(int i)
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

        return spawnPositionZ;
    }

    private void Update() 
    {
       MoveChunks(); 
    }

    void MoveChunks()
    {
        for (int i = 0; i < StartingChunksAmount; i++)
        {
            chunks[i].transform.Translate(-transform.forward*(moveSpeed*Time.deltaTime));
        }
    }
}
