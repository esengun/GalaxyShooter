using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    public int _numberOfLives {get; private set;}

    private void Start()
    {
        _numberOfLives = 3;
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
}
