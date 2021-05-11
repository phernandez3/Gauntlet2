using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : BaseEnemy
{
    //start doing periodic damage to current player target once in range
    //set moveSpeed to 0 once in range
    private void Start()
    {
        attackRange = 3;
    }
}
