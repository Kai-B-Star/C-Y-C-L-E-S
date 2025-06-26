using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    #region Declarations
    [SerializeField] private bool isFloorButton;
    [SerializeField] private bool isElectricLever;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject litBack;
    [SerializeField] private GameObject darkBack;
    private bool isWallActive;
    #endregion

    #region MonoBehaviour
    public void Start()
    {
        if (isElectricLever)
        {
            lights.SetActive(true);
            litBack.SetActive(true);
            darkBack.SetActive(false);
        }
        isWallActive = true;
    }
    #endregion

    #region Lever
    public void Wall()
    {
        if(isWallActive == true)
        {
            WallGone();
            isWallActive = false;
        }
        else if(isWallActive == false)
        {
            WallAppear();
            isWallActive = true;
        }
    }
    public void WallGone()
    {
        wall.SetActive(false);
        if(isElectricLever)
        {
            LightsOut();
        }
    }
    public void WallAppear()
    {
        wall.SetActive(true);
        if(isElectricLever)
        {
            LightsOn();
        }
    }
    #endregion

    #region Electricity
    public void LightsOn()
    {
        lights.SetActive(true);
        litBack.SetActive(true);
        darkBack.SetActive(false);
    }
    public void LightsOut()
    {
        lights.SetActive(false);
        litBack.SetActive(false);
        darkBack.SetActive(true);
    }
    #endregion

    #region OnTrigger2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFloorButton && collision.gameObject == box)
        {
            WallGone();
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isFloorButton && collision.gameObject == box)
        {
            WallAppear();
        }
    }
    #endregion
}

//gotta do changes for PH
