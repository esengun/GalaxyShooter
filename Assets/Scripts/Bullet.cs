using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        if (transform.position.y >= PlayArea.SharedInstance.bulletDestroyPositionY)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.up * Time.deltaTime * _speed);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
