using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    #region Declarations
    protected UIManager uiManager;
    protected GameManager gameManager;
    #endregion
    private void Awake()
    {
        uiManager = UIManager.instance;
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
    }
    public virtual void Move()
    { }
}
