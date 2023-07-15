using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] protected float _powerupDuration = 4f;

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);
}
