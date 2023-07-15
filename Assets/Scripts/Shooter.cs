using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooter : MonoBehaviour
{
    public bool _canTripleShot { get; private set; }

    [SerializeField] private float _fireRate = 0.5f;
    private float nextFire = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + _fireRate;
            GameObject bullet;

            if (_canTripleShot)
            {
                bullet = TripleBulletPool.SharedInstance.GetPooledObject();
            }
            else
            {
                bullet = BulletPool.SharedInstance.GetPooledObject();
            }
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
            }
        }        
    }

    public void SetPowerupTripleShot(bool isOn, float duration)
    {
        _canTripleShot = isOn;
        StartCoroutine(TripleShotPowerDownRoutine(duration));
    }

    IEnumerator TripleShotPowerDownRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        _canTripleShot = false;
    }
}
