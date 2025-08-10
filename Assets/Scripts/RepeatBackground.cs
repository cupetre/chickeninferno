using UnityEngine;
using System.Collections.Generic;

public class RepeatBackground : MonoBehaviour
{
    public Transform player;
    public float chunkLength;
    public GameObject chunkPrefab; 
    public int initialChunks = 2;

    private Queue<GameObject> activeChunks = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < initialChunks; i++)
        {
            Vector3 spawnPos = new Vector3(0, 0, i * chunkLength);
            GameObject newChunk = Instantiate(chunkPrefab, spawnPos, Quaternion.identity, transform);
            activeChunks.Enqueue(newChunk);
        }
    }

    void Update()
    {
        GameObject firstChunk = activeChunks.Peek();

        if (player.position.z > firstChunk.transform.position.z + chunkLength)
        {
            GameObject oldChunk = activeChunks.Dequeue();
            Destroy(oldChunk);

            GameObject lastChunk = null;
            foreach (GameObject chunk in activeChunks)
                lastChunk = chunk;

            Vector3 spawnPos;
            if (lastChunk != null)
            {
                spawnPos = lastChunk.transform.position + new Vector3(0, 0, chunkLength);
            }
            else
            {
                spawnPos = new Vector3(0, 0, player.position.z + chunkLength);
            }

            GameObject newChunk = Instantiate(chunkPrefab, spawnPos, Quaternion.identity, transform);
            activeChunks.Enqueue(newChunk);
        }
    }
}
