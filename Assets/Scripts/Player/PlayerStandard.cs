using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandard : PlayerBase
{
    #region Movement
    protected override void MoveHandle()
    {
        Vector2 playerMovement;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        rigidBody.MovePosition(rigidBody.position + playerMovement * movementSpeed * Time.fixedDeltaTime);

        animator.SetFloat("IsMoving" , Mathf.Abs(playerMovement.x));

        if (Mathf.Abs(playerMovement.x) > 0.01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (playerMovement.x > 0 ? 1: -1);
            transform.localScale = scale;
        }
    }
    #endregion
}

