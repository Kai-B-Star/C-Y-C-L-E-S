using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueTree dialogueOnClick;
    private bool hasBeenTriggered;
    public void NPCSpeak()                                                //starts dialogue on click (to be changed to future interaction button
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            print("triggered");
            DialogueManager.instance.BeginDialogue(dialogueOnClick);
        }
    }
}
