using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        if (transform.position.y <= PlayArea.SharedInstance.enemyDestroyPositionY)
        {
            DisableEnemy();
        }
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>() != null || other.GetComponent<TripleBullet>() != null)
        {
            DisableEnemy();
        }
        else if (other.GetComponent<Player>() != null)
        {
            DisableEnemy();
        }
    }

    public void DisableEnemy()
    {
        var randomXpos = Random.Range(PlayArea.SharedInstance.horizontalMinPosition, PlayArea.SharedInstance.horizontalMaxPosition);
        transform.position = new Vector3(randomXpos, PlayArea.SharedInstance.enemySpawnPositionY, 0f);
        gameObject.SetActive(false);
    }
}
