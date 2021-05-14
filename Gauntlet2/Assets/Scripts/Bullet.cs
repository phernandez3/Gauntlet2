using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public string targetTag;
    [HideInInspector] public int damage;
    [HideInInspector] public bool rude;

    public void LifetimeDestroy(float lifetime)
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If it's a friendly fire bullet...
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

            if (other.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
            }

            if (other.CompareTag("Food"))
            {
                Destroy(this.gameObject);
            }

        }
        else

        // If not friendly fire, then refer to target tag.
        if (other.CompareTag(targetTag))
        {
            switch (targetTag)
            {
                case "Enemy":
                    if (other.gameObject.GetComponent<BaseEnemy>() != null)
                    {
                        other.gameObject.GetComponent<BaseEnemy>().TakeDamage(damage);
                    }
                    else
                    {
                        print("Enemy-tagged object did not have BaseEnemy script or any of its children.");
                    }
                    Destroy(this.gameObject);
                    break;
                case "Player":
                    if (other.gameObject.GetComponent<BasePlayer>() != null)
                    {
                        other.gameObject.GetComponent<BasePlayer>().TakeArmoredDamage(damage);
                    }
                    else
                    {
                        print("Player-tagged object did not have BasePlayer script or any of its children.");
                    }
                    Destroy(this.gameObject);
                    break;
                case "Wall":
                    Destroy(this.gameObject);
                    break;
                case "Food":
                    // Check if it's breakable, if so then kill it.
                    Destroy(this.gameObject);
                    break;
            }
        }
    }

    // Copy all stuff here.
    private void OnTriggerStay(Collider other)
    {
        // If it's a friendly fire bullet...
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

            if (other.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
            }

            if (other.CompareTag("Food"))
            {
                Destroy(this.gameObject);
            }

        }
        else

        if (other.CompareTag(targetTag))
        {
            switch (targetTag)
            {
                case "Enemy":
                    if (other.gameObject.GetComponent<BaseEnemy>() != null)
                    {
                        other.gameObject.GetComponent<BaseEnemy>().TakeDamage(damage);
                    }
                    else
                    {
                        print("Enemy-tagged object did not have BaseEnemy script or any of its children.");
                    }
                    Destroy(this.gameObject);
                    break;
                case "Player":
                    if (other.gameObject.GetComponent<BasePlayer>() != null)
                    {
                        other.gameObject.GetComponent<BasePlayer>().TakeArmoredDamage(damage);
                    }
                    else
                    {
                        print("Player-tagged object did not have BasePlayer script or any of its children.");
                    }
                    Destroy(this.gameObject);
                    break;
                case "Wall":
                    Destroy(this.gameObject);
                    break;
                case "Food":
                    // Check if it's breakable, if so then kill it.
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}
