using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextScore : MonoBehaviour
{
    private Text _points;
    private void Awake()
    {
        _points = GetComponent<Text>();
    }

    private void OnEnable()
    {
        ScoreSystem.OnScoreUpdated += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreSystem.OnScoreUpdated -= UpdateScoreText;
    }

    private void UpdateScoreText(int score)
    {
        _points.text = score.ToString();
    }
}
