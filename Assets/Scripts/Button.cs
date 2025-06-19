using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    #region Declarations
    private bool hasBeenTriggered;
    private GameManager gameManager;
    private UIManager uiManager;
    [SerializeField] private bool isMoving;
    [SerializeField] private GameObject connection;
    private Rigidbody2D rigidBody;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
        if(rigidBody != null)
        {
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }
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

    #region Moving
    public void MovingBall()
    {
        if(isMoving)
        {
            //disable button function
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make it touch connector
        if(collision != null)
        {
            //make rb poof
            //enable button function
        }
    }
    #endregion
}

//things to fix in MOVING for PI
