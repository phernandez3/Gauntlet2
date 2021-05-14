/*
 * Eric Swartz
 * Sets grunt enemy to attack a player once in melee range.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : BaseEnemy
{
    //Set grunt stats here
    private void Start()
    {
        attackDamage = 1;
        attackRange = 3;
    }


    private void LateUpdate()
    {
        if(inRange && timeBetweenAttacks == 0)
        {
            GruntAttack();
        }

        //This happens after grunt finished attacking
        if(timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;

            if(timeBetweenAttacks <= 0)
            {
                timeBetweenAttacks = 0;
            }
        }
    }


    //Adjust grunt attack speed here
    private void GruntAttack()
    {
        closestPlayer.GetComponent<BasePlayer>().TakeArmoredDamage(attackDamage);
        timeBetweenAttacks = 1;
    }
}
