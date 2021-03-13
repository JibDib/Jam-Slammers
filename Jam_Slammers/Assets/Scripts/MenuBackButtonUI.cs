using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject menuToClose;
    [SerializeField] private GameObject menuToOpen;

    public void OnUse()
    {
        menuToClose.SetActive(false);
        menuToOpen.SetActive(true);
    }
}
