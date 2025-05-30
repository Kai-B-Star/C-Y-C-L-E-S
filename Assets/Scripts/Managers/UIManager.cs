using System.Collections.Generic;
using UnityEngine;
using Application = UnityEngine.Application;

public class UIManager : MonoBehaviour
{
    #region Declarations
    public static UIManager instance;

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject credits;
    public enum MainMenuScreens { MainMenu, Options, Controls, Credits }
    private Dictionary<MainMenuScreens, GameObject> mainMenuOrganize;
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
        MainMenuDictionary();
    }
    #endregion

    #region MainMenu
    public void MainMenuDictionary()
    {
        mainMenuOrganize = new Dictionary<MainMenuScreens, GameObject>();
        mainMenuOrganize.Add(MainMenuScreens.MainMenu, mainMenu);
        mainMenuOrganize.Add(MainMenuScreens.Options, options);
        mainMenuOrganize.Add(MainMenuScreens.Controls, controls);
        mainMenuOrganize.Add(MainMenuScreens.Credits, credits);
    }
    public void ShowMainScreen(MainMenuScreens mainScreens)
    {
        foreach (var screen in mainMenuOrganize.Values)
        {
            if (screen != null) screen.SetActive(false);
        }

        if (mainMenuOrganize.ContainsKey(mainScreens) && mainMenuOrganize[mainScreens] != null)
        {
            mainMenuOrganize[mainScreens].SetActive(true);
        }
    }
    public void MainMenu()
    {
        ShowMainScreen(MainMenuScreens.MainMenu);
    }
    public void Options()
    {
        ShowMainScreen(MainMenuScreens.Options);
    }
    public void Controls()
    {
        ShowMainScreen(MainMenuScreens.Controls);
    }
    public void Credits()
    {
        ShowMainScreen(MainMenuScreens.Credits);
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region PauseMenu
    private void Pause()
    {
        
    }
    private void Resume()
    {

    }
    #endregion

}

//scene transition logic (main menu done)
//grab GameManager events and show respective panels
