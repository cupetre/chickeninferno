using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;
    public GameObject backToMenuButton;

    public void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    public void ShowGameOverScreen(float finalTime)
    {
        Time.timeScale = 0;

        string minutes = ((int)finalTime / 60).ToString();
        string seconds = (finalTime % 60).ToString("f2");
        finalTimeText.text = "Final Time: " + minutes + ":" + seconds;

        gameOverText.text = "GAME OVER";
        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        backToMenuButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}