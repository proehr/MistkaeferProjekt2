using UnityEngine;

[CreateAssetMenu(fileName = "ScoringState", menuName = "ScoringState", order = 0)]
public class ScoringState : ScriptableObject
{
    public float timer;
    public int score;
}