using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _failureFXleft;
    [SerializeField] private GameObject _failureFXright;
    [SerializeField] private float _speed;

    
    private SpriteRenderer _spriteRenderer;
    private Sprite _defaultSprite;
    private bool _hasShield;

    // Start is called before the first frame update
    void Start()
    {
        _failureFXleft.SetActive(false);
        _failureFXright.SetActive(false);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;

        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * _speed, 0, 0);
        transform.Translate(0, Input.GetAxis("Vertical") * Time.deltaTime * _speed, 0);


        if (transform.position.x <= PlayArea.SharedInstance.horizontalMinPosition)
        {
            transform.position = new Vector3(PlayArea.SharedInstance.horizontalMaxPosition, transform.position.y, 0);
        }
        else if (transform.position.x >= PlayArea.SharedInstance.horizontalMaxPosition)
        {
            transform.position = new Vector3(PlayArea.SharedInstance.horizontalMinPosition, transform.position.y, 0);
        }

        if (transform.position.y <= PlayArea.SharedInstance.verticalMinPosition)
        {
            transform.position = new Vector3(transform.position.x, PlayArea.SharedInstance.verticalMinPosition, 0);
        }
        else if (transform.position.y >= PlayArea.SharedInstance.verticalMaxPosition + PlayArea.SharedInstance.verticalMinPosition)
        {
            transform.position = new Vector3(transform.position.x, PlayArea.SharedInstance.verticalMaxPosition + PlayArea.SharedInstance.verticalMinPosition, 0);
        }
    }

    public void SetPowerupSpeedBoost(float speedMultiplier, float duration)
    {
        _speed *= speedMultiplier;
        StartCoroutine(SpeedBostPowerupDownRoutine(speedMultiplier, duration));        
    }

    IEnumerator SpeedBostPowerupDownRoutine(float speedMultiplier, float duration)
    {
        yield return new WaitForSeconds(duration);
        _speed /= speedMultiplier;
    }

    public void SetPowerupShield(Sprite shieldSprite, float duration)
    {
        _hasShield = true;
        _spriteRenderer.sprite = shieldSprite;
        StartCoroutine(ShieldPowerupDownRoutine(duration));
    }

    IEnumerator ShieldPowerupDownRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        DisableShield();
    }

    private void DisableShield()
    {
        _spriteRenderer.sprite = _defaultSprite;
        _hasShield = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Enemy>() != null)
        {
            if (_hasShield)
            {
                DisableShield();
                return;
            }
            TakeDamage();            
        }
    }

    private void TakeDamage()
    {
        GameManager.SharedInstance._health.DecreaseHealth();
        var currentHealth = GameManager.SharedInstance._health._numberOfLives;
        if (currentHealth < 1)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            GameManager.SharedInstance.OnPlayerDead();
            Destroy(gameObject);
        }
        else if(currentHealth < 2)
        {
            _failureFXright.SetActive(true);
            _failureFXleft.SetActive(true);
        }
        else if(currentHealth < 3) 
        {
            _failureFXleft.SetActive(true);
        }
    }
}
