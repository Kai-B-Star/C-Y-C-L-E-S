using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageable
{
    #region Declarations
    protected UIManager uiManager;
    protected GameManager gameManager;
    protected Rigidbody2D rigidBody;
    [SerializeField] protected Animator animator;
    protected float movementSpeed = 10;
    protected bool isMoving;
    protected bool isLeft;
    protected bool isRight;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    protected int health = 3;
    private bool isDead;
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
        EnemyBase enemy = collision.transform.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            TakeDamage();
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

    #region Damage
    public void TakeDamage()
    {
        health--;
        animator.SetTrigger("Damage");

        if (health <= 0 && !isDead)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }
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
