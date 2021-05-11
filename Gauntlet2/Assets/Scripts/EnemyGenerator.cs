using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : BaseUnit
{
    [SerializeField] private List<GameObject> enemiesAlive = new List<GameObject>();     //Tracks living enemies for this generator
    [SerializeField] private List<GameObject> enemiesDead = new List<GameObject>();      //Tracks when an enemy has died

    [SerializeField] private int spawnLimit;                 //Sets a capacity for how many enemies can be spawned
    [SerializeField] private float timeBetweenSpawn = 0;     //Safety net to prevent enemies from spawning too quickly
    [SerializeField] private Transform spawnPoint;           //Where enemies will appear once spawned
    [SerializeField] private GameObject enemyPrefab;         //Enemy type for THIS generator goes here


    private void Awake()
    {
        healthPoints = 5;
    }


    private void Update()
    {
        //Enemies that have died are added to the enemiesDead list
        foreach(GameObject gObjEnemy in enemiesAlive)
        {
            if(gObjEnemy.GetComponent<BaseUnit>().isDead)
            {
                enemiesDead.Add(gObjEnemy);
            }
        }

        //Enemies NOW dead are removed from enemiesAlive list, then destroyed
        foreach(GameObject gObjEnemy in enemiesDead)
        {
            Debug.Log("enemy currently in dead list");
            enemiesAlive.Remove(gObjEnemy);
            Debug.Log("dead enemy removed from alive list");
            Destroy(gObjEnemy);
        }
        enemiesDead.Clear();
    }


    private void FixedUpdate()
    {
        //Checks for if an enemy IS blocking this generator
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right, out hit, 1f))
        {
            if(hit.collider != null)
            {
                return;
            }
        }

        //Once generator is not being blocked and has room to spawn more enemies
        //And if the number of enemies alive to this generator is less than the set capacity
        //Then wait out the timer for when the next spawn can happen
        //Then spawn an enemy
        if(enemiesAlive.Count < spawnLimit && timeBetweenSpawn == 0)
        {
            EnemySpawn();

            //This determines the time interval between enemy spawning
            timeBetweenSpawn = 3;
        }

        //Happens once an enemy has spawned and is NOT blocking this generator
        if(timeBetweenSpawn > 0)
        {
            timeBetweenSpawn -= Time.deltaTime;

            if(timeBetweenSpawn <= 0)
            {
                timeBetweenSpawn = 0;
            }
        }
    }


    //Instantiates the enemy prefab for this generator
    private void EnemySpawn()
    {
        GameObject gObjEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemiesAlive.Add(gObjEnemy);
    }
}
