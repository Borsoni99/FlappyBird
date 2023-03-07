using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Loadable Screens")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject characterSelectionMenu;

    private GameObject activeScreen;

    private void Awake()	
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        characterSelectionMenu.SetActive(false);
    }

    public void SetChar()
    {
        int characterIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log("Character set to "+characterIndex);
        GameManager.instance.CharIndex = characterIndex;     
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void CharSelectScreen()
    {   
        activeScreen = characterSelectionMenu;
        mainMenu.SetActive(false);
        characterSelectionMenu.SetActive(true);
    }

    public void BackButton()
    {
        activeScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SettingsMenu()
    {
        activeScreen = settingsMenu;
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}

