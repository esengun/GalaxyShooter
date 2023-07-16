using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private int _startLives = 3;
    public int _numberOfLives {get; private set;}

    private void Start()
    {
        _numberOfLives = _startLives;
        _uiManager.UpdateLiveUI(_numberOfLives);
    }

    public void IncreaseHealth()
    {
        _numberOfLives++;
        _uiManager.UpdateLiveUI(_numberOfLives);
    }

    public void DecreaseHealth()
    {
        _numberOfLives--;
        _uiManager.UpdateLiveUI(_numberOfLives);
    }

    public void ResetHealth()
    {
        _numberOfLives = _startLives;
        _uiManager.UpdateLiveUI(_numberOfLives);
    }
}
