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
        if (healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //this is where player classes, enemies, and generators will take damage
}
