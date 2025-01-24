using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score;

    public static Action<int> OnScoreUpdated;

    private void OnEnable()
    {
        Coins.OnCoinCollected += UpdateScore;
    }

    private void OnDisable()
    {
        Coins.OnCoinCollected -= UpdateScore;
    }

    private void UpdateScore(Coins coin)
    {
        Score += coin.value;

        OnScoreUpdated?.Invoke(Score);
    }
}
