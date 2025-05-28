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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
    }
    protected virtual void MoveHandle()
    { }
    protected virtual void Shoot()
    { }
    protected virtual void Jump()
    { }
    protected virtual void GroundCheck()
    { }
}
