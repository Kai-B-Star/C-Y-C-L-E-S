using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable: MonoBehaviour
{
    private bool isInRange;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interactAction;
    [SerializeField] private GameObject notify;

    private void Update()
    {
        InteractCheck();
    }
    private void InteractCheck()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction?.Invoke();   //erro nesse corno aqui
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStandard>())
        {
            isInRange = true;
            notify.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerStandard>())
        {
            isInRange = false;
            notify.SetActive(false);
        }
    }
}
