using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : EnemyBase
{
    #region GreenStats
    protected override void SetStats()
    {
        //weak one
        hp = 1;
        speed = 3;
    }
    #endregion
}
