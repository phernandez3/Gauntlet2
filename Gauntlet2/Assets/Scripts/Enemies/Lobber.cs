/*
 * Eric Swartz
 * Lobber
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : BaseEnemy
{
    public Vector3 currentPos, heightPos, moveToPos, newPos;
    public bool checkToCalculate = false;
    public bool isThrowing = false;

    public float timeDuration = 0.35f;
    public float timeStart;
    public float u;

    //Set lobber stats here
    private void Start()
    {
        attackRange = 10;
    }


    private void LateUpdate()
    {
        if(inRange)
        {
            LobberAttack();
        }

        //------------------------------------------------
        if(checkToCalculate)
        {
            checkToCalculate = false;
            isThrowing = true;
            timeStart = Time.time;
        }

        //Player is now jumping diagonally
        if (isThrowing)
        {
            u = (Time.time - timeStart) / timeDuration;

            if (u >= 1)
            {
                u = 1;
                isThrowing = false;
            }

            //Interpolate between currentPos and heightPos, then heightPos and moveToPos
            Vector3 ascending, descending;
            ascending = (1 - u) * currentPos + u * heightPos;
            descending = (1 - u) * heightPos + u * moveToPos;

            newPos = (1 - u) * ascending + u * descending;

            transform.position = newPos;
        }
        //---------------------------------------------------------
    }


    //Lobber will toss bombs toward player
    //Bombs will go over walls
    private void LobberAttack()
    {

    }
}
