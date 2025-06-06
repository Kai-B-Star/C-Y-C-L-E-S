using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Declarations
    private int speed = 5;
    private Rigidbody2D rigidBody;
    #endregion

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }
    public void GoInDirection(Vector2 direction)
    {
        rigidBody.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.TakeDamage();
        }
    }
}
