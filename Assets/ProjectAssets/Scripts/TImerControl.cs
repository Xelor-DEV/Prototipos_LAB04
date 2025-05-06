using TMPro;
using UnityEngine;

public class TImerControl : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;

        timerText.text = "Time:  " + timer.ToString("F2");
    }

    // Opcional: métodos para controlar el timer
    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        timer = 0f;
        timerText.text = "0.00";
    }
}