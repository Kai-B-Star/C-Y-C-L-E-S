using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Declarations
    public static GameManager instance;
    private bool isPaused;
    private UIManager uiManager;
    private int killCount;
    private int saveCount;
    [SerializeField] private GameObject mainGame;
    [SerializeField] private NPC npc;
    [SerializeField] private PlayerRange playerRange;
    [SerializeField] private Elevator elevator;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerBase playerBase;

    public int KillCount { get => killCount; set => killCount = value; }
    public int SaveCount { get => saveCount; set => saveCount = value; }
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
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
        KillCount = 0;
        SaveCount = 0;
        Resume();
    }
    private void Update()
    {
        PressPause();
        if (playerRange != null)
        {
            npc = playerRange.NpcRange;
        }
    }
    #endregion

    #region Pause
    public void PressPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        uiManager.PauseGame();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        uiManager.Resume();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        uiManager.Restart();
    }
    #endregion

    #region Puzzle
    public void IntoPuzzle()
    {
        uiManager.PickPuzzle();
        mainGame.SetActive(false);
        player.SetActive(false);
        npc.HasBeenTriggered = false;
        npc.RangeCollider.SetActive(true);
    }
    public void OutOfPuzzle()
    {
        mainGame.SetActive(true);
        npc.PuzzleDone = true;
        elevator.AddRequirement();  
        player.SetActive(true);
    }
    #endregion

    #region Choice
    public void Deactivate()
    {
        uiManager.ChoiceScreen.SetActive(false);
        npc.DialogueOnClick = npc.BadVersion;
        KillCount++;
        uiManager.HidePuzzle();
        OutOfPuzzle();
        //trigger death :( animation
    }
    public void Spare()
    {
        uiManager.ChoiceScreen.SetActive(false);
        npc.DialogueOnClick = npc.BadVersion;
        SaveCount++;
        uiManager.HidePuzzle();
        OutOfPuzzle();
        //trigger happy :) animation
    }
    #endregion

    #region HP
    public void LoseLives()
    {
        playerBase.Health--;
        uiManager.UpdateHP();
        if (playerBase.Health <= 0)
        {
            StartCoroutine(DeathTimer());
        }
    }
    private IEnumerator DeathTimer()
    {
        uiManager.DeathScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        uiManager.DeathScreen.SetActive(false);
        Restart();
    }
    #endregion
}