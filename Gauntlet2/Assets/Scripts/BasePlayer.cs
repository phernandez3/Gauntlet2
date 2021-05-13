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

    // Objects
    public GameObject meleeHitbox;

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
    public float rangeLifetime;
    public GameObject bulletPrefab;
    public int armor;
    public int magic;

    // Tracking stuff
    private GameObject currentBullet;
    private float bombCooldown;
    private float lastBombTime;

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

    /// <summary>
    /// Updates what inputs this player listens for.
    /// </summary>
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
            Fire();
            
        }
        if (Input.GetAxis(Bomb) != 0)
        {
            if (bombs > 0)
            {
                --bombs;
                print("Player" + controllerSlot + ": Bomb! " + bombs + " remaining.");
            }
            else
            {
                print("Player" + controllerSlot + ": No bombs!");
            }

        }
    }

    private void Fire()
    {
        if (currentBullet == null) // Using the original game's "one bullet out at once" rule.
        {
            // Since the player model itself rotates, 
            // I'm just choosing to spawn an object and give it forward velocity based on the player's rotation.
            GameObject bullet = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * (rangeSpeed), ForceMode.Impulse);

            // Give the bullet info.
            currentBullet = bullet;
            currentBullet.GetComponent<Bullet>().targetTag = "Enemy";
            currentBullet.GetComponent<Bullet>().damage = rangePower;
            currentBullet.GetComponent<Bullet>().LifetimeDestroy(rangeLifetime);
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

    public void TakeArmoredDamage(int armoredDamage)
    {
        // Players take damage equal to the attack's power, minus half their armor rounded down.
        // Ex: if 4 armor, 10 damage >>> 8 damage. (Same with 5 armor.)
        int damage = armoredDamage - (armor / 2);
        // print(damage);
        TakeDamage(damage); // Take this final amount of damage and do regular damage stuff with it.
    }
}
