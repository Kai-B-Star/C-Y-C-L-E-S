using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : PlayerBase
{
    #region Declarations
    private float moveX;
    private float moveY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    #endregion

    #region Movement
    protected override void MoveHandle()
    {
        Vector2 playerMovement;
        moveX = playerMovement.x = Input.GetAxisRaw("Horizontal");
        moveY = playerMovement.y = Input.GetAxisRaw("Vertical");
        rigidBody.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));

        rigidBody.MovePosition(rigidBody.position + playerMovement * movementSpeed * Time.fixedDeltaTime);

        animator.SetFloat("IsMoving", Mathf.Abs(playerMovement.x));

        if (Mathf.Abs(playerMovement.x) > 0.01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (playerMovement.x > 0 ? 1 : -1);
            transform.localScale = scale;
        }
    }
    #endregion

    #region Shoot
    protected override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("IsShooting");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().GoInDirection(firePoint.up);
        }
    }
    protected override void GunDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 directionToMouse = new Vector2(mousePosition.x - firePoint.position.x, mousePosition.y - firePoint.position.y);

        firePoint.up = directionToMouse;
    }
    #endregion
}
