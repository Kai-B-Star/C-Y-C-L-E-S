using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    #region Declarations
    [SerializeField] private bool isTriangle;
    [SerializeField] private bool isSquare;
    [SerializeField] private GameObject triangleActive;
    [SerializeField] private GameObject triPlatTop;
    [SerializeField] private GameObject triPlatBottom;
    [SerializeField] private GameObject squareActive;
    [SerializeField] private GameObject squaPlatTop;
    [SerializeField] private GameObject squaPlatBottom;
    #endregion

    #region Collect
    public void Collect()
    {
        if (isTriangle)
        {
            UnlockTriangle();
        }
        else if (isSquare)
        {
            UnlockSquare();
        }
        Destroy(gameObject);
    }
    #endregion

    #region Unlocks
    public void UnlockTriangle()
    {
        triangleActive.SetActive(true);
        triPlatTop.SetActive(false);
        triPlatBottom.SetActive(true);
    }
    public void UnlockSquare()
    {
        squareActive.SetActive(true);
        squaPlatTop.SetActive(false);
        squaPlatBottom.SetActive(true);
    }
    #endregion

    #region OnTrigger2D
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collect();
    }
    #endregion
}
