using System;
using System.IO;
using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoringState scoringState;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] private int initialRoundScore = 1000;
    [SerializeField] private int minAmountSeconds = 20;
    [SerializeField] private int timeMultiplier = 15;

    private String persistentScorePath;
    private int highScore;

    private void Start()
    {
        persistentScorePath = Path.Combine(Application.persistentDataPath, "score.txt");
        if (!File.Exists(persistentScorePath))
        {
            File.WriteAllText(persistentScorePath,"0");
        }
        highScore = Int32.Parse(File.ReadAllText(persistentScorePath));
        
        MainMenuState.OnExitMainMenuEvent += ResetScore;
        WinState.OnEnterWinEvent += UpdateScore;
        WinState.OnEnterWinEvent += SaveHighScore;
    }

    private void SaveHighScore()
    {
        String text = File.ReadAllText(persistentScorePath);
        int oldScore = Int32.Parse(text);
        if (scoringState.score > oldScore)
        {
            File.WriteAllText(persistentScorePath,scoringState.score.ToString());
            highScore = scoringState.score;
        }
    }

    private void UpdateScore()
    {
        float timeDiff = scoringState.timer - minAmountSeconds;
        int roundScore = Math.Max(100, initialRoundScore - (int) timeDiff * timeMultiplier);
        scoringState.score += roundScore;
    }

    private void ResetScore()
    {
        scoringState.score = 0;
    }

    void Update()
    {
        scoreText.text = scoringState.score.ToString();
        highScoreText.text = highScore.ToString();
    }
}