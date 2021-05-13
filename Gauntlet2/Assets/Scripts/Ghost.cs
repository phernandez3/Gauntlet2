/*
 * Eric Swartz
 * Sets ghost enemy to kamikaze once hitting a player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            base.isDead = true;
        }
    }
}
