/*
 * Eric Swartz
 * Sets death enemy to rapidly attack player target.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : BaseEnemy
{
    private int trackAttacks;


    //Set death stats here
    private void Start()
    {
        attackDamage = 10;
        attackRange = 3;
    }


    private void LateUpdate()
    {
        if(inRange && timeBetweenAttacks == 0)
        {
            DemonAttack();
        }

        //This happens after death finished attacking
        if(timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;

            if(timeBetweenAttacks <= 0)
            {
                timeBetweenAttacks = 0;
            }
        }

        //After death deals 200 damage to any player
        if(trackAttacks >= 20)
        {
            Destroy(this.gameObject);
        }
    }


    //Death enemy will attack rapidly
    //Adjust death attack speed here
    private void DemonAttack()
    {
        closestPlayer.GetComponent<BasePlayer>().TakeArmoredDamage(attackDamage);
        timeBetweenAttacks = 0.1f;
        trackAttacks++;
    }
}
