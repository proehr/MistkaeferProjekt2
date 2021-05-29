using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimerText;
    [SerializeField] private ScoringState scoringState;

    private void Start()
    {
        SetUpState.OnEnterSetUpEvent += ResetTimer;
    }

    private void OnEnable()
    {
        ResetTimer();
    }
    
    private void ResetTimer()
    {
        scoringState.timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoringState.timer += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(scoringState.timer);
        gameTimerText.text = timeSpan.ToString("m':'ss':'fff");
    }
}
