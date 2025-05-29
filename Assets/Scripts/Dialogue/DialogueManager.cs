using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Text dialogueMessage;
    [SerializeField] private GameObject spaceIndicator;
    private UIManager uiManager;
    private int currentPos;
    private DialogueBase currentDialogue;
    public static DialogueManager instance;
    private PlayerStandard player;
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
            Destroy(gameObject);
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
    public void BeginDialogue(DialogueBase dialogueToStart)
    {
        PlayerFreeze();
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
    public void PlayerFreeze()
    {
        player.MovementSpeed = 0;
    }
    public void PlayerUnfreeze()
    {
        player.MovementSpeed = 10;
    }
}

