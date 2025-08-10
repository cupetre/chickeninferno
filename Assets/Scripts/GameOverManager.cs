using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalTimeText;

    public void ShowGameOverScreen(float finalTime)
    {
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);

        string minutes = ((int)finalTime / 60).ToString();
        string seconds = (finalTime % 60).ToString("f2");
        finalTimeText.text = "Final Time: " + minutes + ":" + seconds;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}