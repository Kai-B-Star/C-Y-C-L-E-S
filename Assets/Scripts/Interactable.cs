using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable: MonoBehaviour
{
    #region Declarations
    private bool isInRange;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interactAction;
    [SerializeField] private GameObject notify;
    #endregion

    #region MonoBehaviour
    private void Update()
    {
        InteractCheck();
    }
    #endregion

    #region Interact
    public void InteractCheck()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }
    #endregion

    #region OnTrigger2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBase>())
        {
            isInRange = true;
            notify.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerBase>())
        {
            isInRange = false;
            notify.SetActive(false);
        }
    }
    #endregion
}
