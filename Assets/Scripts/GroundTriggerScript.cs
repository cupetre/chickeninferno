using UnityEngine;

public class GroundTriggerScript : MonoBehaviour
{
    private GroundSpawner spawner;

    [System.Obsolete]
    void Start()
    {
        spawner = FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chiken"))
        {
            spawner.SpawnTile();
            spawner.DeleteTile();
            
            gameObject.SetActive(false);
        }
    }
}