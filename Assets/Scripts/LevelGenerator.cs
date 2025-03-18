using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int StartingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float moveSpeed = 8f;

    float chunklength = 10;
    //GameObject[] chunks = new GameObject[12];
    List<GameObject> chunks = new List<GameObject>();

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
            chunks.Add(newChunk);
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
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward*(moveSpeed*Time.deltaTime));
            if(chunk.transform.position.z<Camera.main.transform.position.z - chunklength)
            {
                Destroy(chunk);
                chunks.Remove(chunk);
            }
        }
    }
}
