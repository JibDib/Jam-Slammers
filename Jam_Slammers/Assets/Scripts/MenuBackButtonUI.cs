using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuBackButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject menuToClose;
    [SerializeField] private GameObject menuToOpen;
    [SerializeField] private GameObject firstSelectedOnReturn;

    public void OnUse()
    {
        menuToClose.SetActive(false);
        menuToOpen.SetActive(true);
        FindObjectOfType<EventSystem>().SetSelectedGameObject(firstSelectedOnReturn);
    }
}
