using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string targetTag;
    public int damage;
    public float lifetime;

    private void Awake()
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
                    break;
                case "Player":
                    if (other.gameObject.GetComponent<BasePlayer>() != null)
                    {
                        other.gameObject.GetComponent<BasePlayer>().TakeDamage(damage);
                    }
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
