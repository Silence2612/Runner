using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    void Start() 
    {
        SpawnFence();
    }

    void SpawnFence() 
    {
        List<int> availableLanes = new List<int> {0,1,2};
        int fences2spawn = Random.Range(0,3);
        for (int i = 0; i < fences2spawn; i++)
        {
            if(availableLanes.Count <= 0) break;
            int randomLaneIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity , this.transform);
        }

    }
}