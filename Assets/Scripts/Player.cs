using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Health _health;

    public static Action PlayerDead;

    // Start is called before the first frame update
    void Start()
    {
        _health = GetComponent<Health>();
        if( _health == null)
        {
            _health = gameObject.AddComponent<Health>();
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Enemy>() != null)
        {
            TakeDamage();            
        }
    }

    private void TakeDamage()
    {
        _health._numberOfLives--;
        if (_health._numberOfLives < 1)
        {
            PlayerDead?.Invoke();
            Destroy(gameObject);
        }
    }
}
