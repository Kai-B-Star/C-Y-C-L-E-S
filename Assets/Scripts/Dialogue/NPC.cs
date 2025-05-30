using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueBase dialogueOnClick;
    private bool hasBeenTriggered;
    private DialogueManager dialogueManager;
    private void Start()
    {
        dialogueManager = DialogueManager.instance;
    }
    public void NPCSpeak()
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            dialogueManager.BeginDialogue(dialogueOnClick);
        }
    }
}