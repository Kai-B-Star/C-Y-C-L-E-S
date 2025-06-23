using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    #region Declarations
    [SerializeField] private bool isFloorButton;
    [SerializeField] private bool isElectricLever;
    [SerializeField] private bool isPIButton;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject wall2;
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
        if(isPIButton)
        {
            wall2.SetActive(false);
        }
        if(isElectricLever)
        {
            LightsOut();
        }
    }
    public void WallAppear()
    {
        wall.SetActive(true);
        if(isPIButton)
        {
            wall2.SetActive(true);
        }
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
