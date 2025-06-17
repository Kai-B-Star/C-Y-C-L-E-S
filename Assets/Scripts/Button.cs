using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //connect to gameManager, OutOfPuzzle
    private bool hasBeenTriggered;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    public void ButtonClick()
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            gameManager.OutOfPuzzle();
        }
    }
}
