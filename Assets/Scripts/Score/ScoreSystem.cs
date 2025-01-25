using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public int Score;
    public static Action<int> OnScoreUpdated;
    private static ScoreSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene este objeto en todas las escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OnScoreUpdated?.Invoke(Score);
    }

    private void OnEnable()
    {
        Coins.OnCoinCollected += UpdateScore;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Coins.OnCoinCollected -= UpdateScore;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void UpdateScore(Coins coin)
    {
        Score += coin.value;
        
        OnScoreUpdated?.Invoke(Score);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnScoreUpdated?.Invoke(Score); // UI se actualiza al cargar la escena
    }
}
