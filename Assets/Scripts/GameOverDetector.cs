using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    private GameTimer gameTimer;
    public GameOverManager gameOverManager;
    public RepeatBackground repeatBackground;

    public void Start() {
        gameTimer = FindFirstObjectByType<GameTimer>();
    }

    private void OnTriggerEnter(Collider other)
    {   

        if (other.gameObject.CompareTag("FlyingObstacles"))
        {

            Debug.Log("Game Over, you hit a" + other.name);

            gameTimer.StopTimer();
            repeatBackground.enabled = false; 

            float finalTime = Time.time - gameTimer.startTime;
            
            GetComponent<Rigidbody>().isKinematic = true;

            gameOverManager.ShowGameOverScreen(finalTime);
        }
    }
}