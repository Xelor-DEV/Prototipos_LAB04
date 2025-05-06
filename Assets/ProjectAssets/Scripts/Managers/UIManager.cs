using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text score;

    public void UpdateScoreUI(int newScore)
    {
        score.text = "Score: " + newScore.ToString();
    }

    public void UpdateHealthUI(int newHealth)
    {
        health.text = "Health:  " + newHealth.ToString();
    }
}