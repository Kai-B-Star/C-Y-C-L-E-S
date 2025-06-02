using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    #region Declarations
    [SerializeField] private DialogueBase dialogueOnClick;
    private bool hasBeenTriggered;
    private DialogueManager dialogueManager;
    [SerializeField] private GameObject rangeCollider;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        dialogueManager = DialogueManager.instance;
    }
    #endregion

    #region NPCTrigger
    public void NPCSpeak()
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            dialogueManager.BeginDialogue(dialogueOnClick);
            rangeCollider.SetActive(false);
        }
    }
    #endregion
}