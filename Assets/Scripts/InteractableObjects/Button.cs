using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    #region Declarations
    private bool hasBeenTriggered;
    private UIManager uiManager;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
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
