using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSettings
{
    public static float chickenForwardSpeed = 7.5f;
    public static float chickenMoveSpeed = 3f;
}

public class MainMenuManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("NewScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    public void StartEasy()
    {   
        PlayerPrefs.SetString("Difficulty", "Easy");
        GameSettings.chickenForwardSpeed = 5f; 
        GameSettings.chickenMoveSpeed = 2.5f;
        SceneManager.LoadScene("NewScene");
    }

    public void StartNormal()
    {
        GameSettings.chickenForwardSpeed = 7.5f;
        PlayerPrefs.SetString("Difficulty", "Medium");
        SceneManager.LoadScene("NewScene");
    }

    public void StartHard()
    {
        GameSettings.chickenForwardSpeed = 12f;
        GameSettings.chickenMoveSpeed = 5f;
        PlayerPrefs.SetString("Difficulty", "Hard");
        SceneManager.LoadScene("NewScene");
    }

}
