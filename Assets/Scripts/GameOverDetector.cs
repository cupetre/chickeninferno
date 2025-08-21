using System.Collections;
using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    private GameTimer gameTimer;
    public GameOverManager gameOverManager;
    public RepeatBackground repeatBackground;
    public GameObject[] hitEffects;

    public void Start()
    {
        gameTimer = FindFirstObjectByType<GameTimer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FlyingObstacles"))
        {
            Debug.Log("Game Over, you hit a " + other.name);

            gameTimer.StopTimer();
            repeatBackground.enabled = false;

            GetComponent<Rigidbody>().isKinematic = true;

            int index = Random.Range(0, hitEffects.Length);
            GameObject endEffect = Instantiate(hitEffects[index], transform.position, Quaternion.identity);
            endEffect.transform.parent = null;

            float effectDuration = 0f; // fallback
            ParticleSystem ps = endEffect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                effectDuration = ps.main.duration;
                Destroy(endEffect, effectDuration);
            }

            GetComponent<MeshRenderer>().enabled = false;

            StartCoroutine(ShowGameOverAfterDelay(effectDuration));
        }
    }

    private IEnumerator ShowGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        float finalTime = Time.time - gameTimer.startTime;
        gameOverManager.ShowGameOverScreen(finalTime);
    }

}