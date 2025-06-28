using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R404Movement : MonoBehaviour
{
    #region Declarations
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private Animator animator;
    private bool shouldMove = false;
    private bool isMoving;
    private int currentWaypointIndex = 0;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        animator = GetComponent<Animator>();
        isMoving = false;
    }
    private void Update()
    {
        if (shouldMove && waypoints.Length > 0)
        {
            WaypointMovement();
        }
    }
    #endregion

    #region Movement
    public void WaypointMovement()
    {
        animator.SetBool("IsMoving", isMoving);
        isMoving = true;
        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex == 2)
            {
                animator.SetTrigger("Jump");
            }
            if (currentWaypointIndex >= waypoints.Length)
            {
                shouldMove = false;
                isMoving = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }
    #endregion
}
