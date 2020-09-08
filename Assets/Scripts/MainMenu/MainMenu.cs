using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenu, PauseMenu, OptionsMenu;
        
    // Main Menu Buttons
    public Button StartBtn, OptionsBtn, ExitBtn;

    // Options Menu Buttons
    public Button BackBtn;

    // Pause Menu Buttons
    public Button PauseOptionsBtn, ReturnGameBtn, ReturnMainBtn;


    enum Menu
    {
        MainMenuScreen,
        PauseMenuScreen
    };

    Menu currentScene;

    void ClearEvents()
    {
        StartBtn.onClick.RemoveListener(StartGame);
        OptionsBtn.onClick.RemoveListener(DrawOptionsMenu);
        ExitBtn.onClick.RemoveListener(ExitGame);
        BackBtn.onClick.RemoveAllListeners();
        PauseOptionsBtn.onClick.RemoveListener(DrawOptionsMenu);
        ReturnGameBtn.onClick.RemoveListener(ResumeGame);
        ReturnMainBtn.onClick.RemoveListener(DrawMainMenu);
    }

    // Executes when the game begins
    private void Start()
    {
        StartMenu.SetActive(false);
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        // Sets the game's movement to 0, so there's no movement at all
        Time.timeScale = 0f;

        // Calls the function to draw the game's main menu
        DrawMainMenu();
    }

    // Creates the Main Menu
    void DrawMainMenu()
    {
        ClearEvents();
        // Is the options menu still active on the screen?
        if (OptionsMenu.activeSelf)
        {
            OptionsMenu.SetActive(false);
        }

        if (PauseMenu.activeSelf)
        {
            PauseMenu.SetActive(false);
        }

        StartMenu.SetActive(true);
        currentScene = Menu.MainMenuScreen;

        StartBtn.onClick.AddListener(StartGame);
        OptionsBtn.onClick.AddListener(DrawOptionsMenu);
        ExitBtn.onClick.AddListener(ExitGame);
    }

    // Starts the game
    public void StartGame()
    {
        ClearEvents();
        StartMenu.SetActive(false);

        // Sets the game's movement to normal
        Time.timeScale = 1f;
    }

    // Resume the game from pause Menu
    public void ResumeGame()
    {
        ClearEvents();
        PauseMenu.SetActive(false);

        // Sets the game's movement to normal
        Time.timeScale = 1f;
    }

    // Check actions in the menu for games into games
    private void Update()
    {
        
    }

    // Opens the options menu
    void DrawOptionsMenu()
    {
        ClearEvents();
        OptionsMenu.SetActive(true);
        switch (currentScene)
        {
            case Menu.MainMenuScreen:
                Debug.Log("Vim do Main Menu");
                StartMenu.SetActive(false);
                BackBtn.onClick.AddListener(DrawMainMenu);
                break;
            case Menu.PauseMenuScreen:
                Debug.Log("Vim do Pause Menu");
                PauseMenu.SetActive(false);
                BackBtn.onClick.AddListener(DrawPauseMenu);
                break;
        }
    }

    // Pauses the game and draws the pause menu
    public void DrawPauseMenu()
    {
        ClearEvents();
        // Is the options menu still active on the screen?
        if (OptionsMenu.activeSelf)
        {
            OptionsMenu.SetActive(false);
        }

        // Sets the game's movement to 0, so there's no movement at all
        Time.timeScale = 0f;

        PauseMenu.SetActive(true);
        currentScene = Menu.PauseMenuScreen;
        Debug.Log("Xablau carai");

        PauseOptionsBtn.onClick.AddListener(DrawOptionsMenu);
        ReturnGameBtn.onClick.AddListener(ResumeGame);
        ReturnMainBtn.onClick.AddListener(DrawMainMenu);
    }


    // Quits the game
    public void ExitGame()
    {
        Debug.Log("Exiting the Game");
        Application.Quit();
    }

}
