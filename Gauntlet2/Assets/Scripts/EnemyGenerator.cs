using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : BaseUnit
{
    [SerializeField] private GameObject enemyPrefab;     //Enemy type for THIS enemy generator goes here


    private void Awake()
    {
        healthPoints = 5;
    }


    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right, out hit, 1f))
        {
            if(hit.collider != null)
            {
                Debug.Log("spawn enemy");
            }
            Debug.Log("being blocked");
        }
    }


    //need to check adjacent spaces to generator (raycast)
    //coroutine spawning
}
