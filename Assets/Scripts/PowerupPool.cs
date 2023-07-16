using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPool : ObjectPool<Powerup>
{
    [SerializeField] private GameObject[] powerupPrefabs;
    [SerializeField] private float _powerupSpawnInterval = 3f;

    public override void Start()
    {
        if(powerupPrefabs.Length == 0)
        {
            Debug.LogError("Missing powerup prefabs");
            base.Start();
            return;
        }

        SharedInstance.pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            var randomPowerupIndex = Random.Range(0, powerupPrefabs.Length);
            tmp = Instantiate(powerupPrefabs[randomPowerupIndex]);
            var randomXpos = Random.Range(PlayArea.SharedInstance.horizontalMinPosition, PlayArea.SharedInstance.horizontalMaxPosition);
            tmp.transform.position = new Vector3(randomXpos, PlayArea.SharedInstance.powerUpSpawnPositionY, 0f);
            tmp.SetActive(false);
            SharedInstance.pooledObjects.Add(tmp);
        }
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(SpawnPowerup());
    }

    protected override void OnDisable()
    {
        StopCoroutine(SpawnPowerup());
    }

    IEnumerator SpawnPowerup()
    {
        while (true)
        {
            yield return new WaitForSeconds(_powerupSpawnInterval);
            var powerup = SharedInstance.GetPooledObject();
            if (powerup != null)
            {
                powerup.SetActive(true);
            }
        }
    }

    public override GameObject GetPooledObject()
    {
        var randomPowerup = Random.Range(0, amountToPool);

        if (!pooledObjects[randomPowerup].activeInHierarchy)
        {
            return pooledObjects[randomPowerup];
        }
        return null;
    }
}
