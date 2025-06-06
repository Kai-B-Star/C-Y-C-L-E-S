using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    #region Declarations
    protected int hp;
    private float minimumDis = 100;
    protected float speed;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject deathExplosion;
    [SerializeField] private GameObject enemyTrail;
    private bool canTrail;
    #endregion

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        Move();
        StartCoroutine(TrailCooldown());
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

        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathExplosion);
        }
    }
    private IEnumerator TrailCooldown()
    {
        canTrail = false;
        yield return new WaitForSeconds(4f);
        canTrail = true;
        LeaveTrail();
        yield return new WaitForSeconds(2f);
        canTrail = false;
    }
    private void LeaveTrail()
    {
        Instantiate(enemyTrail);
        Destroy(enemyTrail, 10);
    }

    protected virtual void SetStats()
    { }
}
