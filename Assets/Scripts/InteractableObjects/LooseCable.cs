using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCable : MonoBehaviour
{
    #region Declarations
    [SerializeField] private Transform puzzleSpawn;
    [SerializeField] private GameObject shock;
    #endregion

    #region OnTrigger2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.gameObject.GetComponent<PlayerBase>();
        if (player != null )
        {
            StartCoroutine(Shock());
            player.transform.position = puzzleSpawn.position;
        }
    }

    private IEnumerator Shock()
    {
        shock.SetActive(true);
        yield return new WaitForSeconds(1f);
        shock.SetActive(false);
    }
    #endregion
}
