using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPuzzle : PlayerBase
{
    #region Declarations
    private bool isGrounded;
    private bool isRunning;
    [SerializeField] private float jumpForce;
    private float groundCheckDistance = 0.5f;
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
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    protected override void Run()
    {
        animator.SetBool("IsRunning", isRunning);
        if (isGrounded && isMoving && Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            movementSpeed = 15;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            movementSpeed = 10;
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
