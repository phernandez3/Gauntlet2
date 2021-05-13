using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public string targetTag;
    [HideInInspector] public int damage;

    public void LifetimeDestroy(float lifetime)
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
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
                    break;
                case "Player":
                    if (other.gameObject.GetComponent<BasePlayer>() != null)
                    {
                        other.gameObject.GetComponent<BasePlayer>().TakeArmoredDamage(damage);
                    }
                    else
                    {
                        print("Player-tagged object did not have BasePLayer script or any of its children.");
                    }
                    break;
                case "Wall":
                    Destroy(this.gameObject);
                    break;
                case "Food":
                    // Check if it's breakable, if so then kill it.
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
