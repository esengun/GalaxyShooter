using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private AudioClip _explosionSound;

    public Action EnemyKilled;

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
        Instantiate(_explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_explosionSound, Camera.main.transform.position);
        if (other.GetComponent<Bullet>() != null || other.GetComponent<TripleBullet>() != null)
        {
            GameManager.SharedInstance.OnEnemyKilled();
            EnemyKilled?.Invoke();
            DisableEnemy();
        }
        else if (other.GetComponent<Player>() != null)
        {
            DisableEnemy();
        }        
    }

    public void DisableEnemy()
    {
        var randomXpos = UnityEngine.Random.Range(PlayArea.SharedInstance.horizontalMinPosition, PlayArea.SharedInstance.horizontalMaxPosition);
        transform.position = new Vector3(randomXpos, PlayArea.SharedInstance.enemySpawnPositionY, 0f);
        gameObject.SetActive(false);
    }
}
