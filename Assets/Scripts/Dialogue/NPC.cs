using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    #region Declarations
    [SerializeField] private DialogueBase dialogueOnClick;
    [SerializeField] private DialogueBase badVersion;
    [SerializeField] private DialogueBase goodVersion;
    private bool hasBeenTriggered;
    private DialogueManager dialogueManager;
    [SerializeField] private GameObject rangeCollider;
    [SerializeField] private GameObject mandatoryRange;
    [SerializeField] private bool is404 = false;
    [SerializeField] private bool isNS = false;
    [SerializeField] private bool isPH = false;
    [SerializeField] private bool isPI = false;
    [SerializeField] private bool isNF = false;
    [SerializeField] private bool isY = false;
    [SerializeField] private bool puzzleDone = false;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isDead = false;
    [SerializeField] private bool isAlive = false;

    public bool Is404 { get => is404; set => is404 = value; }
    public bool IsNS { get => isNS; set => isNS = value; }
    public bool IsPH { get => isPH; set => isPH = value; }
    public bool IsPI { get => isPI; set => isPI = value; }
    public bool IsNF { get => isNF; set => isNF = value; }
    public bool PuzzleDone { get => puzzleDone; set => puzzleDone = value; }
    public bool IsY { get => isY; set => isY = value; }
    public DialogueBase DialogueOnClick { get => dialogueOnClick; set => dialogueOnClick = value; }
    public DialogueBase BadVersion { get => badVersion; set => badVersion = value; }
    public DialogueBase GoodVersion { get => goodVersion; set => goodVersion = value; }
    public bool HasBeenTriggered { get => hasBeenTriggered; set => hasBeenTriggered = value; }
    public GameObject RangeCollider { get => rangeCollider; set => rangeCollider = value; }
    public GameObject MandatoryRange { get => mandatoryRange; set => mandatoryRange = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        dialogueManager = DialogueManager.instance;
        Animator = GetComponent<Animator>();
        IsDead = false;
        IsAlive = false;
    }
    #endregion

    #region NPCTrigger
    public void NPCSpeak()
    {
        if (!HasBeenTriggered)
        {
            HasBeenTriggered = true;
            dialogueManager.BeginDialogue(DialogueOnClick);
            RangeCollider.SetActive(false);
        }
    }
    #endregion
}