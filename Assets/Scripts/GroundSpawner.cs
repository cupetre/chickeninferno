using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform starting_point;

    private Queue<GameObject> activeTiles = new Queue<GameObject>();

    public void SpawnTile()
    {
        GameObject newTile = Instantiate(groundPrefab, starting_point.position, Quaternion.identity);
        starting_point.position += Vector3.forward * 10f;
        activeTiles.Enqueue(newTile);
    }

    public void DeleteTile()
    {
        if (activeTiles.Count > 0)
        {
            //the moment another oneis created delete the previous one
            GameObject oldTile = activeTiles.Dequeue();
            Destroy(oldTile);
        }
    }
}