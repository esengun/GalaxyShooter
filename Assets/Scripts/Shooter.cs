using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _bulletPositionYOffset = 0.5f;

    [SerializeField] private float _fireRate = 0.5f;
    private float nextFire = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + _fireRate;

            GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = new Vector3(transform.position.x, transform.position.y + _bulletPositionYOffset, transform.position.z);
                bullet.SetActive(true);
            }
        }
        
    }
}
