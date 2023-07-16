using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : Powerup
{
    [SerializeField] private Sprite _shieldSprite;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            base.OnTriggerEnter2D(other);
            player.SetPowerupShield(_shieldSprite, _powerupDuration);
            DisableEnemy();
        }
    }
}
