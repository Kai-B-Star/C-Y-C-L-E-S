using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    #region Declarations
    private bool hasBeenTriggered;
    private GameManager gameManager;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    #endregion

    #region Button
    public void ButtonClick()
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            gameManager.OutOfPuzzle();
        }
    }
    #endregion
}
