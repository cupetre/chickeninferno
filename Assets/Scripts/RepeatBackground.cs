using UnityEngine;
using System.Collections.Generic;

public class RepeatBackground : MonoBehaviour
{
    public Transform player;
    public float chunkLength;
    public GameObject chunkPrefab; 
    public int initialChunks = 2;

    private Queue<GameObject> chunkPool = new Queue<GameObject>();
    private GameObject lastChunk;
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Vector3 prefabPos = chunkPrefab.transform.position;
            Vector3 spawnPos = new Vector3(0, prefabPos.y, i * chunkLength);
            GameObject chunk = Instantiate(chunkPrefab, spawnPos, Quaternion.identity, transform);
            lastChunk = chunk;
        }
    }

    void Update()
    {
        GameObject firstChunk = chunkPool.Peek();

        if (player.position.z > firstChunk.transform.position.z + chunkLength)
        {
            chunkPool.Dequeue(); //we get rid of the first one in teh q

            Vector3 newPos = lastChunk.transform.position + new Vector3(0, 0, chunkLength);
            firstChunk.transform.position = newPos;

            chunkPool.Enqueue(firstChunk);
            lastChunk = firstChunk;
        }
    }
}
