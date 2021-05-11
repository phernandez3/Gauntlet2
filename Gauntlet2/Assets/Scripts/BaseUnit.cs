using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public int healthPoints;
    public int moveSpeed;


    public void TakeDamage(int damageAmount)
    {
        //healthPoints -= damageAmount;
        //if(healthPoints <= 0)
        //{
        //    Destroy(this);
        //}
    }
}
