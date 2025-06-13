using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Declarations
    public static GameManager instance;
    private bool isPaused;
    private bool inPuzzle;
    private UIManager uiManager;
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject puzzleCam;
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
        playerCam.SetActive(true);
        puzzleCam.SetActive(false);
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

    #region Camera
    private void CameraSwap()
    {
        //if outside puzzle, player cam (bool?)
        //if inside puzzle, puzzle cam
    }
    #endregion

    #region Puzzle
    private void InPuzzle()
    {
        inPuzzle = true;
        uiManager.PickPuzzle();
        //make normal player freeze and puzzle player move
    }
    #endregion
}

//win-loss logic (in events uUuUUu fAnCYy)