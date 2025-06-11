using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
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
    private float spawnRate = 0.5f;
    #endregion

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
    public void Move()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= minimumDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.up = target.position - transform.position;
        }
    }
    public void TakeDamage()
    {
        hp --;
        animator.SetTrigger("IsDamaged");

        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathExplosion, transform.position, transform.rotation);
        }
    }
    private void LeaveTrail()
    {
        Instantiate(enemyTrail, transform.position, transform.rotation);
    }

    protected virtual void SetStats()
    { }
}
