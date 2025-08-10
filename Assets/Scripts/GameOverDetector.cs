using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    private GameTimer gameTimer;
    public GameOverManager gameOverManager;

    void Start() =>

        gameTimer = FindFirstObjectByType<GameTimer>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FlyingObject"))
        {
            Debug.Log("Game Over!");
            gameTimer.StopTimer(); 
            float finalTime = Time.time - gameTimer.startTime;
            gameOverManager.ShowGameOverScreen(finalTime);
        }
    }
}