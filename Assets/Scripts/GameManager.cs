using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameState
    {
        MainMenu,
        Playing
    }

    public static GameManager SharedInstance;

    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] public GameObject _objectPools;
    
    private GameState _state;
    [NonSerialized] public Health _health;
    [NonSerialized] public Score _score;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _health = GetComponent<Health>();
        if (_health == null)
        {
            _health = gameObject.AddComponent<Health>();
        }

        _score = GetComponent<Score>();
        if (_score == null)
        {
            _score = gameObject.AddComponent<Score>();
        }

        _state = GameState.MainMenu;    
    }

    private void Update()
    {
        if(_state == GameState.MainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Instantiate(_playerPrefab);
                _state = GameState.Playing;
                _uiManager.SetMainMenuUI(false);
                _objectPools.SetActive(true);
            }
        }
    }

    public void OnPlayerDead()
    {
        _uiManager.SetMainMenuUI(true);
        _score.ResetScore();
        _health.ResetHealth();
        _state = GameState.MainMenu;
        _objectPools.SetActive(false);
    }

    public void OnEnemyKilled()
    {
        _score.IncreaseScore();
    }
}
