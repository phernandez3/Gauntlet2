using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseUnit
{
    //integrate findobjectsoftype into fixed array[]
    public GameObject[] allPlayers;

    public void Update()
    {
        FindClosestPlayer();
    }


    public void FindClosestPlayer()
    {
        float distanceToClosestPlayer = Mathf.Infinity;
        
        //BasePlayer closestPlayer = null;
        //BasePlayer[] allPlayers = GameObject.FindObjectsOfType<BasePlayer>();

        foreach(GameObject currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }
        Debug.DrawLine(this.transform.position, closestPlayer.transform.position);
    }
}
