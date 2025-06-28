using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Application;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    #region Declarations
    public static UIManager instance;

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject choiceScreen;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject demoScreen;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject murdererScreen;
    [SerializeField] private GameObject saviourScreen;
    [SerializeField] private GameObject pauseButton;

    [Header("Puzzles")]
    [SerializeField] private GameObject r404;
    [SerializeField] private GameObject NS;
    [SerializeField] private GameObject PH;
    [SerializeField] private GameObject PI;
    [SerializeField] private GameObject NF;

    [Header("HP")]
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [Header("Other")]
    [SerializeField] private NPC npc;
    [SerializeField] private PlayerRange playerRange;
    [SerializeField] private PlayerBase player;
    private GameManager gameManager;
    public enum UIScreens { MainMenu, Options, Controls, Credits, Pause, Choice, Demo }
    private Dictionary<UIScreens, GameObject> uiOrganize;

    public enum PuzzleScreens { R404, RNS, RPH, RPI, RNF}
    private Dictionary<PuzzleScreens, GameObject> puzzleOrganize;

    public GameObject ChoiceScreen { get => choiceScreen; set => choiceScreen = value; }
    public GameObject DeathScreen { get => deathScreen; set => deathScreen = value; }
    public GameObject MurdererScreen { get => murdererScreen; set => murdererScreen = value; }
    public GameObject SaviourScreen { get => saviourScreen; set => saviourScreen = value; }
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
        gameManager = GameManager.instance;
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
    private void Update()
    {
        if (playerRange != null)
        {
            npc = playerRange.NpcRange;
        }
    }
    #endregion

    #region Screens
    public void UIDictionary()
    {
        uiOrganize = new Dictionary<UIScreens, GameObject>();
        uiOrganize.Add(UIScreens.MainMenu, mainMenu);
        uiOrganize.Add(UIScreens.Options, options);
        uiOrganize.Add(UIScreens.Controls, controls);
        uiOrganize.Add(UIScreens.Credits, credits);
        uiOrganize.Add(UIScreens.Pause, pauseMenu);
        uiOrganize.Add(UIScreens.Choice, ChoiceScreen);
        uiOrganize.Add(UIScreens.Demo, demoScreen);
        //uiOrganize.Add(UIScreens.Murderer, murdererEnding);
        //uiOrganize.Add(UIScreens.Saviour, saviourEnding);
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
    public void StartGame()
    {
        SceneManager.LoadScene("FirstRoom");
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
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        if (npc.Is404)
        {
            print("404");
            ShowPuzzle(PuzzleScreens.R404);
        }
        else if (npc.IsNS)
        {
            ShowPuzzle(PuzzleScreens.RNS);
        }
        else if (npc.IsPH)
        {
            ShowPuzzle(PuzzleScreens.RPH);
        }
        else if (npc.IsPI)
        {
            ShowPuzzle(PuzzleScreens.RPI);
        }
        else if (npc.IsNF)
        {
            ShowPuzzle(PuzzleScreens.RNF);
        }
    }
    public void HidePuzzle()
    {
        pauseButton.SetActive(true);
        r404.SetActive(false);
        NS.SetActive(false);
        PH.SetActive(false);
        PI.SetActive(false);
        NF.SetActive(false);
    }
    #endregion

    #region Choice
    public void Choice()
    {
        ShowScreen(UIScreens.Choice);
    }
    #endregion

    #region HP
    public void UpdateHP()
    {
        foreach (Image heart in hearts)
        {
            heart.sprite = emptyHeart;
        }
        for (int i = 0; i < player.Health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
    #endregion

    #region Demo
    public void DemoScreen()
    {
        health.SetActive(false);
        ShowScreen(UIScreens.Demo);
    }
    //public void SecretEndings()
    //{
    //    if (gameManager.KillCount > gameManager.SaveCount)
    //    {
    //        ShowScreen(UIScreens.Murderer);
    //    }
    //    else if(gameManager.KillCount < gameManager.SaveCount)
    //    {
    //        ShowScreen(UIScreens.Saviour);
    //    }
    //    StartCoroutine(SecretEndingTimer());
    //}

    //private IEnumerator SecretEndingTimer()
    //{
    //    yield return new WaitForSeconds(10f);
    //    murdererEnding.SetActive(false);
    //    saviourEnding.SetActive(false);
    //}
    #endregion
}
