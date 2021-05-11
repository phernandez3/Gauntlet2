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
    private string MoveX;
    private string MoveY;
    private string FireX;
    private string FireY;
    private string Bomb;

    // Basic player stats
    public int score;
    public int keys;
    public int bombs;

    // Basic player constants
    public float hungerRate;
    public int hungerDamage;
    private bool hungerTimerWaiting;

    // Per player class stats
    public int meleePower;
    public int rangePower;
    public float rangeSpeed;
    public GameObject bulletPrefab;
    public int armor;
    public int magic;

    //[SerializeField] private List<GameObject> currentBullets;
    private GameObject currentBullet;

    // Move
    // MeleeAttack
    // RangedAttack
    // TakeDamage(int)
    // Die

    // PlayerInputs
    // Bomb
    // Lose HP over time

    private void Awake()
    {
        InitInputs();
    }

    private void Update()
    {
        PlayerActions();
        Hunger();
    }

    public void InitInputs()
    {
        MoveX = "MoveX" + controllerSlot;
        MoveY = "MoveY" + controllerSlot;
        FireX = "FireX" + controllerSlot;
        FireY = "FireY" + controllerSlot;
        Bomb = "Bomb" + controllerSlot;
    }


    public void PlayerActions()
    {
        if (Input.GetAxis(MoveX) != 0 || Input.GetAxis(MoveY) != 0)
        {
            Vector2 Move = transform.localPosition;
            Move.x += Input.GetAxis(MoveX) * moveSpeed * Time.deltaTime;
            Move.y += Input.GetAxis(MoveY) * moveSpeed * Time.deltaTime * -1;
            transform.localPosition = Move; // Currently un-normalized?
        }
        if (Input.GetAxis(FireX) != 0 || Input.GetAxis(FireY) != 0)
        {
            // Turn to stick direction.
            Vector3 look = new Vector3(Input.GetAxis(FireX) * -1, Input.GetAxis(FireY), 0f);
            transform.rotation = Quaternion.LookRotation(look * -1, Vector3.forward);

            // Fire
            
        }
        if (Input.GetAxis(Bomb) != 0)
        {

        }
    }

    private void Fire()
    {
        if (currentBullet == null)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * (rangeSpeed), ForceMode.Impulse);
            currentBullet = bullet;
            currentBullet.GetComponent<Bullet>().damage = rangePower;
        }
        
    }

    private void Hunger()
    {
        if (!hungerTimerWaiting)
        {
            StartCoroutine(HungerTimer());
        }
    }

    private IEnumerator HungerTimer()
    {
        hungerTimerWaiting = true;
        yield return new WaitForSeconds(hungerRate);
        hungerTimerWaiting = false;
        TakeDamage(hungerDamage);
    }


}
