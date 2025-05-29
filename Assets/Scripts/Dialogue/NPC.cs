using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueBase dialogueOnClick;
    private bool hasBeenTriggered;
    public void NPCSpeak()
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            DialogueManager.instance.BeginDialogue(dialogueOnClick);
        }
    }
}