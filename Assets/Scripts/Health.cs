using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthUi;
    public int _numberOfLives {get; private set;}

    private void Start()
    {
        _numberOfLives = 3;
        _healthUi.text = $"Health: {_numberOfLives}";
    }

    public void IncreaseHealth()
    {
        _numberOfLives++;
        _healthUi.text = $"Health: {_numberOfLives}";
    }

    public void DecreaseHealth()
    {
        _numberOfLives--;
        _healthUi.text = $"Health: {_numberOfLives}";
    }
}
