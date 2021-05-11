using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : BaseUnit
{
    // Unit
    // public int health;
    // public float moveSpeed;

    // Player-controller stuff
    public int controllerSlot;
    public string MoveX;
    public string MoveY;
    public string FireX;
    public string FireY;
    public string Bomb;

    // Basic player stats
    public int score;
    public int keys;
    public int bombs;

    // Per player class stats
    public int meleePower;
    public int rangePower;
    public float rangeSpeed;
    public GameObject bulletPrefab;
    public int armor;

    public int magic;


    // Move
    // MeleeAttack
    // RangedAttack
    // TakeDamage(int)
    // Die

    // PlayerInputs
    // Bomb
    // Lose HP over time

    
    public void InitInputs()
    {
        MoveX = "MoveX" + controllerSlot;
        MoveY = "MoveY" + controllerSlot;
        FireX = "FireX" + controllerSlot;
        FireY = "FireY" + controllerSlot;
        Bomb = "Bomb" + controllerSlot;
    }



}
