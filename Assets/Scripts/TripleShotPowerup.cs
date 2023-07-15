using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerup : Powerup
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        var shooter = other.GetComponent<Shooter>();
        if (shooter != null)
        {
            shooter.SetPowerupTripleShot(true, _powerupDuration);
            Destroy(gameObject);
        }
    }
}
