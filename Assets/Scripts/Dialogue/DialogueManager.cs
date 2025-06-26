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
    private GameManager gameManager;
    private int currentPos;
    private DialogueBase currentDialogue;
    public static DialogueManager instance;
    [SerializeField] private PlayerStandard player;
    [SerializeField] private Elevator elevator;
    [SerializeField] private NPC npc;
    [SerializeField] private PlayerRange playerRange;
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
        gameManager = GameManager.instance;
    }
    private void Update()
    {
        SpaceCheck();
        npc = playerRange.NpcRange;
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
            currentDialogue = null;
            if (npc.IsY == true)
            {
                gameManager.OutOfPuzzle();
            }
            if (npc.PuzzleDone == false && npc.IsY == false)
            {
                gameManager.IntoPuzzle();
            }
            else if (npc.PuzzleDone == true && gameManager.IsDead == true)
            {
                npc.Animator.SetTrigger("Death");
            }
            else if (npc.PuzzleDone == true && gameManager.IsAlive == true)
            {
                npc.Animator.SetTrigger("Life");
            }
        }
    }
    #endregion
}