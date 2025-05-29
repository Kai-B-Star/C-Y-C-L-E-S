using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueMessage;
    [SerializeField] private GameObject spaceIndicator;
    private UIManager uiManager;
    private int currentPos;
    private DialogueTree currentDialogue;
    public static DialogueManager instance;
    private void Awake()
    {
        dialogueBox.SetActive(false);
        spaceIndicator.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    private void Start()
    {
        uiManager = UIManager.instance;
    }
    private void Update()
    {
        SpaceCheck();
    }
    private void SpaceCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialogue();
        }
    }
    public void BeginDialogue(DialogueTree dialogueToStart)
    {
        dialogueBox.SetActive(true);
        spaceIndicator.SetActive(true);

        currentDialogue = dialogueToStart;
        currentPos = 0;
        dialogueMessage.text = currentDialogue.Messages[currentPos];
    }
    public void AdvanceDialogue()
    {
        currentPos++;
        if (currentPos < currentDialogue.Messages.Length)
        {
            dialogueMessage.text = currentDialogue.Messages[currentPos];
        }
        else
        {
            currentDialogue = null;
            dialogueBox?.SetActive(false);
            spaceIndicator.SetActive(false);
        }
    }
}

