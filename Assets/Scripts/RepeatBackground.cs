using UnityEngine;
using System.Collections.Generic;

public class RepeatBackground : MonoBehaviour
{
    public Transform player;
    public float chunkLength = 55f;
    public GameObject chunkPrefab;
    public int poolSize = 2;

    private Queue<GameObject> chunkPool = new Queue<GameObject>();
    private GameObject lastChunk;
    void Start()
    {

        for (int i = 0; i < poolSize; i++)
        {
            
            // get the position of the chicken first
            Vector3 prefabPos = chunkPrefab.transform.position;
            Vector3 spawnPos = new Vector3(0, prefabPos.y,35 +( i * chunkLength )); // use it for the Y static movement 
            GameObject chunk = Instantiate(chunkPrefab, spawnPos, Quaternion.identity, transform); //we give the chunk, where to span, the identity to follow, and spawning mechanic

            chunkPool.Enqueue(chunk); // we add it
            lastChunk = chunk; // rename it 

            Debug.Log($"[Start] Added chunk {chunk.name} at {spawnPos}. Pool count: {chunkPool.Count}");
        }
    }

    void Update()
    {
        if (chunkPool.Count == 0) return; // safety

        GameObject firstChunk = chunkPool.Peek(); // take the first one

        if (player.position.z > firstChunk.transform.position.z + chunkLength) // once passed, replace it
        {
            Debug.Log($"[Update] Player passed {firstChunk.name} at {firstChunk.transform.position}");

            chunkPool.Dequeue(); //we get rid of the first one in teh q
            Debug.Log($"[Update] Removed {firstChunk.name}. Pool count: {chunkPool.Count}");

            Vector3 prefabPos = chunkPrefab.transform.position;

            Vector3 newPos = lastChunk.transform.position + new Vector3(0, 0, chunkLength);
            firstChunk.transform.position = newPos;

            chunkPool.Enqueue(firstChunk);
            lastChunk = firstChunk;

            Debug.Log($"[Update] Moved and re-added {firstChunk.name} to {newPos}. Pool count: {chunkPool.Count}");
        }
    }
}