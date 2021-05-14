﻿/*
 * Eric Swartz
 * Sets up moving behavior and attack range for all enemies.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    public List<GameObject> activePlayers = new List<GameObject>();       //References any players that are currently in game
    public List<GameObject> inactivePlayers = new List<GameObject>();     //Tracks how many inactive players there are

    public GameObject closestPlayer;     //Tracks which player THIS enemy is currently following

    public int attackDamage;                 //ONLY sets up attack damage variable
    public float attackRange;                //ONLY sets up attack range variable
    public float timeBetweenAttacks = 0;     //Set up for enemy types that attack every so often
    public bool inRange = false;             //Checks for if player target is in range of THIS enemy's attack


    public void FixedUpdate()
    {
        //THIS enemy will only start searching for players IF there are any active
        if (activePlayers.Count > 0)
        {
            //THIS enemy will stop moving once player is in range
            if (inRange)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 5;
            }

            MoveToClosestPlayer();
        }
    }


    public void Update()
    {
        //Killed players will be removed from activePlayers list
        //Also checks if an inactive player has joined back in
        foreach(GameObject player in inactivePlayers)
        {
            activePlayers.Remove(player);

            if(player.activeSelf)
            {
                activePlayers.Add(player);
            }
        }

        //Players joining in will be removed from inactivePlayers list
        //Also checks if player has been killed to then be considered inactive
        foreach(GameObject player in activePlayers)
        {
            inactivePlayers.Remove(player);

            if(!player.activeSelf)
            {
                inactivePlayers.Add(player);
            }
        }
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
        foreach(GameObject playerToFollow in activePlayers)
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