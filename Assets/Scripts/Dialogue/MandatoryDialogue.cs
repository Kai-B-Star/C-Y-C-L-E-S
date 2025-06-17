using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MandatoryDialogue : MonoBehaviour
{
    #region Declarations
    [SerializeField] private UnityEvent gotInRange;
    #endregion

    #region OnTrigger2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStandard>())
        {
            gotInRange.Invoke();
        }
    }
    #endregion
}
