using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    #region Declarations
    protected UIManager uiManager;
    protected GameManager gameManager;
    protected Rigidbody2D rigidBody;
    [SerializeField] protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float movementSpeed;
    protected bool isMoving;
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        uiManager = UIManager.instance;
        gameManager = GameManager.instance;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        MoveHandle();
        Shoot();
        Jump();
        GroundCheck();
    }
    #endregion

    #region OnTrigger2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
    }
    #endregion

    #region PlayerFreeze
    public void PlayerFreeze()
    {
        movementSpeed = 0;
    }
    public void PlayerUnfreeze()
    {
        movementSpeed = 10;
    }

    #endregion

    #region Virtuals
    protected virtual void MoveHandle()
    { }
    protected virtual void Shoot()
    { }
    protected virtual void Jump()
    { }
    protected virtual void GroundCheck()
    { }
    #endregion
}
