using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuzzle : PlayerBase
{
    #region Declarations
    private bool isGrounded;
    [SerializeField] private float jumpForce;
    private float groundCheckDistance = 1.5f;
    [SerializeField] private LayerMask groundLayer;

    public LayerMask GroundLayer { get => groundLayer; set => groundLayer = value; }
#endregion

    #region Movement
    protected override void MoveHandle()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rigidBody.velocity = new Vector2(horizontalInput * movementSpeed, rigidBody.velocity.y);

        animator.SetFloat("IsMoving", Mathf.Abs(horizontalInput));

        if (Mathf.Abs(horizontalInput) > 0.01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (horizontalInput > 0 ? 1 : -1);
            transform.localScale = scale;
        }
    }
#endregion

    #region Jump
    protected override void GroundCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, GroundLayer);
        isGrounded = hit;

        if (hit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetTrigger("Jump");
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    #endregion
}
