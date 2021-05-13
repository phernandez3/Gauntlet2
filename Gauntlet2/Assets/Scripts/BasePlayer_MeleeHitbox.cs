using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer_MeleeHitbox : MonoBehaviour
{

    public bool meleeTargetDetected;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<BaseEnemy>() != null)
            {
                
            }
        }
    }
}
