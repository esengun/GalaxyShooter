using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private int _scoreAmount;
    public int _currentScore { get; private set; }

    private void Start()
    {
        _currentScore = 0;
        _uiManager.UpdateLiveUI(_currentScore);
    }

    public void IncreaseScore()
    {
        _currentScore += _scoreAmount;
        _uiManager.UpdateScoreUI(_currentScore);
    }

    public void DecreaseScore()
    {
        _currentScore -= _scoreAmount;
        _uiManager.UpdateScoreUI(_currentScore);
    }
}
