using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;

public class UIManager : MonoBehaviour
{
    #region Declarations
    public static UIManager instance;
    private bool is404 = false;
    private bool isNS = false;
    private bool isPH = false;
    private bool isPI = false;
    private bool isNF = false;

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;

    [Header("Puzzles")]
    [SerializeField] private GameObject r404;
    [SerializeField] private GameObject NS;
    [SerializeField] private GameObject PH;
    [SerializeField] private GameObject PI;
    [SerializeField] private GameObject NF;

    public enum UIScreens { MainMenu, Options, Controls, Credits, Pause }
    private Dictionary<UIScreens, GameObject> uiOrganize;

    public enum PuzzleScreens { R404, RNS, RPH, RPI, RNF}
    private Dictionary<PuzzleScreens, GameObject> puzzleOrganize;
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
        UIDictionary();
        PuzzleDictionary();
        if (pauseMenu != null)
        {
           pauseMenu.SetActive(false);
        }
    }
    #endregion

    #region MainMenu
    public void UIDictionary()
    {
        uiOrganize = new Dictionary<UIScreens, GameObject>();
        uiOrganize.Add(UIScreens.MainMenu, mainMenu);
        uiOrganize.Add(UIScreens.Options, options);
        uiOrganize.Add(UIScreens.Controls, controls);
        uiOrganize.Add(UIScreens.Credits, credits);
        uiOrganize.Add(UIScreens.Pause, pauseMenu);
    }
    public void ShowScreen(UIScreens mainScreens)
    {
        foreach (var screen in uiOrganize.Values)
        {
            if (screen != null) screen.SetActive(false);
        }

        if (uiOrganize.ContainsKey(mainScreens) && uiOrganize[mainScreens] != null)
        {
            uiOrganize[mainScreens].SetActive(true);
        }
    }
    public void MainMenu()
    {
        ShowScreen(UIScreens.MainMenu);
    }
    public void Options()
    {
        ShowScreen(UIScreens.Options);
    }
    public void Controls()
    {
        ShowScreen(UIScreens.Controls);
    }
    public void Credits()
    {
        ShowScreen(UIScreens.Credits);
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region PauseMenu
    public void PauseGame()
    {
        ShowScreen(UIScreens.Pause);
        pauseButton.SetActive(false);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region Puzzles
    public void PuzzleDictionary()
    {
        puzzleOrganize = new Dictionary<PuzzleScreens, GameObject>();
        puzzleOrganize.Add(PuzzleScreens.R404, r404);
        puzzleOrganize.Add(PuzzleScreens.RNS, NS);
        puzzleOrganize.Add(PuzzleScreens.RPH, PH);
        puzzleOrganize.Add(PuzzleScreens.RPI, PI);
        puzzleOrganize.Add(PuzzleScreens.RNF, NF);
    }
    public void ShowPuzzle(PuzzleScreens puzzleScreens)
    {
        foreach (var screen in uiOrganize.Values)
        {
            if (screen != null) screen.SetActive(false);
        }

        if (puzzleOrganize.ContainsKey(puzzleScreens) && puzzleOrganize[puzzleScreens] != null)
        {
            puzzleOrganize[puzzleScreens].SetActive(true);
        }
    }
    public void PickPuzzle()
    {
        pauseButton.SetActive(false);
        if(is404)
        {
            ShowPuzzle(PuzzleScreens.R404);
        }
        else if(isNS)
        {
            ShowPuzzle(PuzzleScreens.RNS);
        }
        else if(isPH)
        {
            ShowPuzzle(PuzzleScreens.RPH);
        }
        else if(isPI)
        {
            ShowPuzzle(PuzzleScreens.RPI);
        }
        else if(isNF)
        {
            ShowPuzzle(PuzzleScreens.RNF);
        }
        //make the puzzle shown match the robot (idk work ur magic)
    }
    #endregion
}

//scene transition logic (main menu done)
//grab GameManager events and show respective panels (pause done)
//hp system
