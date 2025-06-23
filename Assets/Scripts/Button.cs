using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    #region Declarations
    private bool hasBeenTriggered;
    private GameManager gameManager;
    private UIManager uiManager;
    [SerializeField] private GameObject connection;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
    }
    #endregion

    #region Button
    public void ButtonClick()
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            uiManager.Choice();
        }
    }
    #endregion
}
