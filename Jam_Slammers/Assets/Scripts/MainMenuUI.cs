using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject menuToOpen;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenuFirstSelected;
    public void Play()
    {
        int savedLevelIndex = 1; //open for level saving and loading - possibly
        
        
        string levelToLoad = SceneManager.GetSceneAt(savedLevelIndex).name;
        SceneManager.LoadScene(levelToLoad);
    }

    public void OpenMenu()
    {
        menuToOpen.SetActive(true);
        mainMenu.SetActive(false);
        FindObjectOfType<EventSystem>().SetSelectedGameObject(optionsMenuFirstSelected);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
