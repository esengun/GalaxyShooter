using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerup : Powerup
{
    [SerializeField] private float _boostMultiplier = 2f;


    protected override void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            base.OnTriggerEnter2D(other);
            player.SetPowerupSpeedBoost(_boostMultiplier, _powerupDuration);
            DisableEnemy();
        }
    }
}
