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

        animator.SetBool("MoveSpeed", isMoving);

        if(playerMovement.x != 0 | playerMovement.y != 0)
        {
            isMoving = true;
        }
        else
        {  
            isMoving = false;
        }

        if (playerMovement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (playerMovement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    #endregion
}

