using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : EnemyBase
{
    #region RedStats
    protected override void SetStats()
    {
        //tank small one
        hp = 8;
        speed = 1;
    }
    #endregion
}
