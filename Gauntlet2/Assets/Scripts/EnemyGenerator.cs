using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : BaseUnit
{
    [SerializeField] private List<GameObject> enemiesAlive = new List<GameObject>();     //Tracks living enemies for this generator
    [SerializeField] private List<GameObject> enemiesDead = new List<GameObject>();      //Tracks when an enemy has died

    [SerializeField] private int spawnLimit;             //Sets a capacity for how many enemies can be spawned
    [SerializeField] private Transform spawnPoint;       //Where enemies will appear from once spawned
    [SerializeField] private GameObject enemyPrefab;     //Enemy type for THIS enemy generator goes here


    private void Awake()
    {
        healthPoints = 5;
    }


    private void Update()
    {
        
    }


    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right, out hit, 1f))
        {
            if(hit.collider != null)
            {
                Debug.Log("being blocked");
                return;
            }
        }
        Debug.Log("enemy spawned");
    }


    private void EnemySpawn()
    {
        if(spawnLimit < enemiesAlive.Count)
        {
            GameObject gObjEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
            enemiesAlive.Add(gObjEnemy);
            spawnLimit++;
        }
    }
    //need to check adjacent spaces to generator (raycast)
    //coroutine spawning
}
