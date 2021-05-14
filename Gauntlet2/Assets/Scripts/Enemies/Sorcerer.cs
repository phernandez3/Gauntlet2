/*
 * Eric Swartz
 * Sets sorcerer enemy to attack a player once in melee range, and also
 * has them phasing in and out.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : BaseEnemy
{
    [SerializeField] private BoxCollider thisCollider;     //Make sure the larger collider goes here


    //Set sorcerer stats here
    private void Start()
    {
        attackDamage = 1;
        attackRange = 3;
        healthPoints = 20;

        StartCoroutine(PhaseInOut());
    }


    private void LateUpdate()
    {
        if(inRange && timeBetweenAttacks == 0)
        {
            SorcererAttack();
        }

        //This happens after sorcerer finished attacking
        if (timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;

            if (timeBetweenAttacks <= 0)
            {
                timeBetweenAttacks = 0;
            }
        }
    }


    //Adjust sorcerer attack speed here
    private void SorcererAttack()
    {
        closestPlayer.GetComponent<BasePlayer>().TakeArmoredDamage(attackDamage);
        timeBetweenAttacks = 1;
    }


    //Allows sorcerer to disappear briefly and avoid attacks
    private IEnumerator PhaseInOut()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            thisCollider.enabled = false;
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            thisCollider.enabled = true;
        }
    }
}
