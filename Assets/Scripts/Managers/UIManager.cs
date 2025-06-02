using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    public enum UIScreens { MainMenu, Options, Controls, Credits, Pause }
    private Dictionary<UIScreens, GameObject> uiOrganize;
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

}

//scene transition logic (main menu done)
//grab GameManager events and show respective panels (pause done)
