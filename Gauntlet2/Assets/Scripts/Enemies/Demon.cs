/*
 * Eric Swartz
 * Sets demon enemy to spit fireballs at player once in certain range.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : BaseEnemy
{
    [SerializeField] private GameObject currentFireball;
    [SerializeField] private GameObject fireballPrefab;
    private float speed = 5; //probably rename
    private float lifespan = 1; //probably rename


    //Set demon stats here
    private void Start()
    {
        healthPoints = 10;
        attackDamage = 1;
        attackRange = 20;
    }


    private void LateUpdate()
    {
        if(inRange && timeBetweenAttacks == 0)
        {
            DemonAttack();
            Debug.Log("shot bullet");
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


    private void DemonAttack()
    {
        if(currentFireball == null) // Using the original game's "one bullet out at once" rule.
        {
            timeBetweenAttacks = 1;

            // Since the player model itself rotates, 
            // I'm just choosing to spawn an object and give it forward velocity based on the player's rotation.
            currentFireball = Instantiate(fireballPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            currentFireball.GetComponent<Rigidbody>().AddForce(currentFireball.transform.forward * (speed), ForceMode.Impulse);

            Debug.Log("instantiated bullet");

            // Give the bullet info.
            currentFireball.GetComponent<Bullet>().targetTag = "Player";
            //currentFireball.GetComponent<Bullet>().rude = true;
            currentFireball.GetComponent<Bullet>().damage = attackDamage;
            currentFireball.GetComponent<Bullet>().LifetimeDestroy(lifespan);
            currentFireball.GetComponent<Bullet>().myShooter = this.gameObject;
            Debug.Log("qty");
        }
    }
}
