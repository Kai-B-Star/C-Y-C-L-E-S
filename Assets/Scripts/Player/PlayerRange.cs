using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    #region Declarations
    private bool npcInRange;
    [SerializeField] private NPC npcRange;

    public NPC NpcRange { get => npcRange; set => npcRange = value; }
    #endregion

    #region OnTrigger2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NPC>())
        {
           npcInRange = true;
           NpcRange = collision.gameObject.GetComponent<NPC>(); ;
        }
    }
    #endregion
}
