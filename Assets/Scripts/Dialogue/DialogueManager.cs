using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Declarations
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Text dialogueMessage;
    [SerializeField] private GameObject spaceIndicator;
    private UIManager uiManager;
    private int currentPos;
    private DialogueBase currentDialogue;
    public static DialogueManager instance;
    [SerializeField] private PlayerStandard player;
    [SerializeField] private Elevator elevator;
    #endregion

    #region MonoBehaviour
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
    #endregion

    #region Dialogue
    private void SpaceCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialogue();
        }
    }
    public void BeginDialogue(DialogueBase dialogueToStart)
    {
        player.PlayerFreeze();
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
            dialogueBox?.SetActive(false);
            spaceIndicator.SetActive(false);
            player.PlayerUnfreeze();
            elevator.AddRequirement();
            currentDialogue = null;
        }
    }
    #endregion

}

