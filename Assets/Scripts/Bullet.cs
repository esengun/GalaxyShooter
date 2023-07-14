using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _posYToDestroy;

    private void Update()
    {
        if (transform.position.y >= _posYToDestroy)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.up * Time.deltaTime * _speed);   
    }
}
