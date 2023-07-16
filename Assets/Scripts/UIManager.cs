using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private Image _livesImage;
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField] private TextMeshProUGUI _score;

    public void SetMainMenuUI(bool state)
    {
        _mainMenu.SetActive(state); 
    }

    public void UpdateLiveUI(int currentLive)
    {
        _livesImage.sprite = _liveSprites[currentLive];
    }

    public void UpdateScoreUI(int currentScore)
    {
        _score.text = $"Score: {currentScore}";
    }
}
