using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] protected float _powerupDuration = 4f;


    private void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speed);
            if (transform.position.y <= PlayArea.SharedInstance.powerUpDestroyPositionY)
            {
                DisableEnemy();
            }
        }
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);

    protected void DisableEnemy()
    {
        var randomXpos = Random.Range(PlayArea.SharedInstance.horizontalMinPosition, PlayArea.SharedInstance.horizontalMaxPosition);
        transform.position = new Vector3(randomXpos, PlayArea.SharedInstance.powerUpSpawnPositionY, 0f);
        gameObject.SetActive(false);
    }
}
