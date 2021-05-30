using System;
using System.IO;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoringState scoringState;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    public static int initialRoundScore = 1000;
    public static int minRoundScore = 100;
    public static int minAmountSeconds = 20;
    public static int timeMultiplier = 15;

    private String persistentScorePath;
    private int highScore;

    private void Start()
    {
        //prepares high score saving file
        persistentScorePath = Path.Combine(Application.persistentDataPath, "score.txt");
        if (!File.Exists(persistentScorePath))
        {
            File.WriteAllText(persistentScorePath, "0");
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
            File.WriteAllText(persistentScorePath, scoringState.score.ToString());
            highScore = scoringState.score;
        }
    }

    private void UpdateScore()
    {
        float timeDiff = scoringState.timer - minAmountSeconds;
        int roundScore = Math.Max(minRoundScore, initialRoundScore - (int) timeDiff * timeMultiplier);
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