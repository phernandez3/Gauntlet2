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
    protected string MoveX;
    protected string MoveY;
    protected string FireX;
    protected string FireY;
    protected string Bomb;

    // Objects
    // public GameObject meleeHitbox;

    // Basic player stats
    public int score;
    public int keys;
    public int bombs;

    // Basic player constants
    public float hungerRate;
    public int hungerDamage;
    protected bool hungerTimerWaiting;
    public int foodHeal;

    // Per player class stats
    public string myClass;
    public int meleePower;
    public int rangePower;
    public float rangeSpeed;
    public float rangeLifetime;
    public GameObject bulletPrefab;
    public int armor;
    public int magic;

    // Tracking stuff
    protected GameObject currentBullet;
    public float bombCooldown;
    protected float lastBombTime;

    // Move
    // MeleeAttack
    // RangedAttack
    // TakeDamage(int)
    // Die

    // PlayerInputs
    // Bomb
    // Lose HP over time

    protected void Awake()
    {
        InitInputs();
        lastBombTime = Time.time;
    }

    protected void Update()
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
            Vector3 Move = transform.localPosition;
            Move.x += Input.GetAxis(MoveX) * moveSpeed * Time.deltaTime;
            Move.z += Input.GetAxis(MoveY) * moveSpeed * Time.deltaTime * -1;
            transform.localPosition = Move; // Currently un-normalized?
        }
        else // If not inputting movement, then cancel all velocity.
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3();
        }
        if (Input.GetAxis(FireX) != 0 || Input.GetAxis(FireY) != 0)
        {
            // Turn to stick direction.
            Vector3 look = new Vector3(Input.GetAxis(FireX) * -1, 0f, Input.GetAxis(FireY));
            transform.rotation = Quaternion.LookRotation(look * -1, Vector3.forward);

            // Fire
            Fire();
            
        }

        if (Input.GetAxis(Bomb) != 0)
        {
            if (bombCooldown < Time.time - lastBombTime)
            {
                if (bombs > 0)
                {

                    --bombs;

                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                    foreach (GameObject enemy in enemies) // Do magic damage to every enemy in scene.
                    {
                        if (enemy.GetComponent<BaseEnemy>() != null)
                        {
                            enemy.GetComponent<BaseEnemy>().TakeDamage(magic);
                        }
                    }

                    print("Player" + controllerSlot + ": Bomb! " + bombs + " remaining.");
                }
                else
                {
                    print("Player" + controllerSlot + ": No bombs!");
                }
            }

            lastBombTime = Time.time;
        }
    }

    protected void Fire()
    {
        if (currentBullet == null) // Using the original game's "one bullet out at once" rule.
        {
            // Since the player model itself rotates, 
            // I'm just choosing to spawn an object and give it forward velocity based on the player's rotation.
            currentBullet = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            currentBullet.GetComponent<Rigidbody>().AddForce(currentBullet.transform.forward * (rangeSpeed), ForceMode.Impulse);

            // Give the bullet info.
            currentBullet.GetComponent<Bullet>().targetTag = "Enemy";
            currentBullet.GetComponent<Bullet>().damage = rangePower;
            currentBullet.GetComponent<Bullet>().LifetimeDestroy(rangeLifetime);
            currentBullet.GetComponent<Bullet>().myShooter = this.gameObject;
        }
    }

    protected void Hunger()
    {
        if (!hungerTimerWaiting)
        {
            StartCoroutine(HungerTimer());
        }
    }

    protected IEnumerator HungerTimer()
    {
        hungerTimerWaiting = true;
        yield return new WaitForSeconds(hungerRate);
        hungerTimerWaiting = false;
        TakeDamage(hungerDamage);
    }

    /// <summary>
    /// Use this instead of TakeDamage when you want a player to get hurt from anything that will factor in armor (enemies).
    /// </summary>
    /// <param name="armoredDamage"></param> Input damage to take here, which will factor in player's armor.
    public void TakeArmoredDamage(int armoredDamage)
    {
        // Players take damage equal to the attack's power, minus half their armor rounded down.
        // Ex: if 4 armor, 10 damage >>> 8 damage. (Same with 5 armor.)
        int damage = armoredDamage - (armor / 2);
        // print(damage);
        TakeDamage(damage); // Take this final amount of damage and do regular damage stuff with it.
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            healthPoints += foodHeal;
        }
        if (other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            bombs++;
        }
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            keys++;
        }
        if (other.CompareTag("Door") && keys > 0)
        {
            Destroy(other.gameObject);
            keys--;
        }
        if (other.CompareTag("Exit"))
        {
            print("Please set up level EXIT behavior!");
            // Insert code to exit here.
        }
    }
}
