using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var shooter = other.GetComponent<Shooter>();
        if(shooter != null)
        {
            shooter.SetPowerupTripleShot(true);
            Destroy(gameObject);
        }
    }
}
