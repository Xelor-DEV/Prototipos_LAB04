using System;
using Assets.ProjectAssets.Scripts.GameEvents;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public PlayerScoreData _ScoreData;
    public static PlayerScoreData ScoreData;

    public event Action<float> OnScoreChanged;
    public event Action<int> OnScoreAdded;
    public event Action OnScoreReset;

    [SerializeField] private GameIntEvent onGetCoin;
    [SerializeField] private GameIntEvent onChangeScore;

    private void Start()
    {
        OnScoreChanged?.Invoke(ScoreData.Score);
    }
    private void Update()
    {
        ScoreData = _ScoreData;
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
            //AddPoints(1);
            onGetCoin.Raise(1);
            onChangeScore.Raise(ScoreData.Score);
            Destroy(collision.gameObject);
        }
    }
    public void AddScore(int add)
    {
        ScoreData.Score += add;
    }
    public void ResetScore()
    {
        ScoreData.Score = 0;
    }
}