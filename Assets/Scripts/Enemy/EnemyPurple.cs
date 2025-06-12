using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPurple : EnemyBase
{
    protected override void SetStats()
    {
        //speedy one
        hp = 2;
        speed = 5;
    }
}
