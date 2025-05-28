using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueTree")]
public class DialogueTree : ScriptableObject
{
    [SerializeField] private string[] messages;                               //keeps dialogue options stored

    public string[] Messages { get => messages; }
}
public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueTree dialogueOnClick;
    [SerializeField] private Collider2D collide;
    private void OnMouseDown()                                                //starts dialogue on click (to be changed to future interaction button
    {
        DialogueManager.instance.BeginDialogue(dialogueOnClick);
        collide.enabled = false;
    }
}
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueMessage;                 //manages current dialogue position and shows lines on screen
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
