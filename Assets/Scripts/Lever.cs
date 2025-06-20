using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    #region Declarations
    [SerializeField] private bool isFloorButton;
    [SerializeField] private GameObject wall;
    #endregion

    #region Lever
    public void Wall()
    {
        if(wall != null)
        {
            WallGone();
        }
        else if(wall == null)
        {
            WallAppear();
        }
    }
    public void WallGone()
    {
        wall.SetActive(false);
    }
    public void WallAppear()
    {
        wall.SetActive(true);
    }
    #endregion 

    #region FloorButton
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFloorButton)
        {
            WallGone();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isFloorButton)
        {
            WallAppear();
        }
    }
    #endregion
}

//gotta do changes for PH
