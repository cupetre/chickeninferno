using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime;
    public bool runningTimer = true;

    public void Start()
    {
        startTime = Time.time;
    }

    public void Update()
    {

        if (!runningTimer) return;

        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = "Time: " + minutes + ":" + seconds;

    }

    public void StopTimer()
    {   
        runningTimer = false;
    }
}