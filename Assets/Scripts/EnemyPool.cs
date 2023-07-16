using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private float _enemySpawnInterval = 3f;

    public override void Start()
    {
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
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(SpawnEnemy());
    }

    protected override void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(_enemySpawnInterval);
            var enemy = SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                enemy.SetActive(true);
            }
        }        
    }

}
