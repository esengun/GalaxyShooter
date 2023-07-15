using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed;

    [SerializeField] private float _verticalMaxPosition;
    [SerializeField] private float _verticalMinPosition;

    [SerializeField] private float _horizontalMaxPosition;
    [SerializeField] private float _horizontalMinPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Debug.Log(_speed);
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * _speed, 0, 0);
        transform.Translate(0, Input.GetAxis("Vertical") * Time.deltaTime * _speed, 0);


        if (transform.position.x <= _horizontalMinPosition)
        {
            transform.position = new Vector3(_horizontalMaxPosition, transform.position.y, 0);
        }
        else if (transform.position.x >= _horizontalMaxPosition)
        {
            transform.position = new Vector3(_horizontalMinPosition, transform.position.y, 0);
        }

        if (transform.position.y <= _verticalMinPosition)
        {
            transform.position = new Vector3(transform.position.x, _verticalMinPosition, 0);
        }
        else if (transform.position.y >= _verticalMaxPosition)
        {
            transform.position = new Vector3(transform.position.x, _verticalMaxPosition, 0);
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
}
