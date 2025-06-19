using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : EnemyBase
{
    #region BlueStats
    protected override void SetStats()
    {
        //tank one
        hp = 5;
        speed = 2;
    }
    #endregion
}
