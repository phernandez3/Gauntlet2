using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    public GameObject[] allPlayers;     //References the four players for determining which is closer


    public void Awake()
    {
        moveSpeed = 5f;
    }


    public void Update()
    {
        MoveToClosestPlayer();
    }


    //Enemy will find which player is closest to it
    //And begin moving toward THAT player
    public void MoveToClosestPlayer()
    {
        //
        float distanceToClosestPlayer = Mathf.Infinity;

        //Resets variable
        GameObject closestPlayer = null;

        //Goes through array to check what this enemy is closer to, and follow
        foreach(GameObject currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - transform.position).sqrMagnitude;
            if(distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }

        //Basic moving toward whichever player is nearest to this enemy
        transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, moveSpeed * Time.deltaTime);
        Debug.DrawLine(transform.position, closestPlayer.transform.position);
    }
}
