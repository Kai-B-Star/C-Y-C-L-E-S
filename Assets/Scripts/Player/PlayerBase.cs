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
    protected float movementSpeed = 10;
    protected bool isMoving;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    protected int health = 3;

    public int Health { get => health; set => health = value; }
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        uiManager = UIManager.instance;
        gameManager = GameManager.instance;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        MoveHandle();
        Shoot();
        Jump();
        GroundCheck();
        GunDirection();
    }
    #endregion

    #region OnTrigger2D & OnCollision2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            gameManager.LoseLives();
            animator.SetTrigger("IsDamaged");
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
    protected virtual void GunDirection()
    { }
    #endregion
}
