using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Declarations
    public static GameManager instance;
    private bool isPaused;
    private UIManager uiManager;
    [SerializeField] private GameObject mainGame;
    [SerializeField] private NPC npc;
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
        isPaused = false;
    }
    private void Update()
    {
        PressPause();
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
    }
    public void OutOfPuzzle()
    {
        npc.PuzzleDone = true;
        mainGame.SetActive(true);
        //auto activate choice dialogue
        //deactivate puzzle
    }
    #endregion
}

//win-loss logic (in events uUuUUu fAnCYy)