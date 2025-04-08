using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultsScreen : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private string winMessage = "Level Complete!";
    [SerializeField] private string loseMessage = "Level Failed";

    private void ShowResults(bool levelWon, float timeTaken)
    {
        if(levelWon == true)
        {
            resultText.text = winMessage;
        }
        else
        {
            resultText.text = loseMessage;
        }

        UpdateTimeText(timeTaken);
    }

    private void UpdateTimeText(float timeInSeconds)
    {
        timeText.text = "Your Time: " + timeInSeconds + " seconds";
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}