using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public PlayerScoreData ScoreData;

    public event Action<float> OnScoreChanged;
    public event Action<int> OnScoreAdded;
    public event Action OnScoreReset;

    private void Start()
    {
        OnScoreChanged?.Invoke(ScoreData.Score);
    }

    public void AddPoints(int points)
    {
        AddScore(points);
        OnScoreAdded?.Invoke(points);
        OnScoreChanged?.Invoke(ScoreData.Score);
    }

    public void ResetPoints()
    {
        ResetScore();
        OnScoreReset?.Invoke();
        OnScoreChanged?.Invoke(ScoreData.Score);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            AddPoints(1);
            Destroy(collision.gameObject);
        }
    }
    public void AddScore(float add)
    {
        ScoreData.Score += add;
    }
    public void ResetScore()
    {
        ScoreData.Score = 0;
    }
}