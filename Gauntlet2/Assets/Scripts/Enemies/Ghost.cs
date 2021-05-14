/*
 * Eric Swartz
 * Sets ghost enemy to kamikaze once hitting a player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    //Set ghost stats here
    private void Start()
    {
        attackDamage = 1;
        attackRange = 1;
    }


    private void LateUpdate()
    {
        if(inRange)
        {
            closestPlayer.GetComponent<BasePlayer>().TakeArmoredDamage(attackDamage);
            base.isDead = true;
        }
    }
}
