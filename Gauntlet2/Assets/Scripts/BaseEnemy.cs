using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    public GameObject[] allPlayers;     //References the four players to determine which is closer


    public void Awake()
    {
        moveSpeed = 5f;
    }


    public void Update()
    {
        MoveToClosestPlayer();
    }


    public void MoveToClosestPlayer()
    {
        float distanceToClosestPlayer = Mathf.Infinity;
        
        GameObject closestPlayer = null;

        foreach(GameObject currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - transform.position).sqrMagnitude;
            if(distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, moveSpeed * Time.deltaTime);
        Debug.DrawLine(this.transform.position, closestPlayer.transform.position);
    }
}
