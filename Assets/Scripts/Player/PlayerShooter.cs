using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : PlayerStandard
{
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
