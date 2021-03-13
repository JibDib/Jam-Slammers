using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Play()
    {
        int savedLevelIndex = 1; //open for level saving and loading - possibly
        
        
        string levelToLoad = SceneManager.GetSceneAt(savedLevelIndex).name;
        SceneManager.LoadScene(levelToLoad);
    }

    public void OpenMenu(GameObject menuToOpen, GameObject currentMenu = null)
    {
        menuToOpen.SetActive(true);
        
        //close currently active menu
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
