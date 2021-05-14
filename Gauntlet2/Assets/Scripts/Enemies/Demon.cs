/*
 * Eric Swartz
 * Sets demon enemy to spit fireballs at player once in certain range.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : BaseEnemy
{
    [SerializeField] private GameObject fireballPrefab;     //Reference to fireball prefab goes here

    private GameObject currentFireball;     //Safety net for there to be only one fireball per THIS demon out at a time
    private float fireballSpeed = 5;        //How fast fireball will travel
    private float fireballLifespan = 1;     //How long fireball will last without hitting anything


    //Set demon stats here
    private void Start()
    {
        attackDamage = 1;
        attackRange = 20;
        healthPoints = 20;
    }


    private void LateUpdate()
    {
        if(inRange && timeBetweenAttacks == 0)
        {
            DemonAttack();
        }

        //This happens after demon finished attacking
        if(timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;

            if(timeBetweenAttacks <= 0)
            {
                timeBetweenAttacks = 0;
            }
        }
    }


    //Carrying over Paul's Fire() function from BasePlayer script
    //Demon will shoot a fireball at a player
    //Adjust demon attack speed here
    private void DemonAttack()
    {
        if(currentFireball == null)
        {
            timeBetweenAttacks = 2;

            currentFireball = Instantiate(fireballPrefab, gameObject.transform.position, gameObject.transform.rotation);
            currentFireball.GetComponent<Rigidbody>().AddForce(currentFireball.transform.forward * (fireballSpeed), ForceMode.Impulse);

            currentFireball.GetComponent<Bullet>().targetTag = "Player";
            currentFireball.GetComponent<Bullet>().damage = attackDamage;
            currentFireball.GetComponent<Bullet>().LifetimeDestroy(fireballLifespan);
            currentFireball.GetComponent<Bullet>().myShooter = gameObject;
        }
    }
}
