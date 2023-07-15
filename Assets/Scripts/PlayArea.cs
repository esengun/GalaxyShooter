using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    public static PlayArea SharedInstance;

    [SerializeField] public float verticalMaxPosition = 4f;
    [SerializeField] public float verticalMinPosition = -4f;

    [SerializeField] public float horizontalMaxPosition = 8f;
    [SerializeField] public float horizontalMinPosition = -8f;


    [SerializeField] public float bulletDestroyPositionY = 5f;


    [SerializeField] public float enemyDestroyPositionY = -5f;
    [SerializeField] public float enemySpawnPositionY = 5f;
    
    [SerializeField] public float powerUpSpawnPositionY = 5f;
    [SerializeField] public float powerUpDestroyPositionY = 5f;

    void Awake()
    {
        SharedInstance = this;
    }
}
