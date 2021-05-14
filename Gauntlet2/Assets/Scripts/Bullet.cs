using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public string targetTag;
    [HideInInspector] public int damage;
    [HideInInspector] public bool rude;
    [HideInInspector] public GameObject myShooter;

    public void LifetimeDestroy(float lifetime)
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerStuff(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TriggerStuff(other);
    }

    private void TriggerStuff(Collider other)
    {
        if (other.gameObject != myShooter)
        {
            // If friendly fire, then ignore targetTag and work on either unit type.
            if (rude)
            {
                if (other.CompareTag("Enemy") || other.CompareTag("Player"))
                {
                    if (other.gameObject.GetComponent<BasePlayer>() != null)
                    {
                        other.gameObject.GetComponent<BasePlayer>().TakeArmoredDamage(damage);
                    }
                    else if (other.gameObject.GetComponent<BaseUnit>() != null)
                    {
                        other.gameObject.GetComponent<BaseUnit>().TakeDamage(damage);
                    }
                }
            }
            else

            // If not friendly fire, then refer to target tag.
            if (other.CompareTag("Enemy") && targetTag == "Enemy")
            {
                if (other.gameObject.GetComponent<BaseEnemy>() != null)
                {
                    other.gameObject.GetComponent<BaseEnemy>().TakeDamage(damage);
                    Destroy(this.gameObject);
                }
                else
                {
                    print("Enemy-tagged object did not have BaseEnemy script or any of its children.");
                }
            }

            if (other.CompareTag("Player") && targetTag == "Player")
            {
                if (other.gameObject.GetComponent<BasePlayer>() != null)
                {
                    other.gameObject.GetComponent<BasePlayer>().TakeArmoredDamage(damage);
                    Destroy(this.gameObject);
                }
                else
                {
                    print("Player-tagged object did not have BasePlayer script or any of its children.");
                }
            }

            // Generic stuff that always checks.
            if (other.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
            }

            if (other.CompareTag("Food"))
            {
                if (other.gameObject.GetComponent<Food>() != null)
                {
                    if (other.gameObject.GetComponent<Food>().destroyedOnShot)
                    {
                        Destroy(other.gameObject);
                    }
                }
                Destroy(this.gameObject);
            }
        }
    }

}
