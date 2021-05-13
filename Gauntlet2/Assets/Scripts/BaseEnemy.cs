/*
 * Eric Swartz
 * Sets up moving behavior and attack range for all enemies.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    public GameObject[] allPlayers;      //References the four players for determining which is closer
    public GameObject closestPlayer;     //Tracks which player THIS enemy is currently following

    public int attackDamage;                 //ONLY sets up attack damage variable
    public float attackRange;                //ONLY sets up attack range variable
    public float timeBetweenAttacks = 0;     //Set up for enemy types that attack every so often
    public bool inRange = false;             //Checks for if player target is in range of THIS enemy's attack


    public void Update()
    {
        //THIS enemy will stop moving once player is in range
        if(inRange)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 5;
        }

        MoveToClosestPlayer();
    }


    //Enemy will find which player is closest to it
    //And begin moving toward THAT player
    public void MoveToClosestPlayer()
    {
        //Sets closest player to infinite value
        float distanceToClosestPlayer = Mathf.Infinity;
        
        //Resets closestPlayer variable
        closestPlayer = null;

        //Goes through array to check which player THIS enemy is closer to
        //Then follows THAT player
        foreach(GameObject playerToFollow in allPlayers)
        {
            //Goes through and finds distance between THIS enemy and each player
            float distanceToAPlayer = (playerToFollow.transform.position - transform.position).sqrMagnitude;

            //Switches which player gameObject to follow here
            if(distanceToAPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToAPlayer;
                closestPlayer = playerToFollow;
            }
        }

        Debug.DrawLine(transform.position, closestPlayer.transform.position);

        //Basic moving toward whichever player is nearest to this enemy
        transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, moveSpeed * Time.deltaTime);

        //Checks for if player being followed is in range of THIS enemy attack range
        if(distanceToClosestPlayer < attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
}
