using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    #region Declarations
    private float minimumDis = 100;
    [SerializeField] protected int hp; 
    [SerializeField] protected float speed;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject deathExplosion;
    [SerializeField] private GameObject enemyTrail;
    private Animator animator;
    [SerializeField] private Elevator elevator;
    private float spawnRate = 0.5f;
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        InvokeRepeating("LeaveTrail", 0, spawnRate);
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        target = GameObject.Find("Player").transform;
        SetStats();
    }
    private void Update()
    {
        Move();
    }
    #endregion

    #region Movement
    public void Move()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= minimumDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.up = target.position - transform.position;
        }
    }
    private void LeaveTrail()
    {
        GameObject trail = Instantiate(enemyTrail, transform.position, transform.rotation);
        Destroy(trail, 3f);
    }
    #endregion

    #region HP
    public void TakeDamage()
    {
        hp --;
        animator.SetTrigger("IsDamaged");

        if (hp <= 0)
        {
            Destroy(gameObject);
            elevator.AddRequirement();
            Instantiate(deathExplosion, transform.position, transform.rotation);
        }
    }
    #endregion

    #region Virtuals
    protected virtual void SetStats()
    { }
    #endregion
}
