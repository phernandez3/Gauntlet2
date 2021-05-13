/*
 * Eric Swartz
 * Sets up health and move speed variables, tracks damage taken, and if is dead
 * for all player classes, enemies, and generators.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public int healthPoints;
    public float moveSpeed;
    public bool isDead = false;


    public void TakeDamage(int damageAmount)
    {
        healthPoints -= damageAmount;
        Debug.Log("took damage");
        //if (healthPoints <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    //this is where player classes, enemies, and generators will take damage
}
