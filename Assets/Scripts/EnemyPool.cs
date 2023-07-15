using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private float _enemySpawnInterval = 3f;

    private bool _isPlayerDead;

    public override void Start()
    {
        Player.PlayerDead += OnPlayerDead;
        SharedInstance.pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            var randomXpos = Random.Range(PlayArea.SharedInstance.horizontalMinPosition, PlayArea.SharedInstance.horizontalMaxPosition);
            tmp.transform.position = new Vector3(randomXpos, PlayArea.SharedInstance.enemySpawnPositionY, 0f);
            tmp.SetActive(false);
            SharedInstance.pooledObjects.Add(tmp);
        }
        StartCoroutine(SpawnEnemy());
    }

    private void OnPlayerDead()
    {
        _isPlayerDead = true;
    }

    IEnumerator SpawnEnemy()
    {
        while(true && !_isPlayerDead)
        {
            yield return new WaitForSeconds(_enemySpawnInterval);
            var enemy = SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                enemy.SetActive(true);
            }
        }        
    }

    private void OnDisable()
    {
        Player.PlayerDead -= OnPlayerDead;
    }

    private void OnDestroy()
    {
        StopCoroutine(SpawnEnemy());
    }

}
